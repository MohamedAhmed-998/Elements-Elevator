using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

namespace Element_Elevator
{
    // Set Filter
    class instancefilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is FamilyInstance;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
    // Define the revitplugin class implementing IExternalCommand with necessary attributes
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class revitplugin : IExternalCommand
    {
        public static ExternalEvent exevent { get; set; }
        public static Event_Handler evhand { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Check Revit version
            string revitVersion = commandData.Application.Application.VersionNumber;
            int version;
            if (int.TryParse(revitVersion, out version))
            {
                // If Revit version is not between 2020 and 2024, show a message and cancel the command
                if (version <= 2016 || version >= 2025)
                {
                    TaskDialog.Show("Unsupported Version", "This add-in only works with Revit versions 2020 to 2024.");
                    return Result.Cancelled;
                }
            }
            else
            {
                TaskDialog.Show("Error", "Unable to determine Revit version.");
                return Result.Failed;
            }

            #region generalmethod
            // Initialize Revit application and document objects
            UIApplication uiapp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = commandData.Application.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = commandData.Application.ActiveUIDocument.Document;
            method m = new method(doc);
            #endregion
            #region element elevator
            // Start a transaction group for the element elevator operation
            TransactionGroup tg = new TransactionGroup(doc, "tg");
            tg.Start();
            // Create and initialize the Elevator_form
            Elevator_form evform = new Elevator_form();
            #region set form data
            evform.uidoc = uidoc;
            evform.doc = doc;
            evform.m = m;
            #endregion

            List<Level> levels = null;
            List<Element> list_elements = null;
            try
            {
                // Get project levels
                levels = new FilteredElementCollector(doc).OfClass(typeof(Level)).Cast<Level>().ToList();
                // Select structural elements
                list_elements = uidoc.Selection.PickObjects(ObjectType.Element, "Select Elements You Want To Change Elevations")
                    .Select(p => doc.GetElement(p))
                    .Where(v => v.Category.Name == "Structural Foundations" || v.Category.Name == "Walls" || v.Category.Name == "Structural Columns" ||
                                v.Category.Name == "Structural Framing" || v.Category.Name == "Floors" || v.Category.Name == "Shaft Openings" ||
                                v.Category.Name == "Stairs").ToList();
            }
            catch { }
            if (list_elements != null)
            {
                // Sort levels by name and set to form
                levels = levels.OrderBy(k => k.Name).ToList();
                evform.listlevels = levels;
                var groupelist1 = list_elements.GroupBy(q => q.Category.Name);
                evform.listelems = list_elements;
                TreeNode parentNode = new TreeNode();
                TreeNode childNode = new TreeNode();

                // Set the Parent and Child nodes
                foreach (var group in groupelist1)
                {
                    parentNode = evform.treeView1.Nodes.Add(group.Key);
                    foreach (Element el in group)
                    {
                        childNode = parentNode.Nodes.Add(el.Name);
                        // Set the Tag property to the Element object
                        childNode.Tag = el;
                    }
                }
                evform.parentnode1 = parentNode;
                evform.childnode1 = childNode;

                Elevator_form elform = new Elevator_form();
                using (Transaction t98 = new Transaction(doc, "t98"))
                {
                    t98.Start();
                    // Setting start and end levels to make reference levels editable parameter
                    foreach (Element elem in list_elements)
                    {
                        if (elem.Category.Name == "Structural Framing")
                        {
                            ParameterMap paramMap = elem.ParametersMap;
                            foreach (Parameter param in paramMap)
                            {
                                if (param.Definition.Name == "Start Level Offset")
                                {
                                    // Parameter found, proceed with setting the value
                                    param.Set(0.0000001);
                                }
                                if (param.Definition.Name == "End Level Offset")
                                {
                                    // Parameter found, proceed with setting the value
                                    param.Set(0.0000001);
                                }
                            }
                        }
                    }
                    t98.Commit();
                }
                // Set form data to static storage for the event handler
                data_storage.ListLevels = evform.listlevels;
                evhand = new Event_Handler();
                exevent = ExternalEvent.Create(evhand);
                evform.Show();
            }
            tg.Assimilate();
            return Result.Succeeded;
            #endregion
        }
    }
}
