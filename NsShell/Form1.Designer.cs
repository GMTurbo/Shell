namespace NsShell
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_launch3DI = new System.Windows.Forms.Button();
            this.m_launchMPF = new System.Windows.Forms.Button();
            this.m_LaunchPLC = new System.Windows.Forms.Button();
            this.MoldListView = new System.Windows.Forms.ListView();
            this.listLoading = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Program = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pathname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locateOnDiskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openSailDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.openSailDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeLoading = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addW4lDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.locateOnDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.expandTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeSearchTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setExePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.m_statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.process1 = new System.Diagnostics.Process();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLoading)).BeginInit();
            this.listViewContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeLoading)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeLoading);
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.treeSearchTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(984, 529);
            this.splitContainer1.SplitterDistance = 741;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.MoldListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listLoading);
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Size = new System.Drawing.Size(741, 529);
            this.splitContainer2.SplitterDistance = 224;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_launch3DI);
            this.groupBox1.Controls.Add(this.m_launchMPF);
            this.groupBox1.Controls.Add(this.m_LaunchPLC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(573, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 218);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NS File Generator Launcher";
            // 
            // m_launch3DI
            // 
            this.m_launch3DI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_launch3DI.AutoSize = true;
            this.m_launch3DI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_launch3DI.Location = new System.Drawing.Point(9, 146);
            this.m_launch3DI.Name = "m_launch3DI";
            this.m_launch3DI.Size = new System.Drawing.Size(150, 59);
            this.m_launch3DI.TabIndex = 4;
            this.m_launch3DI.Text = "3DI Viewer";
            this.m_launch3DI.UseVisualStyleBackColor = true;
            this.m_launch3DI.Click += new System.EventHandler(this.m_launch3DI_Click);
            // 
            // m_launchMPF
            // 
            this.m_launchMPF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_launchMPF.AutoSize = true;
            this.m_launchMPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_launchMPF.Location = new System.Drawing.Point(9, 81);
            this.m_launchMPF.Name = "m_launchMPF";
            this.m_launchMPF.Size = new System.Drawing.Size(150, 59);
            this.m_launchMPF.TabIndex = 3;
            this.m_launchMPF.Text = "MPF File Generator";
            this.m_launchMPF.UseVisualStyleBackColor = true;
            this.m_launchMPF.Click += new System.EventHandler(this.m_launchMPF_Click);
            // 
            // m_LaunchPLC
            // 
            this.m_LaunchPLC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LaunchPLC.AutoSize = true;
            this.m_LaunchPLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LaunchPLC.Location = new System.Drawing.Point(9, 19);
            this.m_LaunchPLC.Name = "m_LaunchPLC";
            this.m_LaunchPLC.Size = new System.Drawing.Size(150, 56);
            this.m_LaunchPLC.TabIndex = 2;
            this.m_LaunchPLC.Text = "PLC File Generator";
            this.m_LaunchPLC.UseVisualStyleBackColor = true;
            this.m_LaunchPLC.Click += new System.EventHandler(this.m_LaunchPLC_Click);
            // 
            // MoldListView
            // 
            this.MoldListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoldListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.MoldListView.ForeColor = System.Drawing.Color.White;
            this.MoldListView.Location = new System.Drawing.Point(0, 0);
            this.MoldListView.MultiSelect = false;
            this.MoldListView.Name = "MoldListView";
            this.MoldListView.Size = new System.Drawing.Size(567, 221);
            this.MoldListView.TabIndex = 0;
            this.MoldListView.UseCompatibleStateImageBehavior = false;
            this.MoldListView.SelectedIndexChanged += new System.EventHandler(this.MoldListView_SelectedIndexChanged);
            this.MoldListView.DoubleClick += new System.EventHandler(this.MoldListView_DoubleClick);
            // 
            // listLoading
            // 
            this.listLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLoading.Image = global::NsShell.Properties.Resources.loading;
            this.listLoading.Location = new System.Drawing.Point(0, 0);
            this.listLoading.Name = "listLoading";
            this.listLoading.Size = new System.Drawing.Size(741, 301);
            this.listLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.listLoading.TabIndex = 2;
            this.listLoading.TabStop = false;
            this.listLoading.DoubleClick += new System.EventHandler(this.listLoading_DoubleClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Type,
            this.Size,
            this.Modified,
            this.Program,
            this.Pathname});
            this.listView1.ContextMenuStrip = this.listViewContext;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(741, 301);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 145;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // Size
            // 
            this.Size.Text = "Size";
            // 
            // Modified
            // 
            this.Modified.Text = "Modified";
            this.Modified.Width = 155;
            // 
            // Program
            // 
            this.Program.Text = "Program";
            this.Program.Width = 100;
            // 
            // Pathname
            // 
            this.Pathname.Text = "Pathname";
            this.Pathname.Width = 220;
            // 
            // listViewContext
            // 
            this.listViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.locateOnDiskToolStripMenuItem1,
            this.openSailDirectoryToolStripMenuItem,
            this.openSailDirectoryToolStripMenuItem1});
            this.listViewContext.Name = "listViewContext";
            this.listViewContext.Size = new System.Drawing.Size(176, 76);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::NsShell.Properties.Resources.folder_stroke_16x16;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // locateOnDiskToolStripMenuItem1
            // 
            this.locateOnDiskToolStripMenuItem1.Image = global::NsShell.Properties.Resources.eye_12x9;
            this.locateOnDiskToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.locateOnDiskToolStripMenuItem1.Name = "locateOnDiskToolStripMenuItem1";
            this.locateOnDiskToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.locateOnDiskToolStripMenuItem1.Text = "Locate On Disk";
            this.locateOnDiskToolStripMenuItem1.Click += new System.EventHandler(this.locateOnDiskToolStripMenuItem1_Click);
            // 
            // openSailDirectoryToolStripMenuItem
            // 
            this.openSailDirectoryToolStripMenuItem.Name = "openSailDirectoryToolStripMenuItem";
            this.openSailDirectoryToolStripMenuItem.Size = new System.Drawing.Size(172, 6);
            // 
            // openSailDirectoryToolStripMenuItem1
            // 
            this.openSailDirectoryToolStripMenuItem1.Image = global::NsShell.Properties.Resources.aperture_16x16;
            this.openSailDirectoryToolStripMenuItem1.Name = "openSailDirectoryToolStripMenuItem1";
            this.openSailDirectoryToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.openSailDirectoryToolStripMenuItem1.Text = "Open Sail Directory";
            this.openSailDirectoryToolStripMenuItem1.Click += new System.EventHandler(this.openSailDirectoryToolStripMenuItem1_Click);
            // 
            // treeLoading
            // 
            this.treeLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLoading.BackColor = System.Drawing.Color.Transparent;
            this.treeLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.treeLoading.Image = global::NsShell.Properties.Resources.loading;
            this.treeLoading.Location = new System.Drawing.Point(0, 0);
            this.treeLoading.Name = "treeLoading";
            this.treeLoading.Size = new System.Drawing.Size(239, 529);
            this.treeLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.treeLoading.TabIndex = 1;
            this.treeLoading.TabStop = false;
            //this.treeLoading.Click += new System.EventHandler(this.treeLoading_Click);
            this.treeLoading.DoubleClick += new System.EventHandler(this.treeLoading_DoubleClick);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(0, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(239, 500);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addW4lDirectoryToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripSeparator3,
            this.locateOnDiskToolStripMenuItem,
            this.toolStripSeparator4,
            this.expandTreeToolStripMenuItem,
            this.collapseAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 126);
            // 
            // addW4lDirectoryToolStripMenuItem
            // 
            this.addW4lDirectoryToolStripMenuItem.Image = global::NsShell.Properties.Resources.list_nested_24x21;
            this.addW4lDirectoryToolStripMenuItem.Name = "addW4lDirectoryToolStripMenuItem";
            this.addW4lDirectoryToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addW4lDirectoryToolStripMenuItem.Text = "Add w4l Directory";
            this.addW4lDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addW4lDirectoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::NsShell.Properties.Resources.x_21x21;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem5.Text = "Delete Node";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // locateOnDiskToolStripMenuItem
            // 
            this.locateOnDiskToolStripMenuItem.Image = global::NsShell.Properties.Resources.eye_12x9;
            this.locateOnDiskToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.locateOnDiskToolStripMenuItem.Name = "locateOnDiskToolStripMenuItem";
            this.locateOnDiskToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.locateOnDiskToolStripMenuItem.Text = "Locate On Disk";
            this.locateOnDiskToolStripMenuItem.Click += new System.EventHandler(this.locateOnDiskToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // expandTreeToolStripMenuItem
            // 
            this.expandTreeToolStripMenuItem.Image = global::NsShell.Properties.Resources.list_nested_16x14;
            this.expandTreeToolStripMenuItem.Name = "expandTreeToolStripMenuItem";
            this.expandTreeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.expandTreeToolStripMenuItem.Text = "Expand All";
            this.expandTreeToolStripMenuItem.Click += new System.EventHandler(this.expandTreeToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Image = global::NsShell.Properties.Resources.list_16x14;
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NsShell.Properties.Resources.search1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // treeSearchTextBox
            // 
            this.treeSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSearchTextBox.Location = new System.Drawing.Point(3, 3);
            this.treeSearchTextBox.Multiline = true;
            this.treeSearchTextBox.Name = "treeSearchTextBox";
            this.treeSearchTextBox.Size = new System.Drawing.Size(233, 25);
            this.treeSearchTextBox.TabIndex = 2;
            this.treeSearchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.treeSearchTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.setExePathsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newToolStripMenuItem.Text = "&New Design";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openToolStripMenuItem.Text = "&Open Design";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            this.recentToolStripMenuItem.MouseEnter += new System.EventHandler(this.recentToolStripMenuItem_MouseEnter);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(182, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // setExePathsToolStripMenuItem
            // 
            this.setExePathsToolStripMenuItem.Name = "setExePathsToolStripMenuItem";
            this.setExePathsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.setExePathsToolStripMenuItem.Text = "&Set Exe Paths";
            this.setExePathsToolStripMenuItem.Click += new System.EventHandler(this.setExePathsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_statusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 553);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // m_statusText
            // 
            this.m_statusText.Name = "m_statusText";
            this.m_statusText.Size = new System.Drawing.Size(0, 17);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 575);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 613);
            this.Name = "Form1";
            this.Text = "NsShell";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLoading)).EndInit();
            this.listViewContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeLoading)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.SplitContainer splitContainer1;
          private System.Windows.Forms.SplitContainer splitContainer2;
          private System.Windows.Forms.ListView listView1;
          private System.Windows.Forms.TreeView treeView1;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
          private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
          private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
          private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
          private System.Windows.Forms.StatusStrip statusStrip1;
          private System.Windows.Forms.ToolStripStatusLabel m_statusText;
          private System.Diagnostics.Process process1;
          private System.Windows.Forms.ColumnHeader Title;
          private System.Windows.Forms.ColumnHeader Type;
          private System.Windows.Forms.ColumnHeader Modified;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
          private System.Windows.Forms.ToolTip toolTip1;
          private System.Windows.Forms.ColumnHeader Size;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
          private System.Windows.Forms.ListView MoldListView;
          private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
          private System.Windows.Forms.ToolStripMenuItem addW4lDirectoryToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
          private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
          private System.Windows.Forms.PictureBox treeLoading;
          private System.Windows.Forms.PictureBox listLoading;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
          private System.Windows.Forms.ToolStripMenuItem locateOnDiskToolStripMenuItem;
          private System.Windows.Forms.ContextMenuStrip listViewContext;
          private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem locateOnDiskToolStripMenuItem1;
          private System.Windows.Forms.ToolStripMenuItem expandTreeToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
          private System.Windows.Forms.ToolStripSeparator openSailDirectoryToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem openSailDirectoryToolStripMenuItem1;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Button m_LaunchPLC;
          private System.Windows.Forms.Button m_launch3DI;
          private System.Windows.Forms.Button m_launchMPF;
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.TextBox treeSearchTextBox;
          private System.Windows.Forms.ToolStripMenuItem setExePathsToolStripMenuItem;
          private System.Windows.Forms.ColumnHeader Program;
          private System.Windows.Forms.ColumnHeader Pathname;
          private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
     }
}

