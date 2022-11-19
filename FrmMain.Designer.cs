namespace jadedbrowser
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtBaseDir = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lstImages = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.AllowDrop = true;
            this.txtBaseDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBaseDir.Location = new System.Drawing.Point(0, 0);
            this.txtBaseDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.PlaceholderText = "Working Folder (drag and drop a folder here)";
            this.txtBaseDir.Size = new System.Drawing.Size(914, 27);
            this.txtBaseDir.TabIndex = 1;
            this.txtBaseDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.txtBaseDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.txtBaseDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseDir_KeyPress);
            // 
            // txtSearch
            // 
            this.txtSearch.AllowDrop = true;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search (find jpeg and png\'s with this in their name)";
            this.txtSearch.Size = new System.Drawing.Size(914, 27);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.txtSearch.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(128, 128);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRefresh.Location = new System.Drawing.Point(0, 54);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(914, 29);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lstImages
            // 
            this.lstImages.AllowDrop = true;
            this.lstImages.ContextMenuStrip = this.contextMenuStrip1;
            this.lstImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImages.LargeImageList = this.imageList1;
            this.lstImages.Location = new System.Drawing.Point(0, 83);
            this.lstImages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(914, 517);
            this.lstImages.TabIndex = 4;
            this.lstImages.UseCompatibleStateImageBehavior = false;
            this.lstImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.lstImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.lstImages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstImages_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 52);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.folderToolStripMenuItem.Text = "&Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.lstImages);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtBaseDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Jaded Browser";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBaseDir;
        private TextBox txtSearch;
        private ImageList imageList1;
        private Button cmdRefresh;
        private ListView lstImages;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem folderToolStripMenuItem;
        private ToolStripMenuItem mnuOpen;
        private ToolStripMenuItem mnuFolder;
    }
}