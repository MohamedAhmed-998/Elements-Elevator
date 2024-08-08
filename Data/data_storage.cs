using Autodesk.Revit.DB;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Element_Elevator
{
    public static class data_storage
    {
        public static List<Level> ListLevels { get; set; }
        public static List<Element> check_list { get; set; }
        public static List<TreeNode> SelectedNodes { get; set; }
        public static Guna2NumericUpDown Elevation { get; set; }
        public static Guna2NumericUpDown bottomelev { get; set; }
        public static Guna2TextBox text_box1 { get; set; }
        public static Guna2TextBox text_box2 { get; set; }
        public static List<double> doubles { get; set; }
        public static double double2 { get; set; }
        public static double distance { get; set; }
        public static List<double> bottom_doubles { get; set; }
        public static List<Level> min_level { get; set; }
        public static List<Level> min_level1 { get; set; }
        public static List<string> st { get; set; }
        public static List<string> st1 { get; set; }


    }
}
