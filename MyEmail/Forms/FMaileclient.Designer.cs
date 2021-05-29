
namespace MyEmail.Forms
{
    partial class FMaileclient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMaileclient));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButtonAvtorization = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButtonNewLetter = new System.Windows.Forms.ToolStripSplitButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxLetters = new System.Windows.Forms.ListBox();
            this.textBoxСontent = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Aqua;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButtonAvtorization,
            this.toolStripSplitButtonNewLetter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButtonAvtorization
            // 
            this.toolStripSplitButtonAvtorization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButtonAvtorization.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonAvtorization.Image")));
            this.toolStripSplitButtonAvtorization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonAvtorization.Name = "toolStripSplitButtonAvtorization";
            this.toolStripSplitButtonAvtorization.Size = new System.Drawing.Size(94, 20);
            this.toolStripSplitButtonAvtorization.Text = "Авторизация";
            this.toolStripSplitButtonAvtorization.Click += new System.EventHandler(this.toolStripSplitButtonAvtorization_Click);
            // 
            // toolStripSplitButtonNewLetter
            // 
            this.toolStripSplitButtonNewLetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButtonNewLetter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonNewLetter.Image")));
            this.toolStripSplitButtonNewLetter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonNewLetter.Name = "toolStripSplitButtonNewLetter";
            this.toolStripSplitButtonNewLetter.Size = new System.Drawing.Size(103, 20);
            this.toolStripSplitButtonNewLetter.Text = "Новое письмо";
            this.toolStripSplitButtonNewLetter.Click += new System.EventHandler(this.toolStripSplitButtonNewLetter_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 22);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxLetters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxСontent);
            this.splitContainer1.Size = new System.Drawing.Size(800, 580);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBoxLetters
            // 
            this.listBoxLetters.BackColor = System.Drawing.Color.Silver;
            this.listBoxLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLetters.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.listBoxLetters.ForeColor = System.Drawing.Color.Maroon;
            this.listBoxLetters.FormattingEnabled = true;
            this.listBoxLetters.ItemHeight = 20;
            this.listBoxLetters.Location = new System.Drawing.Point(0, 0);
            this.listBoxLetters.Name = "listBoxLetters";
            this.listBoxLetters.Size = new System.Drawing.Size(266, 580);
            this.listBoxLetters.TabIndex = 0;
            this.listBoxLetters.SelectedIndexChanged += new System.EventHandler(this.listBoxLetters_SelectedIndexChanged);
            // 
            // textBoxСontent
            // 
            this.textBoxСontent.BackColor = System.Drawing.Color.Gray;
            this.textBoxСontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxСontent.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBoxСontent.ForeColor = System.Drawing.Color.Blue;
            this.textBoxСontent.Location = new System.Drawing.Point(0, 0);
            this.textBoxСontent.Multiline = true;
            this.textBoxСontent.Name = "textBoxСontent";
            this.textBoxСontent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxСontent.Size = new System.Drawing.Size(530, 580);
            this.textBoxСontent.TabIndex = 0;
            // 
            // FMaileclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMaileclient";
            this.Text = "Почта";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonAvtorization;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonNewLetter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ListBox listBoxLetters;
        public System.Windows.Forms.TextBox textBoxСontent;
    }
}