
namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bClear = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bFont = new System.Windows.Forms.Button();
            this.bPaste = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bRorate = new System.Windows.Forms.Button();
            this.rRect = new System.Windows.Forms.RadioButton();
            this.rCopy = new System.Windows.Forms.RadioButton();
            this.rFill = new System.Windows.Forms.RadioButton();
            this.rErase = new System.Windows.Forms.RadioButton();
            this.rPipette = new System.Windows.Forms.RadioButton();
            this.rText = new System.Windows.Forms.RadioButton();
            this.rElips = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.rPen = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openParametricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1179, 534);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.bClear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.bFont);
            this.panel1.Controls.Add(this.bPaste);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.bRorate);
            this.panel1.Controls.Add(this.rRect);
            this.panel1.Controls.Add(this.rCopy);
            this.panel1.Controls.Add(this.rFill);
            this.panel1.Controls.Add(this.rErase);
            this.panel1.Controls.Add(this.rPipette);
            this.panel1.Controls.Add(this.rText);
            this.panel1.Controls.Add(this.rElips);
            this.panel1.Controls.Add(this.rLine);
            this.panel1.Controls.Add(this.rPen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 66);
            this.panel1.TabIndex = 1;
            // 
            // bClear
            // 
            this.bClear.ImageIndex = 6;
            this.bClear.ImageList = this.imageList1;
            this.bClear.Location = new System.Drawing.Point(180, 4);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(26, 26);
            this.bClear.TabIndex = 25;
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "line.png");
            this.imageList1.Images.SetKeyName(1, "Ellipse.png");
            this.imageList1.Images.SetKeyName(2, "text.png");
            this.imageList1.Images.SetKeyName(3, "font.png");
            this.imageList1.Images.SetKeyName(4, "pipette.png");
            this.imageList1.Images.SetKeyName(5, "eraser.png");
            this.imageList1.Images.SetKeyName(6, "clear.png");
            this.imageList1.Images.SetKeyName(7, "flood.png");
            this.imageList1.Images.SetKeyName(8, "copy.png");
            this.imageList1.Images.SetKeyName(9, "paste.png");
            this.imageList1.Images.SetKeyName(10, "load.png");
            this.imageList1.Images.SetKeyName(11, "parametric.png");
            this.imageList1.Images.SetKeyName(12, "square (2).png");
            this.imageList1.Images.SetKeyName(13, "pen.png");
            this.imageList1.Images.SetKeyName(14, "rotate.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(426, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Enter degree to scale";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(443, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 23;
            // 
            // bFont
            // 
            this.bFont.ImageIndex = 3;
            this.bFont.ImageList = this.imageList1;
            this.bFont.Location = new System.Drawing.Point(295, 4);
            this.bFont.Name = "bFont";
            this.bFont.Size = new System.Drawing.Size(26, 26);
            this.bFont.TabIndex = 22;
            this.bFont.UseVisualStyleBackColor = true;
            this.bFont.Click += new System.EventHandler(this.button2_Click);
            // 
            // bPaste
            // 
            this.bPaste.ImageIndex = 9;
            this.bPaste.ImageList = this.imageList1;
            this.bPaste.Location = new System.Drawing.Point(295, 37);
            this.bPaste.Name = "bPaste";
            this.bPaste.Size = new System.Drawing.Size(26, 26);
            this.bPaste.TabIndex = 21;
            this.bPaste.UseVisualStyleBackColor = true;
            this.bPaste.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(726, 16);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Solid ",
            "Clear"});
            this.comboBox2.Location = new System.Drawing.Point(789, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "DashDot",
            "DashDotDot"});
            this.comboBox1.Location = new System.Drawing.Point(789, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(670, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 41);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.DoubleClick += new System.EventHandler(this.pictureBox3_DoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(612, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 41);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            // 
            // bRorate
            // 
            this.bRorate.ImageKey = "rotate.png";
            this.bRorate.ImageList = this.imageList1;
            this.bRorate.Location = new System.Drawing.Point(461, 0);
            this.bRorate.Name = "bRorate";
            this.bRorate.Size = new System.Drawing.Size(37, 24);
            this.bRorate.TabIndex = 16;
            this.bRorate.UseVisualStyleBackColor = true;
            this.bRorate.Click += new System.EventHandler(this.bRorate_Click);
            // 
            // rRect
            // 
            this.rRect.Appearance = System.Windows.Forms.Appearance.Button;
            this.rRect.AutoSize = true;
            this.rRect.ImageIndex = 12;
            this.rRect.ImageList = this.imageList1;
            this.rRect.Location = new System.Drawing.Point(212, 35);
            this.rRect.Name = "rRect";
            this.rRect.Size = new System.Drawing.Size(26, 26);
            this.rRect.TabIndex = 13;
            this.rRect.TabStop = true;
            this.rRect.UseVisualStyleBackColor = true;
            // 
            // rCopy
            // 
            this.rCopy.Appearance = System.Windows.Forms.Appearance.Button;
            this.rCopy.AutoSize = true;
            this.rCopy.ImageIndex = 8;
            this.rCopy.ImageList = this.imageList1;
            this.rCopy.Location = new System.Drawing.Point(263, 35);
            this.rCopy.Name = "rCopy";
            this.rCopy.Size = new System.Drawing.Size(26, 26);
            this.rCopy.TabIndex = 9;
            this.rCopy.TabStop = true;
            this.rCopy.UseVisualStyleBackColor = true;
            // 
            // rFill
            // 
            this.rFill.Appearance = System.Windows.Forms.Appearance.Button;
            this.rFill.AutoSize = true;
            this.rFill.ImageIndex = 7;
            this.rFill.ImageList = this.imageList1;
            this.rFill.Location = new System.Drawing.Point(14, 35);
            this.rFill.Name = "rFill";
            this.rFill.Size = new System.Drawing.Size(26, 26);
            this.rFill.TabIndex = 8;
            this.rFill.TabStop = true;
            this.rFill.UseVisualStyleBackColor = true;
            // 
            // rErase
            // 
            this.rErase.Appearance = System.Windows.Forms.Appearance.Button;
            this.rErase.AutoSize = true;
            this.rErase.ImageIndex = 5;
            this.rErase.ImageList = this.imageList1;
            this.rErase.Location = new System.Drawing.Point(46, 35);
            this.rErase.Name = "rErase";
            this.rErase.Size = new System.Drawing.Size(26, 26);
            this.rErase.TabIndex = 6;
            this.rErase.TabStop = true;
            this.rErase.UseVisualStyleBackColor = true;
            // 
            // rPipette
            // 
            this.rPipette.Appearance = System.Windows.Forms.Appearance.Button;
            this.rPipette.AutoSize = true;
            this.rPipette.ImageIndex = 4;
            this.rPipette.ImageList = this.imageList1;
            this.rPipette.Location = new System.Drawing.Point(46, 3);
            this.rPipette.Name = "rPipette";
            this.rPipette.Size = new System.Drawing.Size(26, 26);
            this.rPipette.TabIndex = 5;
            this.rPipette.TabStop = true;
            this.rPipette.UseVisualStyleBackColor = true;
            // 
            // rText
            // 
            this.rText.Appearance = System.Windows.Forms.Appearance.Button;
            this.rText.AutoSize = true;
            this.rText.ImageIndex = 2;
            this.rText.ImageList = this.imageList1;
            this.rText.Location = new System.Drawing.Point(263, 3);
            this.rText.Name = "rText";
            this.rText.Size = new System.Drawing.Size(26, 26);
            this.rText.TabIndex = 3;
            this.rText.TabStop = true;
            this.rText.UseVisualStyleBackColor = true;
            // 
            // rElips
            // 
            this.rElips.Appearance = System.Windows.Forms.Appearance.Button;
            this.rElips.AutoSize = true;
            this.rElips.ImageIndex = 1;
            this.rElips.ImageList = this.imageList1;
            this.rElips.Location = new System.Drawing.Point(180, 35);
            this.rElips.Name = "rElips";
            this.rElips.Size = new System.Drawing.Size(26, 26);
            this.rElips.TabIndex = 2;
            this.rElips.TabStop = true;
            this.rElips.UseVisualStyleBackColor = true;
            // 
            // rLine
            // 
            this.rLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rLine.AutoSize = true;
            this.rLine.ImageIndex = 0;
            this.rLine.ImageList = this.imageList1;
            this.rLine.Location = new System.Drawing.Point(148, 35);
            this.rLine.Name = "rLine";
            this.rLine.Size = new System.Drawing.Size(26, 26);
            this.rLine.TabIndex = 1;
            this.rLine.TabStop = true;
            this.rLine.UseVisualStyleBackColor = true;
            // 
            // rPen
            // 
            this.rPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.rPen.AutoSize = true;
            this.rPen.ImageIndex = 13;
            this.rPen.ImageList = this.imageList1;
            this.rPen.Location = new System.Drawing.Point(14, 3);
            this.rPen.Name = "rPen";
            this.rPen.Size = new System.Drawing.Size(26, 26);
            this.rPen.TabIndex = 0;
            this.rPen.TabStop = true;
            this.rPen.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.unDoToolStripMenuItem,
            this.reDoToolStripMenuItem,
            this.openParametricToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.saveToolStripMenuItem.Text = "File";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open png";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pngToolStripMenuItem,
            this.parametricToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            this.pngToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.pngToolStripMenuItem.Text = "Png ";
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // parametricToolStripMenuItem
            // 
            this.parametricToolStripMenuItem.Name = "parametricToolStripMenuItem";
            this.parametricToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.parametricToolStripMenuItem.Text = "Parametric";
            this.parametricToolStripMenuItem.Click += new System.EventHandler(this.parametricToolStripMenuItem_Click);
            // 
            // unDoToolStripMenuItem
            // 
            this.unDoToolStripMenuItem.Name = "unDoToolStripMenuItem";
            this.unDoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.unDoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.unDoToolStripMenuItem.Text = "UnDo";
            this.unDoToolStripMenuItem.Click += new System.EventHandler(this.unDoToolStripMenuItem_Click);
            // 
            // reDoToolStripMenuItem
            // 
            this.reDoToolStripMenuItem.Name = "reDoToolStripMenuItem";
            this.reDoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.reDoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.reDoToolStripMenuItem.Text = "ReDo";
            this.reDoToolStripMenuItem.Click += new System.EventHandler(this.reDoToolStripMenuItem_Click);
            // 
            // openParametricToolStripMenuItem
            // 
            this.openParametricToolStripMenuItem.Name = "openParametricToolStripMenuItem";
            this.openParametricToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openParametricToolStripMenuItem.Text = "Open parametric";
            this.openParametricToolStripMenuItem.Click += new System.EventHandler(this.openParametricToolStripMenuItem_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Surface",
            "Border"});
            this.comboBox3.Location = new System.Drawing.Point(78, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(64, 21);
            this.comboBox3.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 624);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RadioButton rPen;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton rRect;
        private System.Windows.Forms.RadioButton rCopy;
        private System.Windows.Forms.RadioButton rFill;
        private System.Windows.Forms.RadioButton rErase;
        private System.Windows.Forms.RadioButton rPipette;
        private System.Windows.Forms.RadioButton rText;
        private System.Windows.Forms.RadioButton rElips;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.Button bRorate;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button bPaste;
        private System.Windows.Forms.Button bFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openParametricToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}

