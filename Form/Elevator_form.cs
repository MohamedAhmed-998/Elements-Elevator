using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Document = Autodesk.Revit.DB.Document;
using System.Linq;
using System.Diagnostics;

namespace Element_Elevator
{
    public partial class Elevator_form : System.Windows.Forms.Form
    {
        // Define public fields to be accessed by other classes
        public UIDocument uidoc;
        public Document doc;
        public method m;
        public List<Element> listelems;
        public List<List<Element>> grlist;
        public List<Level> listlevels;
        public TreeNode parentnode1;
        public TreeNode childnode1;
        public TreeNode childNode;
        public List<Element> check_list = new List<Element>();
        public List<Element> allbeams1 = new List<Element>();
        public List<Element> elem1 = new List<Element>();
        private List<TreeNode> selectedNodes = new List<TreeNode>();
        List<string> text_list = new List<string>();
        List<string> text_list1 = new List<string>();

        private ExternalEvent exEvent;
        private Event_Handler handler;
        // Constructor to initialize form components and set up external event
        public Elevator_form()
        {
            InitializeComponent();
            handler = new Event_Handler();
            exEvent = ExternalEvent.Create(handler);
        }
        // Event handler for checking/unchecking nodes in the tree view
        public void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                // If node has child nodes, update their checked state
                if (e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode childNode in e.Node.Nodes)
                    {
                        childNode.Checked = e.Node.Checked;
                    }
                }
                // Add or remove the element associated with the node from the check_list
                Element element = e.Node.Tag as Element;
                if (e.Node.Checked)
                {
                    check_list.Add(element);
                    selectedNodes.Add(e.Node);
                }
                else
                {
                    check_list.Remove(element);
                }
                // Update the text boxes with the levels of the selected elements
                UpdateTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }
        // Method to update the text boxes with the levels of the selected elements
        private void UpdateTextBoxes()
        {
            text_list.Clear();
            text_list1.Clear();

            foreach (Element elem in check_list)
            {
                if (elem != null)
                {
                    if (elem.Category.Name == "Floors" || elem.Category.Name == "Structural Foundations")
                    {
                        var tp = elem.ParametersMap.get_Item("Level").AsValueString();
                        text_list.Add(tp);
                    }
                    if (elem.Category.Name == "Structural Columns")
                    {
                        var tp = elem.ParametersMap.get_Item("Top Level").AsValueString();
                        text_list.Add(tp);
                        var bot = elem.ParametersMap.get_Item("Base Level").AsValueString();
                        text_list1.Add(bot);
                    }
                    if (elem.Category.Name == "Structural Framing")
                    {
                        var tp = elem.ParametersMap.get_Item("Reference Level").AsValueString();
                        text_list.Add(tp);
                    }
                    if (elem.Category.Name == "Walls")
                    {
                        var tp = elem.ParametersMap.get_Item("Top Constraint").AsValueString();
                        text_list.Add(tp);
                        var botwall = elem.ParametersMap.get_Item("Base Constraint").AsValueString();
                        text_list1.Add(botwall);
                    }
                    if (elem.Category.Name == "Stairs")
                    {
                        var tp = elem.ParametersMap.get_Item("Top Level").AsValueString();
                        text_list.Add(tp);
                        var bt = elem.ParametersMap.get_Item("Base Level").AsValueString();
                        text_list1.Add(bt);
                    }
                    if (elem.Category.Name == "Shaft Openings")
                    {
                        var tp = elem.ParametersMap.get_Item("Top Constraint").AsValueString();
                        text_list.Add(tp);
                        var bt1 = elem.ParametersMap.get_Item("Base Constraint").AsValueString();
                        text_list1.Add(bt1);
                    }
                }
            }
            // Set the text boxes based on the levels of the selected elements
            if (text_list.Count > 1 && text_list.Distinct().Count() > 1)
            {
                text_box1.Text = "Multiple Levels";
            }
            else if (text_list.Count > 0)
            {
                text_box1.Text = text_list[0];
            }
            else
            {
                text_box1.Clear();
            }

            if (text_list1.Count > 1 && text_list1.Distinct().Count() > 1)
            {
                Textbox2.Text = "Multiple Levels";
            }
            else if (text_list1.Count > 0)
            {
                Textbox2.Text = text_list1[0];
            }
            else
            {
                Textbox2.Clear();
            }
        }
        // Event handler for the "Move" button click
        public void movingbt_Click(object sender, EventArgs e)
        {
            try
            {
                // Store data for the external event
                data_storage.check_list = check_list;
                data_storage.SelectedNodes = selectedNodes;
                data_storage.Elevation = elevation;
                data_storage.bottomelev = Bottom_elev;
                data_storage.text_box1 = text_box1;
                data_storage.text_box2 = Textbox2;
                // Raise the external event to execute Revit commands
                revitplugin.exevent.Raise();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }
        // Event handler for form load
        private void Elevator_form_Load(object sender, EventArgs e)
        {
        }
        // Event handler for the "Close" button click
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Event handler for elevation control load
        public void elevation_Load(object sender, EventArgs e)
        {
            elevation.DecimalPlaces = 2;
            elevation.Increment = 0.1m;
            elevation.Minimum = decimal.MinValue;
            elevation.Maximum = decimal.MaxValue;
        }
        // Event handler for text boxes 1 & 2 text change
        private void text_box1_TextChanged(object sender, EventArgs e)
        {
            text_box1.ReadOnly = true;
        }
        private void Textbox2_TextChanged(object sender, EventArgs e)
        {
            Textbox2.ReadOnly = true;
        }
        private void help_button_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(help_button, 0, 42);
        }
        // Event handler for  bottom elevation control load
        private void Bottom_elev_Load(object sender, EventArgs e)
        {
            Bottom_elev.DecimalPlaces = 2;
            Bottom_elev.Increment = 0.1m;
            Bottom_elev.Minimum = decimal.MinValue;
            Bottom_elev.Maximum = decimal.MaxValue;
        }
        private void guna2ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/mohamed-ahmed-fathy-beblawy-6485a2133/";
            Process.Start(url);
        }
        private void text_box1_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void githubLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/MohamedAhmed-998";
            Process.Start(url);
        }
    }
}
