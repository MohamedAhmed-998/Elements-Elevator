using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Element_Elevator
{
    public class Event_Handler : IExternalEventHandler
    {
        // This method is executed when the external event is raised
        public void Execute(UIApplication app)
        {
            // Retrieve the active document and necessary data from the data storage
            Document doc = app.ActiveUIDocument.Document;
            var listlevels = data_storage.ListLevels;
            var check_list = data_storage.check_list;
            var selectedNodes = data_storage.SelectedNodes;
            var elevation = data_storage.Elevation;
            var text_box1 = data_storage.text_box1;
            // Initialize lists to store calculation results and level information
            List<double> doubles = new List<double>();
            List<double> bottom_doubles = new List<double>();
            List<Level> min_level = new List<Level>();
            List<Level> min_level1 = new List<Level>();
            List<string> st = new List<string>();
            List<string> st1 = new List<string>();
            listlevels= listlevels.OrderBy(l=>l.Elevation).ToList();
            try
            {
                // Ensure that levels Exists
                if (listlevels != null && listlevels.Count > 0)
                {
                    double distance = 0;
                    // Iterate through the elements in the check_list
                    foreach (Element el in check_list)
                    {
                        // Start a transaction to move elements to the new levels
                        using (Transaction tlev = new Transaction(doc, "Move Elements to Levels"))
                        {
                            tlev.Start();
                            try
                            {
                                // Iterate through the selected nodes in the UI tree view
                                foreach (TreeNode nod1 in selectedNodes)
                                {
                                    // Check if the element is selected and matches the node text
                                    if (el != null && check_list != null && nod1.Checked && el.Name == nod1.Text)
                                    {
                                        // Handle floors and structural foundations
                                        if (el.Category.Name == "Floors" || el.Category.Name == "Structural Foundations")
                                        {
                                            // Convert elevation to feet
                                            double elevationInFeet = Convert.ToDouble(elevation.Value) * 3.28084;
                                            // If the elevation is greater than or equal to the last level's elevation
                                            if (elevationInFeet >= listlevels.Last().Elevation)
                                            {
                                                // Set the element level to the last level and adjust the height offset
                                                el.ParametersMap.get_Item("Level").Set(listlevels.Last().Id);
                                                el.ParametersMap.get_Item("Height Offset From Level").Set(elevationInFeet - listlevels.Last().Elevation);
                                                text_box1.Text = listlevels.Last().Name;
                                            }
                                            //set new level and elevation in case of the user entered any level except last level elevation
                                            else
                                            {
                                                double x = 0;
                                                // Calculate the closest level and set the element to that level
                                                foreach (var lev in listlevels)
                                                {
                                                    double difference = elevationInFeet - lev.Elevation;
                                                    doubles.Add(Math.Abs(difference));
                                                    distance = doubles.Min();
                                                    x = difference > 0 ? distance - elevationInFeet : distance + elevationInFeet;
                                                }

                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(distance, 5) == Math.Round(Math.Abs(elevationInFeet - lev1.Elevation), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                }

                                                text_box1.Text = st.First();
                                                el.ParametersMap.get_Item("Level").Set(min_level.First().Id);
                                                el.ParametersMap.get_Item("Height Offset From Level").Set(elevationInFeet - min_level.First().Elevation);
                                            }
                                        }
                                        #region beams
                                        // Handle structural framing (beams)
                                        else if (el.Category.Name == "Structural Framing")
                                        {
                                            var offset = el.ParametersMap;
                                            var param = el.ParametersMap;
                                            if (param.Contains("Start Level Offset"))
                                            {
                                                var x1 = param.get_Item("Start Level Offset");
                                                x1.Set(0.0000001);
                                            }
                                            if (param.Contains("End Level Offset"))
                                            {
                                                el.ParametersMap.get_Item("End Level Offset").Set(0.0000001);
                                            }
                                            if (Convert.ToDouble(elevation.Value) * 3.28084 >= listlevels.Last().Elevation)
                                            {
                                                el.ParametersMap.get_Item("Reference Level").Set(listlevels.Last().Id);
                                                double number = listlevels.Last().Elevation / 3.28084;
                                                text_box1.Text = listlevels.Last().Name;
                                                if (offset.Contains("z Offset Value"))
                                                {
                                                    var p = offset.get_Item("z Offset Value");
                                                    p.Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - listlevels.Last().Elevation));
                                                }
                                                if (param.Contains("Start Level Offset"))
                                                {
                                                    var x1 = param.get_Item("Start Level Offset");
                                                    x1.Set(0.0000001);
                                                }
                                                if (param.Contains("End Level Offset"))
                                                {
                                                    el.ParametersMap.get_Item("End Level Offset").Set(0.0000001);
                                                }
                                            }
                                            else
                                            {
                                                double x = 0;
                                                foreach (var lev in listlevels)
                                                {
                                                    var doub = Convert.ToDouble(elevation.Value) * 3.28084 - lev.Elevation;
                                                    if (doub < 0)
                                                    {
                                                        doubles.Add(doub * (-1));
                                                    }
                                                    if (doub >= 0)
                                                    {
                                                        doubles.Add(doub);
                                                    }
                                                    distance = doubles.Min();
                                                    x = distance + Convert.ToDouble(elevation.Value) * 3.28084;
                                                    if (x > lev.Elevation)
                                                    {
                                                        x = distance - Convert.ToDouble(elevation.Value) * 3.28084;
                                                    }
                                                }
                                                x = x;
                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(elevation.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                }
                                                text_box1.Text = st.First();
                                                if (offset.Contains("z Offset Value"))
                                                {
                                                    var p = offset.get_Item("z Offset Value");
                                                    p.Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - (min_level.First().Elevation)));
                                                    var ofx = offset.get_Item("z Offset Value").AsDouble();
                                                }
                                                if (param.Contains("Start Level Offset"))
                                                {
                                                    var x1 = param.get_Item("Start Level Offset");
                                                    x1.Set(0.0000001);
                                                }
                                                if (param.Contains("End Level Offset"))
                                                {
                                                    el.ParametersMap.get_Item("End Level Offset").Set(0.0000001);
                                                }
                                            }
                                        }
                                        #endregion
                                        #region columns
                                        // Handle structural columns
                                        else if (el.Category.Name == "Structural Columns")
                                        {
                                            if (Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 <= listlevels.First().Elevation && Convert.ToDouble(elevation.Value) * 3.28084 >= listlevels.Last().Elevation)
                                            {
                                                el.ParametersMap.get_Item("Base Level").Set(listlevels.First().Id);
                                                double number1 = listlevels.First().Elevation / 3.28084;
                                                data_storage.text_box2.Text = listlevels.First().Name;
                                                el.ParametersMap.get_Item("Base Offset").Set((Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084) - listlevels.First().Elevation);
                                                el.ParametersMap.get_Item("Top Level").Set(listlevels.Last().Id);
                                                el.ParametersMap.get_Item("Top Offset").Set((Convert.ToDouble(elevation.Value) * 3.28084) - listlevels.Last().Elevation);
                                                double number = listlevels.Last().Elevation / 3.28084;
                                                text_box1.Text = listlevels.Last().Name;
                                            }
                                            else
                                            {
                                                double x = 0;
                                                foreach (var lev in listlevels)
                                                {
                                                    var doub_top = Convert.ToDouble(elevation.Value) * 3.28084 - lev.Elevation;
                                                    var doub_bot = Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev.Elevation;
                                                    doubles.Add(Math.Abs(doub_top));
                                                    bottom_doubles.Add(Math.Abs(doub_bot));
                                                    distance = doubles.Min();
                                                    data_storage.distance = bottom_doubles.Min();
                                                    x = distance + Convert.ToDouble(elevation.Value) * 3.28084;
                                                    if (x > lev.Elevation)
                                                    {
                                                        x = distance - Convert.ToDouble(elevation.Value) * 3.28084;

                                                    }
                                                }
                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(data_storage.distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st1.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                    if (Math.Round(distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(elevation.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level1.Add(lev1);
                                                    }
                                                }
                                                text_box1.Text = st.First();
                                                data_storage.text_box2.Text = st1.First();
                                                el.ParametersMap.get_Item("Base Level").Set(listlevels.Where(f => f.Name == st1.First()).First().Id);
                                                el.ParametersMap.get_Item("Top Level").Set(listlevels.Where(f => f.Name == st.First()).Last().Id);
                                                el.ParametersMap.get_Item("Base Offset").Set((((Convert.ToDouble(data_storage.bottomelev.Value)) * 3.28084) - (min_level.First().Elevation)));
                                                el.ParametersMap.get_Item("Top Offset").Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - (min_level1.First().Elevation)));
                                            }
                                        }
                                        #endregion
                                        #region walls
                                        // Handle Structural Walls
                                        else if (el.Category.Name == "Walls")
                                        {
                                            if (Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 <= listlevels.First().Elevation && Convert.ToDouble(elevation.Value) * 3.28084 >= listlevels.Last().Elevation)
                                            {
                                                el.ParametersMap.get_Item("Base Constraint").Set(listlevels.First().Id);
                                                double number1 = listlevels.First().Elevation / 3.28084;
                                                data_storage.text_box2.Text = listlevels.First().Name;
                                                el.ParametersMap.get_Item("Base Offset").Set((Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084) - listlevels.First().Elevation);
                                                el.ParametersMap.get_Item("Top Constraint").Set(listlevels.Last().Id);
                                                el.ParametersMap.get_Item("Top Offset").Set((Convert.ToDouble(elevation.Value) * 3.28084) - listlevels.Last().Elevation);
                                                double number = listlevels.Last().Elevation;
                                            }
                                            else
                                            {
                                                double x = 0;
                                                foreach (var lev in listlevels)
                                                {
                                                    var doub_top = Convert.ToDouble(elevation.Value) * 3.28084 - lev.Elevation;
                                                    var doub_bot = Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev.Elevation;
                                                    doubles.Add(Math.Abs(doub_top));
                                                    bottom_doubles.Add(Math.Abs(doub_bot));
                                                    distance = doubles.Min();
                                                    data_storage.distance = bottom_doubles.Min();
                                                    x = distance + Convert.ToDouble(elevation.Value) * 3.28084;
                                                    if (x > lev.Elevation)
                                                    {
                                                        x = distance - Convert.ToDouble(elevation.Value) * 3.28084;

                                                    }
                                                }
                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(data_storage.distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st1.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                    if (Math.Round(distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(elevation.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level1.Add(lev1);
                                                    }
                                                }
                                                data_storage.text_box2.Text = st1.First();
                                                text_box1.Text = st.First();
                                                el.ParametersMap.get_Item("Base Constraint").Set(listlevels.Where(f => f.Name == st1.First()).First().Id);
                                                el.ParametersMap.get_Item("Top Constraint").Set(listlevels.Where(f => f.Name == st.First()).Last().Id);
                                                el.ParametersMap.get_Item("Base Offset").Set((((Convert.ToDouble(data_storage.bottomelev.Value)) * 3.28084) - (min_level.First().Elevation)));
                                                el.ParametersMap.get_Item("Top Offset").Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - (min_level1.First().Elevation)));
                                            }
                                        }
                                        #endregion
                                        #region stairs
                                        // Handle  Stairs
                                        else if (el.Category.Name == "Stairs")
                                        {
                                            if (Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 <= listlevels.First().Elevation && Convert.ToDouble(elevation.Value) * 3.28084 >= listlevels.Last().Elevation)
                                            {
                                                el.ParametersMap.get_Item("Base Level").Set(listlevels.First().Id);
                                                double number1 = listlevels.First().Elevation / 3.28084;
                                                data_storage.text_box2.Text = listlevels.First().Name;
                                                el.ParametersMap.get_Item("Base Offset").Set((Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084) - listlevels.First().Elevation);
                                                el.ParametersMap.get_Item("Top Level").Set(listlevels.Last().Id);
                                                el.ParametersMap.get_Item("Top Offset").Set((Convert.ToDouble(elevation.Value) * 3.28084) - listlevels.Last().Elevation);
                                                double number = listlevels.Last().Elevation / 3.28084;
                                                text_box1.Text = listlevels.Last().Name;
                                            }
                                            else
                                            {
                                                double x = 0;
                                                foreach (var lev in listlevels)
                                                {
                                                    var doub_top = Convert.ToDouble(elevation.Value) * 3.28084 - lev.Elevation;
                                                    var doub_bot = Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev.Elevation;
                                                    doubles.Add(Math.Abs(doub_top));
                                                    bottom_doubles.Add(Math.Abs(doub_bot));
                                                    distance = doubles.Min();
                                                    data_storage.distance = bottom_doubles.Min();
                                                    x = distance + Convert.ToDouble(elevation.Value) * 3.28084;
                                                    if (x > lev.Elevation)
                                                    {
                                                        x = distance - Convert.ToDouble(elevation.Value) * 3.28084;

                                                    }
                                                }
                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(data_storage.distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st1.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                    if (Math.Round(distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(elevation.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level1.Add(lev1);
                                                    }
                                                }
                                            }
                                            text_box1.Text = st.First();
                                            data_storage.text_box2.Text = st1.First();
                                            el.ParametersMap.get_Item("Base Level").Set(listlevels.Where(f => f.Name == st.First()).First().Id);
                                            el.ParametersMap.get_Item("Top Level").Set(listlevels.Where(f => f.Name == st.First()).Last().Id);
                                            el.ParametersMap.get_Item("Base Offset").Set((((Convert.ToDouble(data_storage.bottomelev.Value)) * 3.28084) - (min_level.First().Elevation)));
                                            el.ParametersMap.get_Item("Top Offset").Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - (min_level1.First().Elevation)));
                                        }
                                        #endregion
                                        #region shaft_opening
                                        // Handle Shaft Openings
                                        else if (el.Category.Name == "Shaft Openings")
                                        {
                                            if (Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 <= listlevels.First().Elevation && Convert.ToDouble(elevation.Value) * 3.28084 >= listlevels.Last().Elevation)
                                            {
                                                el.ParametersMap.get_Item("Base Constraint").Set(listlevels.First().Id);
                                                double number1 = listlevels.First().Elevation / 3.28084;
                                                data_storage.text_box2.Text = listlevels.First().Name;
                                                el.ParametersMap.get_Item("Base Offset").Set((Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084) - listlevels.First().Elevation);
                                                el.ParametersMap.get_Item("Top Constraint").Set(listlevels.Last().Id);
                                                el.ParametersMap.get_Item("Top Offset").Set((Convert.ToDouble(elevation.Value) * 3.28084) - listlevels.Last().Elevation);
                                                double number = listlevels.Last().Elevation;
                                            }
                                            else
                                            {
                                                double x = 0;
                                                foreach (var lev in listlevels)
                                                {
                                                    var doub_top = Convert.ToDouble(elevation.Value) * 3.28084 - lev.Elevation;
                                                    var doub_bot = Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev.Elevation;
                                                    doubles.Add(Math.Abs(doub_top));
                                                    bottom_doubles.Add(Math.Abs(doub_bot));
                                                    distance = doubles.Min();
                                                    data_storage.distance = bottom_doubles.Min();
                                                    x = distance + Convert.ToDouble(elevation.Value) * 3.28084;
                                                    if (x > lev.Elevation)
                                                    {
                                                        x = distance - Convert.ToDouble(elevation.Value) * 3.28084;

                                                    }
                                                }
                                                foreach (var lev1 in listlevels)
                                                {
                                                    if (Math.Round(data_storage.distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(data_storage.bottomelev.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st1.Add(lev1.Name);
                                                        min_level.Add(lev1);
                                                    }
                                                    if (Math.Round(distance, 5) == Math.Round((Math.Abs(Convert.ToDouble(elevation.Value) * 3.28084 - lev1.Elevation)), 5))
                                                    {
                                                        st.Add(lev1.Name);
                                                        min_level1.Add(lev1);
                                                    }
                                                }
                                                data_storage.text_box2.Text = st1.First();
                                                text_box1.Text = st.First();
                                                el.ParametersMap.get_Item("Base Constraint").Set(listlevels.Where(f => f.Name == st1.First()).First().Id);
                                                el.ParametersMap.get_Item("Top Constraint").Set(listlevels.Where(f => f.Name == st.First()).Last().Id);
                                                el.ParametersMap.get_Item("Base Offset").Set((((Convert.ToDouble(data_storage.bottomelev.Value)) * 3.28084) - (min_level.First().Elevation)));
                                                el.ParametersMap.get_Item("Top Offset").Set((((Convert.ToDouble(elevation.Value)) * 3.28084) - (min_level1.First().Elevation)));
                                            }
                                        }
                                        #endregion
                                        #region levels
                                        else if (el.Category.Name == "Levels")
                                        {
                                            el.ParametersMap.get_Item("Elevation").Set((Convert.ToDouble(elevation.Value)) * 3.28084);
                                        }
                                        #endregion
                                    }
                                }

                                tlev.Commit();
                            }
                            catch (Exception ex)
                            {
                                // Log the exception
                                TaskDialog.Show("Error", ex.Message + "\n" + ex.StackTrace);
                                tlev.RollBack();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // General exception handling
                TaskDialog.Show("Error", ex.Message + "\n" + ex.StackTrace);
            }
        }
        public string GetName()
        {
            return "element elevator";
        }
    }
}
