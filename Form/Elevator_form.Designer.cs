using System;

namespace Element_Elevator
{
    partial class Elevator_form
    {
        /// <summary>b
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elevator_form));
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.movingbt = new Guna.UI2.WinForms.Guna2Button();
            this.Close = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.elevation = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.n1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.text_box1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.Textbox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.help_button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bottom_elev = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.elevation)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bottom_elev)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // guna2ControlBox1
            // 
            resources.ApplyResources(this.guna2ControlBox1, "guna2ControlBox1");
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.PressedColor = System.Drawing.Color.Red;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.HideSelection = false;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // movingbt
            // 
            this.movingbt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.movingbt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.movingbt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.movingbt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.movingbt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            resources.ApplyResources(this.movingbt, "movingbt");
            this.movingbt.ForeColor = System.Drawing.Color.Black;
            this.movingbt.Name = "movingbt";
            this.movingbt.Click += new System.EventHandler(this.movingbt_Click);
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            resources.ApplyResources(this.Close, "Close");
            this.Close.ForeColor = System.Drawing.Color.Black;
            this.Close.Name = "Close";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // elevation
            // 
            this.elevation.BackColor = System.Drawing.Color.Transparent;
            this.elevation.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.elevation, "elevation");
            this.elevation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.elevation.Name = "elevation";
            this.elevation.Load += new System.EventHandler(this.elevation_Load);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // n1
            // 
            this.n1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.n1.Name = "zob";
            this.n1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.n1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.n1.RenderStyle.ColorTable = null;
            this.n1.RenderStyle.RoundedEdges = true;
            this.n1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.n1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.n1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.n1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.n1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            resources.ApplyResources(this.n1, "n1");
            // 
            // text_box1
            // 
            this.text_box1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_box1.DefaultText = "";
            this.text_box1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.text_box1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.text_box1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.text_box1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.text_box1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.text_box1, "text_box1");
            this.text_box1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.text_box1.Name = "text_box1";
            this.text_box1.PasswordChar = '\0';
            this.text_box1.PlaceholderText = "";
            this.text_box1.SelectedText = "";
            this.text_box1.TextChanged += new System.EventHandler(this.text_box1_TextChanged_1);
            // 
            // Textbox2
            // 
            this.Textbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textbox2.DefaultText = "";
            this.Textbox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Textbox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Textbox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textbox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textbox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.Textbox2, "Textbox2");
            this.Textbox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Textbox2.Name = "Textbox2";
            this.Textbox2.PasswordChar = '\0';
            this.Textbox2.PlaceholderText = "";
            this.Textbox2.SelectedText = "";
            // 
            // help_button
            // 
            this.help_button.AllowDrop = true;
            this.help_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.help_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.help_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.help_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.help_button.FillColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.help_button, "help_button");
            this.help_button.ForeColor = System.Drawing.Color.White;
            this.help_button.HoverState.BorderColor = System.Drawing.Color.Black;
            this.help_button.HoverState.FillColor = System.Drawing.Color.Red;
            this.help_button.Image = ((System.Drawing.Image)(resources.GetObject("help_button.Image")));
            this.help_button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.help_button.ImageSize = new System.Drawing.Size(10, 10);
            this.help_button.Name = "help_button";
            this.help_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.AllowDrop = true;
            resources.ApplyResources(this.guna2ContextMenuStrip1, "guna2ContextMenuStrip1");
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.githubLinkToolStripMenuItem});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.guna2ContextMenuStrip1_Opening);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click_1);
            // 
            // githubLinkToolStripMenuItem
            // 
            this.githubLinkToolStripMenuItem.Name = "githubLinkToolStripMenuItem";
            resources.ApplyResources(this.githubLinkToolStripMenuItem, "githubLinkToolStripMenuItem");
            this.githubLinkToolStripMenuItem.Click += new System.EventHandler(this.githubLinkToolStripMenuItem_Click);
            // 
            // Bottom_elev
            // 
            this.Bottom_elev.AllowDrop = true;
            this.Bottom_elev.BackColor = System.Drawing.Color.Transparent;
            this.Bottom_elev.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.Bottom_elev, "Bottom_elev");
            this.Bottom_elev.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.Bottom_elev.Name = "Bottom_elev";
            this.Bottom_elev.Load += new System.EventHandler(this.Bottom_elev_Load);
            // 
            // Elevator_form
            // 
            this.AcceptButton = this.movingbt;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.Close;
            this.Controls.Add(this.Bottom_elev);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.Textbox2);
            this.Controls.Add(this.text_box1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elevation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.movingbt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Elevator_form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.Elevator_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elevation)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bottom_elev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        public System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2Button movingbt;
        public Guna.UI2.WinForms.Guna2Button Close;
        public Guna.UI2.WinForms.Guna2NumericUpDown elevation;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip n1;
        private Guna.UI2.WinForms.Guna2TextBox text_box1;
        private Guna.UI2.WinForms.Guna2TextBox Textbox2;
        private Guna.UI2.WinForms.Guna2Button help_button;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        public Guna.UI2.WinForms.Guna2NumericUpDown Bottom_elev;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubLinkToolStripMenuItem;
    }
}