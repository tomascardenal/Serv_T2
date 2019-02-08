namespace E1_Files
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txbDir = new System.Windows.Forms.TextBox();
            this.lbWdir = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDirectories = new System.Windows.Forms.ListBox();
            this.lbFiles = new System.Windows.Forms.Label();
            this.lbDir = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbDir
            // 
            this.txbDir.Location = new System.Drawing.Point(128, 22);
            this.txbDir.Name = "txbDir";
            this.txbDir.Size = new System.Drawing.Size(249, 20);
            this.txbDir.TabIndex = 0;
            // 
            // lbWdir
            // 
            this.lbWdir.AutoSize = true;
            this.lbWdir.Location = new System.Drawing.Point(18, 26);
            this.lbWdir.Name = "lbWdir";
            this.lbWdir.Size = new System.Drawing.Size(93, 13);
            this.lbWdir.TabIndex = 1;
            this.lbWdir.Text = "Working directory:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(394, 21);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // listFiles
            // 
            this.listFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(31, 87);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(182, 199);
            this.listFiles.TabIndex = 3;
            this.listFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "View/Open";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // listDirectories
            // 
            this.listDirectories.ContextMenuStrip = this.contextMenuStrip1;
            this.listDirectories.FormattingEnabled = true;
            this.listDirectories.Location = new System.Drawing.Point(274, 87);
            this.listDirectories.Name = "listDirectories";
            this.listDirectories.Size = new System.Drawing.Size(182, 199);
            this.listDirectories.TabIndex = 4;
            this.listDirectories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listDirectories_MouseDoubleClick);
            // 
            // lbFiles
            // 
            this.lbFiles.AutoSize = true;
            this.lbFiles.Location = new System.Drawing.Point(108, 64);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(28, 13);
            this.lbFiles.TabIndex = 5;
            this.lbFiles.Text = "Files";
            // 
            // lbDir
            // 
            this.lbDir.AutoSize = true;
            this.lbDir.Location = new System.Drawing.Point(337, 64);
            this.lbDir.Name = "lbDir";
            this.lbDir.Size = new System.Drawing.Size(57, 13);
            this.lbDir.TabIndex = 6;
            this.lbDir.Text = "Directories";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 316);
            this.Controls.Add(this.lbDir);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.listDirectories);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lbWdir);
            this.Controls.Add(this.txbDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Files-E1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDir;
        private System.Windows.Forms.Label lbWdir;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.ListBox listDirectories;
        private System.Windows.Forms.Label lbFiles;
        private System.Windows.Forms.Label lbDir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}

