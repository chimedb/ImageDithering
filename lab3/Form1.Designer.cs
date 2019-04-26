namespace lab3
{
    partial class Form1
    {
        /// <summary>
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
            this.original_picturebox = new System.Windows.Forms.PictureBox();
            this.dithering_picturebox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseAnAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedDitheringToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorDiffusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popularityAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kr_scrollbar = new System.Windows.Forms.HScrollBar();
            this.kg_scrollbar = new System.Windows.Forms.HScrollBar();
            this.kb_scrollbar = new System.Windows.Forms.HScrollBar();
            this.kr_label = new System.Windows.Forms.Label();
            this.kg_label = new System.Windows.Forms.Label();
            this.kb_label = new System.Windows.Forms.Label();
            this.k_scrollbar = new System.Windows.Forms.HScrollBar();
            this.k_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.original_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dithering_picturebox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // original_picturebox
            // 
            this.original_picturebox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.original_picturebox.Location = new System.Drawing.Point(12, 50);
            this.original_picturebox.Name = "original_picturebox";
            this.original_picturebox.Size = new System.Drawing.Size(386, 386);
            this.original_picturebox.TabIndex = 0;
            this.original_picturebox.TabStop = false;
            this.original_picturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.original_picturebox_Paint);
            // 
            // dithering_picturebox
            // 
            this.dithering_picturebox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dithering_picturebox.Location = new System.Drawing.Point(404, 50);
            this.dithering_picturebox.Name = "dithering_picturebox";
            this.dithering_picturebox.Size = new System.Drawing.Size(386, 386);
            this.dithering_picturebox.TabIndex = 1;
            this.dithering_picturebox.TabStop = false;
            this.dithering_picturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.dithering_picturebox_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.chooseAnAlgorithmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chooseAnAlgorithmToolStripMenuItem
            // 
            this.chooseAnAlgorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.averageDitheringToolStripMenuItem,
            this.orderedDitheringToolStripMenuItem,
            this.orderedDitheringToolStripMenuItem1,
            this.errorDiffusionToolStripMenuItem,
            this.popularityAlgorithmToolStripMenuItem});
            this.chooseAnAlgorithmToolStripMenuItem.Name = "chooseAnAlgorithmToolStripMenuItem";
            this.chooseAnAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.chooseAnAlgorithmToolStripMenuItem.Text = "Choose an algorithm";
            // 
            // averageDitheringToolStripMenuItem
            // 
            this.averageDitheringToolStripMenuItem.Name = "averageDitheringToolStripMenuItem";
            this.averageDitheringToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.averageDitheringToolStripMenuItem.Text = "Average Dithering";
            this.averageDitheringToolStripMenuItem.Click += new System.EventHandler(this.averageDitheringToolStripMenuItem_Click);
            // 
            // orderedDitheringToolStripMenuItem
            // 
            this.orderedDitheringToolStripMenuItem.Name = "orderedDitheringToolStripMenuItem";
            this.orderedDitheringToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.orderedDitheringToolStripMenuItem.Text = "Ordered Dithering (Random)";
            this.orderedDitheringToolStripMenuItem.Click += new System.EventHandler(this.orderedDitheringToolStripMenuItem_Click);
            // 
            // orderedDitheringToolStripMenuItem1
            // 
            this.orderedDitheringToolStripMenuItem1.Name = "orderedDitheringToolStripMenuItem1";
            this.orderedDitheringToolStripMenuItem1.Size = new System.Drawing.Size(242, 22);
            this.orderedDitheringToolStripMenuItem1.Text = "Ordered Dithering (On position)";
            this.orderedDitheringToolStripMenuItem1.Click += new System.EventHandler(this.orderedDitheringToolStripMenuItem1_Click);
            // 
            // errorDiffusionToolStripMenuItem
            // 
            this.errorDiffusionToolStripMenuItem.Name = "errorDiffusionToolStripMenuItem";
            this.errorDiffusionToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.errorDiffusionToolStripMenuItem.Text = "Error Diffusion";
            this.errorDiffusionToolStripMenuItem.Click += new System.EventHandler(this.errorDiffusionToolStripMenuItem_Click);
            // 
            // popularityAlgorithmToolStripMenuItem
            // 
            this.popularityAlgorithmToolStripMenuItem.Name = "popularityAlgorithmToolStripMenuItem";
            this.popularityAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.popularityAlgorithmToolStripMenuItem.Text = "Popularity Algorithm";
            this.popularityAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.popularityAlgorithmToolStripMenuItem_Click);
            // 
            // kr_scrollbar
            // 
            this.kr_scrollbar.Location = new System.Drawing.Point(311, 8);
            this.kr_scrollbar.Minimum = 2;
            this.kr_scrollbar.Name = "kr_scrollbar";
            this.kr_scrollbar.Size = new System.Drawing.Size(80, 17);
            this.kr_scrollbar.TabIndex = 3;
            this.kr_scrollbar.Value = 2;
            this.kr_scrollbar.Visible = false;
            this.kr_scrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.kr_scrollbar_Scroll);
            // 
            // kg_scrollbar
            // 
            this.kg_scrollbar.Location = new System.Drawing.Point(463, 7);
            this.kg_scrollbar.Minimum = 2;
            this.kg_scrollbar.Name = "kg_scrollbar";
            this.kg_scrollbar.Size = new System.Drawing.Size(80, 17);
            this.kg_scrollbar.TabIndex = 4;
            this.kg_scrollbar.Value = 2;
            this.kg_scrollbar.Visible = false;
            this.kg_scrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.kg_scrollbar_Scroll);
            // 
            // kb_scrollbar
            // 
            this.kb_scrollbar.Location = new System.Drawing.Point(607, 7);
            this.kb_scrollbar.Minimum = 2;
            this.kb_scrollbar.Name = "kb_scrollbar";
            this.kb_scrollbar.Size = new System.Drawing.Size(80, 17);
            this.kb_scrollbar.TabIndex = 5;
            this.kb_scrollbar.Value = 2;
            this.kb_scrollbar.Visible = false;
            this.kb_scrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.kb_scrollbar_Scroll);
            // 
            // kr_label
            // 
            this.kr_label.AutoSize = true;
            this.kr_label.Location = new System.Drawing.Point(400, 9);
            this.kr_label.Name = "kr_label";
            this.kr_label.Size = new System.Drawing.Size(32, 13);
            this.kr_label.TabIndex = 6;
            this.kr_label.Text = "Kr : 2";
            this.kr_label.Visible = false;
            // 
            // kg_label
            // 
            this.kg_label.AutoSize = true;
            this.kg_label.Location = new System.Drawing.Point(546, 9);
            this.kg_label.Name = "kg_label";
            this.kg_label.Size = new System.Drawing.Size(35, 13);
            this.kg_label.TabIndex = 7;
            this.kg_label.Text = "Kg : 2";
            this.kg_label.Visible = false;
            // 
            // kb_label
            // 
            this.kb_label.AutoSize = true;
            this.kb_label.Location = new System.Drawing.Point(690, 9);
            this.kb_label.Name = "kb_label";
            this.kb_label.Size = new System.Drawing.Size(35, 13);
            this.kb_label.TabIndex = 8;
            this.kb_label.Text = "Kb : 2";
            this.kb_label.Visible = false;
            // 
            // k_scrollbar
            // 
            this.k_scrollbar.Location = new System.Drawing.Point(264, 8);
            this.k_scrollbar.Maximum = 255;
            this.k_scrollbar.Minimum = 2;
            this.k_scrollbar.Name = "k_scrollbar";
            this.k_scrollbar.Size = new System.Drawing.Size(80, 17);
            this.k_scrollbar.TabIndex = 9;
            this.k_scrollbar.Value = 2;
            this.k_scrollbar.Visible = false;
            this.k_scrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.k_scrollbar_Scroll);
            // 
            // k_label
            // 
            this.k_label.AutoSize = true;
            this.k_label.Location = new System.Drawing.Point(346, 10);
            this.k_label.Name = "k_label";
            this.k_label.Size = new System.Drawing.Size(35, 13);
            this.k_label.TabIndex = 10;
            this.k_label.Text = "K : 40";
            this.k_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.k_label);
            this.Controls.Add(this.k_scrollbar);
            this.Controls.Add(this.kb_label);
            this.Controls.Add(this.kg_label);
            this.Controls.Add(this.kr_label);
            this.Controls.Add(this.kb_scrollbar);
            this.Controls.Add(this.kg_scrollbar);
            this.Controls.Add(this.kr_scrollbar);
            this.Controls.Add(this.dithering_picturebox);
            this.Controls.Add(this.original_picturebox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color reduction";
            ((System.ComponentModel.ISupportInitialize)(this.original_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dithering_picturebox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox original_picturebox;
        private System.Windows.Forms.PictureBox dithering_picturebox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseAnAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorDiffusionToolStripMenuItem;
        private System.Windows.Forms.HScrollBar kr_scrollbar;
        private System.Windows.Forms.HScrollBar kg_scrollbar;
        private System.Windows.Forms.HScrollBar kb_scrollbar;
        private System.Windows.Forms.Label kr_label;
        private System.Windows.Forms.Label kg_label;
        private System.Windows.Forms.Label kb_label;
        private System.Windows.Forms.ToolStripMenuItem popularityAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedDitheringToolStripMenuItem1;
        private System.Windows.Forms.HScrollBar k_scrollbar;
        private System.Windows.Forms.Label k_label;
    }
}

