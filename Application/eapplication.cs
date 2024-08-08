using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics.CodeAnalysis;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Autodesk.Revit.DB.Structure.StructuralSections;
using System.Security.Cryptography;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Mechanical;
using System.Windows.Documents;
using System.Windows.Controls;
using Grid = Autodesk.Revit.DB.Grid;
using System.Security.AccessControl;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Xml.Linq;
using System.Reflection;


namespace Element_Elevator
{
    public class eapplication : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("Elements Elevator");
            var panel = application.CreateRibbonPanel("Elements Elevator", "Structural");
            var pushdata = new PushButtonData("fth-addin", "Elements_Elevator", Assembly.GetExecutingAssembly().Location, "Element_Elevator.revitplugin");
            var bitimage = new BitmapImage(new Uri("pack://application:,,,/Element_Elevator;component/transferr.ico"));
            pushdata.LargeImage = bitimage;
            pushdata.ToolTip= "Elements Elevator: Modify elevations and levels of selected elements in your Revit project.";
            panel.AddItem(pushdata);
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}

