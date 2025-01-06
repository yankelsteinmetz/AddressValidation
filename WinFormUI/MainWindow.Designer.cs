namespace WinFormUI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            SaveFile = new Button();
            uplaodFile = new Button();
            USPSlogo = new PictureBox();
            DataGrid = new DataGridView();
            instructions = new Label();
            template = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)USPSlogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // SaveFile
            // 
            SaveFile.BackColor = SystemColors.ButtonFace;
            SaveFile.FlatStyle = FlatStyle.Flat;
            SaveFile.Location = new Point(678, 406);
            SaveFile.Name = "SaveFile";
            SaveFile.Size = new Size(101, 32);
            SaveFile.TabIndex = 0;
            SaveFile.Text = "Save";
            SaveFile.UseVisualStyleBackColor = false;
            SaveFile.Visible = false;
            SaveFile.Click += SaveFile_Click;
            // 
            // uplaodFile
            // 
            uplaodFile.BackColor = SystemColors.ControlLight;
            uplaodFile.FlatStyle = FlatStyle.Flat;
            uplaodFile.ForeColor = SystemColors.ActiveCaptionText;
            uplaodFile.Location = new Point(25, 38);
            uplaodFile.Name = "uplaodFile";
            uplaodFile.Size = new Size(75, 25);
            uplaodFile.TabIndex = 1;
            uplaodFile.Text = "Upload";
            uplaodFile.UseVisualStyleBackColor = false;
            uplaodFile.Click += UplaodFile_Click;
            // 
            // USPSlogo
            // 
            USPSlogo.Image = (Image)resources.GetObject("USPSlogo.Image");
            USPSlogo.InitialImage = (Image)resources.GetObject("USPSlogo.InitialImage");
            USPSlogo.Location = new Point(718, 0);
            USPSlogo.Name = "USPSlogo";
            USPSlogo.Size = new Size(82, 75);
            USPSlogo.SizeMode = PictureBoxSizeMode.StretchImage;
            USPSlogo.TabIndex = 3;
            USPSlogo.TabStop = false;
            USPSlogo.Click += USPSlogo_Click;
            // 
            // DataGrid
            // 
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid.BackgroundColor = SystemColors.ControlLight;
            DataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGrid.GridColor = SystemColors.MenuBar;
            DataGrid.Location = new Point(25, 83);
            DataGrid.Name = "DataGrid";
            DataGrid.ReadOnly = true;
            DataGrid.Size = new Size(754, 304);
            DataGrid.TabIndex = 4;
            // 
            // instructions
            // 
            instructions.AutoSize = true;
            instructions.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructions.Location = new Point(164, 9);
            instructions.Name = "instructions";
            instructions.Size = new Size(380, 25);
            instructions.TabIndex = 5;
            instructions.Text = "Upload a CSV file with addresses to validate";
            // 
            // template
            // 
            template.AutoSize = true;
            template.Location = new Point(578, 19);
            template.Name = "template";
            template.Size = new Size(110, 15);
            template.TabIndex = 6;
            template.TabStop = true;
            template.Text = "download template";
            template.LinkClicked += template_LinkClicked;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(template);
            Controls.Add(instructions);
            Controls.Add(DataGrid);
            Controls.Add(USPSlogo);
            Controls.Add(uplaodFile);
            Controls.Add(SaveFile);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)USPSlogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveFile;
        private Button uplaodFile;
        private PictureBox USPSlogo;
        private DataGridView DataGrid;
        private Label instructions;
        private LinkLabel template;
    }
}
