using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace NsShell
{
    public partial class Form1 : Form
    {
        public string Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        #region Icon Stuff
        // Constants that we need in the function call
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;

        // This structure will contain information about the file
        public struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        // The signature of SHGetFileInfo (located in Shell32.dll)
        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

        #endregion Icon Stuff

        #region INI File stuff

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName);

        #endregion INI File stuff

        #region Members

        private delegate void status(string message);
        status statSetter;

        bool toggle1 = false;
        bool toggle2 = false;

        BackgroundWorker workerTree = new BackgroundWorker();
        BackgroundWorker workerList = new BackgroundWorker();
        BackgroundWorker directoryWorker = new BackgroundWorker();

        exePathSetter PathSetter = new exePathSetter();

        private delegate object threadWorker(object data);
        threadWorker doWorkOnMe;
        threadWorker doMeToo;

        string SelectedMold = "";
        List<string> molds = new List<string>() { "Mold 100", "Mold 104", "Mold 105", "Mold 107", "Mold 108", "Mold 109", "Mold 110", "Mold 111", "Mold 112", "Mold 113", "Mold 114", "Mold 116" };

        string SailFileDirectory = null;

        List<FileInfo> CurrentFiles = new List<FileInfo>();

        #endregion Members

        #region Properties

        public string LayoutExeFullPath
        {
            get { return PathSetter.LayoutExeFullPath; }
        }

        public string LayoutIniFullPath
        {
            get { return PathSetter.LayoutIniFullPath; }
        }

        public string NhtgenExeFullPath
        {
            get { return PathSetter.NhtgenExeFullPath; }
        }

        public string NsfgExeFullPath
        {
            get { return PathSetter.NsfgExeFullPath; }
        }

        FileInfo SailFile
        {
            get { return CurrentFiles.Find((file) => { return file.Extension.ToLower() == ".sail"; }); }
        }

        FileInfo CofFile
        {
            get { return CurrentFiles.Find((file) => { return file.Extension.ToLower() == ".cof"; }); }
        }

        FileInfo _3DIfile
        {
            get { return CurrentFiles.Find((file) => { return file.Extension.ToLower() == ".3di"; }); }
        }

        FileInfo NHTFile
        {
            get { return CurrentFiles.Find((file) => { return file.Extension.ToLower() == ".nht"; }); }
        }

        public string Status
        {
            get { return m_statusText.Text; }
            set { statSetter(value); }
        }

        #endregion Properties

        public Form1()
        {
            InitializeComponent();

            statSetter = ((message) => { m_statusText.Text = message; });
            ToggleTreeLoadIcon(false);
            ToggleListLoadIcon(false);

            SetupWorker();

            LoadMoldListView();
        }

        #region Thread Stuff

        private void SetupWorker()
        {
            #region Tree Worker

            workerTree.DoWork += new DoWorkEventHandler(workerTree_DoWork);
            workerTree.ProgressChanged += new ProgressChangedEventHandler(workerTree_ProgressChanged);
            workerTree.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerTree_RunWorkerCompleted);

            #endregion

            #region List Worker
            workerList.DoWork += new DoWorkEventHandler(workerList_DoWork);
            workerList.ProgressChanged += new ProgressChangedEventHandler(workerList_ProgressChanged);
            workerList.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerList_RunWorkerCompleted);
            #endregion

            #region Diretory Worker

            directoryWorker.DoWork += new DoWorkEventHandler(directoryWorker_DoWork);
            directoryWorker.ProgressChanged += new ProgressChangedEventHandler(directoryWorker_ProgressChanged);
            directoryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(directoryWorker_RunWorkerCompleted);

            #endregion
        }

        void directoryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                if (SailFileDirectory != null)
                {
                    Status = "Updating Files...";
                    ToggleListLoadIcon(true);
                    doMeToo = LoadItemsToListView;
                    while (workerList.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }
                    List<string> files = Directory.GetFiles(SailFileDirectory).ToList();
                    List<FileInfo> fullfiles = new List<FileInfo>(files.Count);
                    files.ForEach((file) => { fullfiles.Add(new FileInfo(file)); });
                    workerList.RunWorkerAsync(fullfiles);
                }
            }
        }

        void directoryWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        void directoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = Directory.GetFiles(SailFileDirectory).ToList();
            e.Result = files.Count != CurrentFiles.Count;
        }

        void workerList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] ret = (object[])e.Result;
            List<ListViewItem> items = (List<ListViewItem>)ret[0];
            listView1.Items.Clear();
            if (listView1.SmallImageList != null)
                listView1.SmallImageList.Images.Clear();
            items.ForEach((item) => { listView1.Items.Add(item); });
            listView1.SmallImageList = (ImageList)ret[1];
            listView1.Update();
            listView1.Refresh();
            workerList.Dispose();
            GC.Collect();
            ToggleListLoadIcon(false);
            Status = "";
        }

        void workerList_ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        void workerList_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = doMeToo((object)e.Argument);
        }

        void workerTree_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                ToggleTreeLoadIcon(false);
                return;
            }

            treeView1.BeginUpdate();
            object[] ret = (object[])e.Result;
            foreach (TreeNode node in (ret[0] as TreeView).Nodes)
                treeView1.Nodes.Add((TreeNode)node.Clone());

            foreach (TreeNode node in treeView1.Nodes)
                FullTree.Nodes.Add((TreeNode)node.Clone());

            treeView1.ImageList = (ImageList)ret[1];
            treeView1.Update();
            workerTree.Dispose();
            treeView1.ExpandAll();
            treeView1.TopNode = treeView1.Nodes[0];
            treeView1.TopNode.EnsureVisible();
            treeView1.EndUpdate();
            ToggleTreeLoadIcon(false);
        }

        void workerTree_ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        void workerTree_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = doWorkOnMe((object)e.Argument);
        }

        #endregion Thread Stuff

        #region Misc Functions

        private object LoadItemsToListView(object filesToLoadobj)
        {
            // Will store a handle to the small icon
            IntPtr hImgSmall;

            SHFILEINFO shinfo = new SHFILEINFO();

            List<FileInfo> filesToLoad = (List<FileInfo>)filesToLoadobj;
            if (filesToLoad == null)
                return null;
            SailFileDirectory = Path.GetDirectoryName(filesToLoad[0].FullName);
            List<ListViewItem> ret = new List<ListViewItem>();
            CurrentFiles = filesToLoad;
            int count = 0;
            ImageList small = new ImageList();
            //ImageList large = new ImageList();
            small.ImageSize = new System.Drawing.Size(16, 16);
            //large.ImageSize = new System.Drawing.Size(64, 64);

            CurrentFiles.ForEach((ico) =>
            {
                try
                {
                    // Get a handle to the small icon
                    hImgSmall = SHGetFileInfo(ico.FullName, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                    // Get the small icon from the handle
                    Icon newIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                    small.Images.Add(newIcon);
                }
                catch { }
                //large.Images.Add(newIcon);
            });

            ListViewItem item;
            CurrentFiles.ForEach((file) =>
            {
                item = new ListViewItem(new string[] { file.Name, file.Extension.ToUpper(), FormatByteSize(file), File.GetLastWriteTime(file.FullName).ToShortDateString() + " " 
                    + File.GetLastWriteTime(file.FullName).ToShortTimeString(), GetProgramType(file.Extension), @file.FullName }, count++);
                ret.Add(item);
            });

            return new object[] { ret, small };
        }

        private string GetProgramType(string ext)
        {
            string Layout = "3DLayout";
            string PLC = "PLC File Generator";
            string MPF = "MPF File Generator";
            string NHT = "NHT Gen";
            string viewer = "3DI Viewer";

            switch (ext.ToLower())
            {
                case ".nht":
                    return NHT;
                case ".nhtsf":
                    return NHT;
                case ".xref":
                    return NHT;
                case ".sail":
                    return NHT;
                case ".cof":
                    return Layout;
                case ".ref":
                    return NHT;
                case ".3dl":
                    return Layout;
                case ".3dld":
                    return PLC;
                case ".plc":
                    return PLC;
                case ".plcv":
                    return PLC;
                case ".mpf":
                    return viewer;
                case ".3di":
                    return MPF;
                case ".w4l":
                    return Layout;
                case ".w4a":
                    return Layout;
                case ".3dlthkav":
                    return PLC;
                case ".3dlthkmax":
                    return PLC;
                case ".3dlthkmean":
                    return PLC;
                default:
                    return "Misc";
            }
        }

        private void LoadMoldListView()
        {
            MoldListView.Items.Clear();
            int count = 0;
            ImageList large = new ImageList();
            large.ImageSize = new System.Drawing.Size(75, 128);
            Image newIcon = NsShell.Properties.Resources.mold100;
            molds.ForEach((ico) =>
            {
                large.Images.Add(newIcon);
            });

            MoldListView.LargeImageList = large;
            ListViewItem item;
            molds.ForEach((file) =>
            {
                item = new ListViewItem(new string[] { file }, count++);
                item.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold);
                MoldListView.Items.Add(item);
            });
        }

        void ToggleTreeLoadIcon(bool loading)
        {
            treeLoading.Enabled = loading;
            treeLoading.Visible = loading;
            if (loading)
                treeLoading.BringToFront();
            else
            {
                toggle2 = true;
                treeLoading.Image = NsShell.Properties.Resources.loading;
                treeLoading.SendToBack();
            }
        }

        void ToggleListLoadIcon(bool loading)
        {
            listLoading.Enabled = loading;
            listLoading.Visible = loading;
            if (loading)
                listLoading.BringToFront();
            else
            {
                toggle1 = true;
                listLoading.Image = NsShell.Properties.Resources.loading;
                listLoading.SendToBack();
            }
        }

        private void ModifyLayoutIni(string cofFileName)
        {
            WriteINI("Application File List", "Cof", cofFileName, @LayoutIniFullPath);
        }

        private void ModifyLayoutIni(string cofFileName, string layoutIniFile)
        {
            WriteINI("Application File List", "Cof", cofFileName, @layoutIniFile);
        }

        bool WriteINI(string SectionName, string KeyName, string StringToWrite, string INIFileName)
        {
            bool Return;
            Return = WritePrivateProfileString(SectionName,
                               KeyName,
                               StringToWrite,
                               INIFileName);
            return Return;
        }

        #endregion Misc Functions

        #region File Size Methods & Enums

        public enum FileSizeUnit : byte
        {
            B,
            KB,
            MB,
            GB,
            TB,
            PB,
            EB,
            ZB,
            YB
        };

        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes,
        /// kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileSize">The numeric value to be converted.</param>
        /// <returns>The converted string.</returns>
        public string FormatByteSize(double fileSize)
        {
            FileSizeUnit unit = FileSizeUnit.B;
            while (fileSize >= 1024 && unit < FileSizeUnit.YB)
            {
                fileSize = fileSize / 1024;
                unit++;
            }
            return string.Format("{0:0.#} {1}", fileSize, unit);
        }

        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes,
        /// kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns>The converted string.</returns>
        public string FormatByteSize(FileInfo fileInfo)
        {
            return FormatByteSize(fileInfo.Length);
        }

        #endregion File Size Methods & Enums

        #region Sorting Methods

        List<bool> ascending = new List<bool>(5) { false, false, false, false, false };

        private void SortSizes()
        {
            ascending[2] = !ascending[2];
            long[] sizes = new long[CurrentFiles.Count];
            for (int i = 0; i < CurrentFiles.Count; i++)
                sizes[i] = CurrentFiles[i].Length;

            FileInfo[] tmpFiles = CurrentFiles.ToArray();

            Array.Sort(sizes, tmpFiles);
            if (!ascending[2])
            {
                List<FileInfo> tmpper = new List<FileInfo>(tmpFiles.ToList());
                tmpper.Reverse();
                tmpFiles = tmpper.ToArray();
            }
            RefreshView(new List<FileInfo>(tmpFiles.ToList()));
        }

        private void SortTimeStamps()
        {
            ascending[3] = !ascending[3];
            DateTime[] lastwriteTimes = new DateTime[CurrentFiles.Count];
            for (int i = 0; i < CurrentFiles.Count; i++)
                lastwriteTimes[i] = CurrentFiles[i].LastWriteTime;

            FileInfo[] tmpFiles = CurrentFiles.ToArray();

            Array.Sort(lastwriteTimes, tmpFiles);
            if (!ascending[3])
            {
                List<FileInfo> tmpper = new List<FileInfo>(tmpFiles.ToList());
                tmpper.Reverse();
                tmpFiles = tmpper.ToArray();
            }

            RefreshView(new List<FileInfo>(tmpFiles.ToList()));

        }

        private void SortTypes()
        {
            ascending[1] = !ascending[1];
            string[] exts = new string[CurrentFiles.Count];
            for (int i = 0; i < CurrentFiles.Count; i++)
                exts[i] = CurrentFiles[i].Extension;
            FileInfo[] tmpFiles = CurrentFiles.ToArray();

            Array.Sort(exts, tmpFiles);
            if (!ascending[1])
            {
                List<FileInfo> tmpper = new List<FileInfo>(tmpFiles.ToList());
                tmpper.Reverse();
                tmpFiles = tmpper.ToArray();
            }
            RefreshView(new List<FileInfo>(tmpFiles.ToList()));
        }

        private void SortTitles()
        {
            ascending[0] = !ascending[0];
            string[] names = new string[CurrentFiles.Count];
            for (int i = 0; i < CurrentFiles.Count; i++)
                names[i] = CurrentFiles[i].Name;

            FileInfo[] tmpFiles = CurrentFiles.ToArray();

            Array.Sort(names, tmpFiles);
            if (!ascending[0])
            {
                List<FileInfo> tmpper = new List<FileInfo>(tmpFiles.ToList());
                tmpper.Reverse();
                tmpFiles = tmpper.ToArray();
            }
            RefreshView(new List<FileInfo>(tmpFiles.ToList()));
        }

        private void SortPrograms()
        {
            ascending[4] = !ascending[4];
            string[] names = new string[CurrentFiles.Count];
            for (int i = 0; i < CurrentFiles.Count; i++)
                names[i] = GetProgramType(CurrentFiles[i].Extension);

            FileInfo[] tmpFiles = CurrentFiles.ToArray();

            Array.Sort(names, tmpFiles);
            if (!ascending[4])
            {
                List<FileInfo> tmpper = new List<FileInfo>(tmpFiles.ToList());
                tmpper.Reverse();
                tmpFiles = tmpper.ToArray();
            }
            RefreshView(new List<FileInfo>(tmpFiles.ToList()));
        }

        private void RefreshView(List<FileInfo> list)
        {
            ToggleListLoadIcon(true);
            doMeToo = LoadItemsToListView;
            while (workerList.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }
            workerList.RunWorkerAsync(list);
        }

        #endregion Sorting Methods

        #region Tree Code

        private void addW4lDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeChanged = true;
                ToggleTreeLoadIcon(true);
                while (workerTree.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }

                doWorkOnMe = AddToTree;
                workerTree.RunWorkerAsync(fbd.SelectedPath);
            }
        }

        private object AddToTree(object pathString)
        {
            return ListDirectory((string)pathString);
        }

        private object LoadTree(object loadFilePath)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = string.Format("{0}\\tree.nss", path);
            TreeView tree = new TreeView();
            if (!File.Exists(path))
                return null;
            LoadAndSave.loadTree(tree, path);

            return new object[] { tree, tree.ImageList };
        }

        private object ListDirectory(string path)
        {
            TreeView tree = new TreeView();
            var rootDirectoryInfo = new DirectoryInfo(path);
            ImageList images = new ImageList();
            int count = 0;
            tree.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo, ref images, ref count));
            tree.ImageList = images;
            return new object[] { tree, images };
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo, ref ImageList images, ref int count)
        {
            Bitmap folder = NsShell.Properties.Resources.folder_fill_24x24;
            images.Images.Add(folder);
            var directoryNode = new TreeNode(directoryInfo.Name, count, count++);
            directoryNode.Tag = @directoryInfo.FullName;
            directoryNode.Name = "Folder";
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                    directoryNode.Nodes.Add(CreateDirectoryNode(directory, ref images, ref count));
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                if (Path.GetExtension(file.Name).ToLower() == ".w4l")
                {
                    Bitmap newIcon = NsShell.Properties.Resources.w4lLogo;
                    images.Images.Add(newIcon);
                    TreeNode node = new TreeNode(file.Name, count, count++);
                    node.Tag = @file.FullName;
                    node.Name = "File";
                    directoryNode.Nodes.Add(node);
                }
            }
            return directoryNode;
        }

        private TreeNode RecursivelyAddNodes(TreeNode Parent)
        {
            var directoryNode = new TreeNode(Parent.Text, Parent.ImageIndex, Parent.SelectedImageIndex);
            directoryNode.Tag = Parent.Tag;
            directoryNode.Name = Parent.Name;
            foreach (TreeNode Node in Parent.Nodes)
                directoryNode.Nodes.Add(RecursivelyAddNodes(Node));
            return directoryNode;
        }

        private void RemoveDirectoryNode(TreeNode selected, ref TreeView tree)
        {
            if (selected != null)
            {
                foreach (TreeNode child in selected.Nodes)
                    RemoveDirectoryNode(child, ref tree);
                tree.Nodes.Remove(selected);
                if (tree.ImageList != null)
                    tree.ImageList.Images.RemoveByKey(selected.ImageKey);
            }
        }

        bool treeChanged = false;

        private void SaveTree()
        {
            if (treeChanged)
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                if (treeSearchTextBox.Text == string.Empty)
                    LoadAndSave.saveTree(treeView1, string.Format("{0}\\tree.nss", path));
                else
                    LoadAndSave.saveTree(FullTree, string.Format("{0}\\tree.nss", path));
            }
        }

        TreeView FullTree = new TreeView();

        private TreeNode RecursiveSearch(string[] searchPattern, TreeNode parent)
        {
            foreach (TreeNode child in parent.Nodes)
                RecursiveSearch(searchPattern, child);

            bool found = true;
            foreach (string patt in searchPattern)
                found &= parent.Text.ToLower().Contains(patt);

            if (found)
            {
                treeView1.Nodes.Add((TreeNode)parent.Clone());
                return parent;
            }
            else
                return new TreeNode();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            treeView1.BeginUpdate();

            treeView1.Nodes.Clear();
            if (treeSearchTextBox.Text != string.Empty)
                RecursiveSearch(treeSearchTextBox.Text.ToLower().Split(new char[] { ' ' }), FullTree.Nodes[0]);
            else
            {
                foreach (TreeNode node in FullTree.Nodes)
                    treeView1.Nodes.Add((TreeNode)node.Clone());

            }

            //enables redrawing tree after all objects have been added
            treeView1.ExpandAll();
            treeView1.EndUpdate();
            if (treeView1.TopNode != null)
            {
                treeView1.TopNode = treeView1.Nodes[0];
                treeView1.TopNode.EnsureVisible();
                treeView1.Refresh();
            }
        }

        #endregion Tree Code

        #region Events

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sail Files (.sail)|*.sail|Sail Files (.cof)|*.cof|All Files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ToggleListLoadIcon(true);
                doMeToo = LoadItemsToListView;
                while (workerList.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }
                List<string> files = Directory.GetFiles(Path.GetDirectoryName(ofd.FileName)).ToList();
                List<FileInfo> fullfiles = new List<FileInfo>(files.Count);
                files.ForEach((file) => { fullfiles.Add(new FileInfo(file)); });
                workerList.RunWorkerAsync(fullfiles);

            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 5)
                return;

            switch (e.Column)
            {
                case 0://Title
                    SortTitles();
                    break;
                case 1: //Type
                    SortTypes();
                    break;
                case 2:
                    SortSizes();
                    break;
                case 3: //Timestamp
                    SortTimeStamps();
                    break;
                case 4:// program type
                    SortPrograms();
                    break;
                default:
                    break;
            }
        }

        private void MoldListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MoldListView.Items.Count; i++)
                MoldListView.Items[i].ForeColor = Color.White;

            foreach (ListViewItem item in MoldListView.SelectedItems)
            {
                Status = string.Format("Selected Mold: {0}", item.Text);
                SelectedMold = item.Text;
                MoldListView.SelectedItems[0].ForeColor = Color.Red;
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Node and all its contents?", "Delete Selected Node", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (treeView1.SelectedNode != null)
                {
                    treeChanged = true;
                    List<int> removeImages = new List<int>();
                    //if (treeSearchTextBox.Text == string.Empty)
                    //{
                    //     RemoveDirectoryNode(treeView1.SelectedNode, ref FullTree);
                    //     treeView1.BeginUpdate();
                    //     treeView1.Nodes.Clear();
                    //     foreach (TreeNode node in FullTree.Nodes)
                    //          treeView1.Nodes.Add((TreeNode)node.Clone());
                    //     treeView1.EndUpdate();
                    //}
                    //else
                    RemoveDirectoryNode(treeView1.SelectedNode, ref treeView1);
                    treeView1.Refresh();
                    GC.Collect();
                }
            }
        }

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                try
                {
                    string argument = string.Format("/e, /select, \"{0}\"", treeView1.SelectedNode.Tag.ToString());
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = "explorer";
                    info.Arguments = argument;
                    System.Diagnostics.Process.Start(info);
                }
                catch
                {
                    MessageBox.Show("Error Locating File", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void listLoading_DoubleClick(object sender, EventArgs e)
        {
            toggle1 = !toggle1;
            listLoading.Image = toggle1 ? NsShell.Properties.Resources.loading : NsShell.Properties.Resources.loading;
            listLoading.Update();
        }

        private void treeLoading_DoubleClick(object sender, EventArgs e)
        {
            toggle2 = !toggle2;
            treeLoading.Image = toggle2 ? NsShell.Properties.Resources.loading : NsShell.Properties.Resources.loading;
            treeLoading.Update();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                    System.Diagnostics.Process.Start(item.SubItems[item.SubItems.Count - 1].Text);
            }
            catch { }
        }

        private void locateOnDiskToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentFiles.Count > 0)
            {
                string argument = "";
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    argument = string.Format("/e, /select, \"{0}\"", item.SubItems[item.SubItems.Count - 1].Text);

                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = "explorer";
                    info.Arguments = argument;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Status = "";
            if (!directoryWorker.IsBusy && SailFileDirectory != null)
                directoryWorker.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTree();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToggleTreeLoadIcon(true);
            while (workerTree.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }

            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = string.Format("{0}\\tree.nss", path);

            doWorkOnMe = LoadTree;
            workerTree.RunWorkerAsync(path);

            if (!PathSetter.AllFilesFound)
                MessageBox.Show("Error With Executable Paths.  Fix Those Before Continuing..", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void MoldListView_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedMold != "" && SailFile != null)
            {
                Status = "Launching NHT Gen...";
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                info.FileName = @NhtgenExeFullPath;
                info.Arguments = string.Format("{0} {1}", "\"" + SailFile.FullName + "\"", SelectedMold.Remove(0, 5));
                System.Diagnostics.Process.Start(info);
            }
        }

        private void expandTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        //********************** Gabe/Ken Update 10/12 ************************
        // define list of possible file names. 

        List<string> FileTypes = new List<string>() { "dblam", "lam", "yarn", "grid", "db" };

        /// <summary>
        /// get file type of w4l if w4l is a grid, yarn, dblam, db, or lam file, else do nothing
        /// </summary>
        /// <param name="w4lfilename">w4l filename (not the full filename)</param>
        /// <param name="type">this will give you the file type if one is found</param>
        /// <returns>true if it found something, false otherwise</returns>
        bool GetFileType(string w4lfilename, ref string type)
        {
            string workingFilename = w4lfilename.ToLower();
            List<string> foundTypes = new List<string>();
            for (int i = 0; i < FileTypes.Count; i++)
            {
                if (workingFilename.Contains(FileTypes[i]))
                    foundTypes.Add(FileTypes[i]);
            }

            if (foundTypes.Contains("dblam") && foundTypes.Contains("lam") && foundTypes.Contains("db"))
                type = "dblam";
            else if (foundTypes.Count > 0)
                type = foundTypes[0];
            else
                return false;

            return true;

        }
        //************************************************************************

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && SailFile != null)
            {
                
                addMru(SailFile.FullName);

                // ************** Modified by Salvo 10/12 **************
                string newFileName = "";
                string newPathw4l = "";

                string type = "";
                if (!GetFileType(treeView1.SelectedNode.Text, ref type))
                {
                    //make new filename with these rules: take 2 characters before and two characters after the dash and assign that to the new w4l filename Yarn.w4l
                    newFileName = SailFile.Name.Substring(SailFile.Name.LastIndexOf("-") - 2, 2) + SailFile.Name.Substring(SailFile.Name.LastIndexOf("-") + 1, 2) + "YARN.w4l";
                    //make directory with working directory and new filename
                    newPathw4l = SailFile.DirectoryName + "\\" + newFileName;
                }
                else
                {
                    newFileName = SailFile.Name.Substring(SailFile.Name.LastIndexOf("-") - 2, 2) + SailFile.Name.Substring(SailFile.Name.LastIndexOf("-") + 1, 2) + type.ToUpper() + ".w4l";
                    //make directory with working directory and new filename
                    newPathw4l = SailFile.DirectoryName + "\\" + newFileName;
                }
                bool sigue = false;
                if (File.Exists(newPathw4l))
                {
                    try { File.Delete(newPathw4l); sigue = true; }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "NsShell", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
                }

                //********************************************************
                if (!sigue)
                    return;

                Status = "Launching Layout...";
                string layoutPath = PathSetter.LayoutExeFullPath;
                string iniFilePath = PathSetter.LayoutIniFullPath;
                DialogResult result = MessageBox.Show("Is this a sectional sail?", "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    layoutPath = PathSetter.LayoutSectionalExeFullPath;
                    iniFilePath = PathSetter.LayoutSectionalIniFullPath;
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    layoutPath = PathSetter.LayoutExeFullPath;
                    iniFilePath = PathSetter.LayoutIniFullPath;
                }
                else
                    return;

                try
                {
                    File.Copy(treeView1.SelectedNode.Tag.ToString(), newPathw4l);
                    ModifyLayoutIni(CofFile.FullName, iniFilePath);
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = @layoutPath;
                    info.Arguments = string.Format("{0}", "\"" + newPathw4l + "\"");
                    System.Diagnostics.Process.Start(info);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("already exists"))
                    {
                        ModifyLayoutIni(CofFile.FullName, iniFilePath);
                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                        info.FileName = @layoutPath;
                        info.Arguments = string.Format("{0}", "\"" + newPathw4l + "\"");
                        System.Diagnostics.Process.Start(info);
                        System.Diagnostics.Process.Start(newPathw4l);
                    }
                    else
                        MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void openSailDirectoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void m_LaunchPLC_Click(object sender, EventArgs e)
        {
            if (NHTFile != null)
            {
                try
                {
                    addMru(SailFile.FullName);
                    Status = "Launching PLC File Generator...";
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = @NsfgExeFullPath;
                    info.Arguments = string.Format("{0} {1}", "\"" + NHTFile.FullName + "\"", "PLC");
                    System.Diagnostics.Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void m_launchMPF_Click(object sender, EventArgs e)
        {
            if (_3DIfile != null)
            {
                try
                {
                    addMru(SailFile.FullName);
                    Status = "Launching MPF File Generator...";
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = @NsfgExeFullPath;
                    info.Arguments = string.Format("{0} {1}", "\"" + _3DIfile.FullName + "\"", "MPF");
                    System.Diagnostics.Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void m_launch3DI_Click(object sender, EventArgs e)
        {
            if (_3DIfile != null)
            {
                try
                {
                    addMru(SailFile.FullName);
                    Status = "Launching 3DI File Viewer...";
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                    info.FileName = @NsfgExeFullPath;
                    info.Arguments = string.Format("{0} {1}", "\"" + _3DIfile.FullName + "\"", "Viewer");
                    System.Diagnostics.Process.Start(info);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void setExePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathSetter.Show();
            PathSetter.BringToFront();
        }

        #endregion Events

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("North Sails Nevada\nCopyright 2012\nWritten By: Gabe Testa", "NsShell v" + Version, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void recentToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            // parse a file that contains all the filename (Full paths) that you've added to the mru

            // displace them in the recent submenu (find code how-to)

            // handle click events
            if (!File.Exists("mru.sav"))
                return;

            recentToolStripMenuItem.DropDownItems.Clear();
            List<string> filesReadFromFile = new List<string>();
            using (StreamReader sr = new StreamReader("mru.sav"))
            {
                while (!sr.EndOfStream)
                {
                    filesReadFromFile.Add(sr.ReadLine());
                }
            }
            filesReadFromFile.Reverse();
            Bitmap image = NsShell.Properties.Resources.boat;
            filesReadFromFile.ForEach(s => { recentToolStripMenuItem.DropDownItems.Add(s, image, new EventHandler(MRUClicked)); });
        }

        private void MRUClicked(object sender, EventArgs e)
        {
            ToggleListLoadIcon(true);
            doMeToo = LoadItemsToListView;
            while (workerList.IsBusy) { System.Threading.Thread.Yield(); Application.DoEvents(); }
            List<string> files = Directory.GetFiles(Path.GetDirectoryName(sender.ToString())).ToList();
            List<FileInfo> fullfiles = new List<FileInfo>(files.Count);
            files.ForEach((file) => { fullfiles.Add(new FileInfo(file)); });
            workerList.RunWorkerAsync(fullfiles);
        }

        private void addMru(string fullfilename)
        {
            if (fullfilename == null)
                return;

            //check for file
            if (!File.Exists("mru.sav"))
            {
                //file does not exist
                // then we don't need to worry about checking anything, just the the file to the new mru.sav file
                using (StreamWriter sw = new StreamWriter("mru.sav"))
                {
                    sw.WriteLine(fullfilename);
                }

                return;
            }
            else
            {
                // file does exits
                List<string> temp = new List<string>();
                string FileLine;
                //create a temporary list List<string>
                using (StreamReader sr = new StreamReader("mru.sav"))
                {
                    while (!sr.EndOfStream)
                    {
                        // use a streamreader to read the contents of the file.  Adding each entry to the list
                        FileLine = sr.ReadLine();
                        if (!temp.Contains(FileLine))
                            temp.Add(FileLine);
                    }
                }

                // move old item to the end
                if (temp.Contains(fullfilename))
                    temp.Remove(fullfilename);
                // if the list count == 6, then we have to remove the top element of the list, and
                if (temp.Count > 6)
                {
                    temp.RemoveAt(0);
                    temp.Add(fullfilename);
                }
                else
                    temp.Add(fullfilename);


                using (StreamWriter sw = new StreamWriter("mru.sav"))
                {
                    foreach (string s in temp)
                        sw.WriteLine(s);

                }
            }
        }
    }

    /// <summary>
    /// jhTreeViewTools is a namespace for classes around the TreeView control
    /// This (only) one is a class for saving and loading the TreeView 
    /// </summary>
    public static class LoadAndSave
    {
        #region Save (saveTree, saveNode)
        /// <summary>
        /// Save the TreeView content
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="filename"></param>
        /// <returns>Errorcode as int</returns>
        public static int saveTree(TreeView tree, string filename)
        {
            // Neues Array anlegen
            ArrayList al = new ArrayList();
            foreach (TreeNode tn in tree.Nodes)
            {
                // jede RootNode im TreeView sichern ...
                al.Add(tn);
            }

            // Datei anlegen
            Stream file = File.Open(filename, FileMode.Create);
            // Binär-Formatierer init.
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                // Serialisieren des Arrays
                bf.Serialize(file, al);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                MessageBox.Show("Serialization failed : {0}", e.Message);
                return -1; // ERROR
            }

            // Datei schliessen
            file.Close();

            return 0; // OKAY
        }

        #endregion

        #region Load (loadTree, searchNode)

        /// <summary>
        /// Load the TreeView content
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="filename"></param>
        /// <returns>Errorcode as int</returns>
        public static int loadTree(TreeView tree, string filename)
        {
            if (File.Exists(filename))
            {
                ImageList images = new ImageList();
                // Datei öffnen
                Stream file = File.Open(filename, FileMode.Open);
                // Binär-Formatierer init.
                BinaryFormatter bf = new BinaryFormatter();
                // Object var. init.
                object obj = null;
                try
                {
                    // Daten aus der Datei deserialisieren
                    obj = bf.Deserialize(file);
                }
                catch (System.Runtime.Serialization.SerializationException e)
                {
                    MessageBox.Show("De-Serialization failed : {0}", e.Message);
                    return -1;
                }
                // Datei schliessen
                file.Close();

                // Neues Array erstellen
                ArrayList nodeList = obj as ArrayList;

                // load Root-Nodes

                int count = 0;
                foreach (TreeNode node in nodeList)
                    tree.Nodes.Add(RecursivelyAddNodes(node, ref count));

                RecursivelyGetImages((TreeNode)nodeList[0], ref images);
                tree.ImageList = images;
                tree.ExpandAll();
                return 0;

            }
            else return -2; // File existiert nicht
        }

        private static TreeNode RecursivelyAddNodes(TreeNode Parent, ref int count)
        {
            var directoryNode = new TreeNode(Parent.Text, count, count++);
            directoryNode.Tag = Parent.Tag;
            directoryNode.Name = Parent.Name;
            foreach (TreeNode Node in Parent.Nodes)
                directoryNode.Nodes.Add(RecursivelyAddNodes(Node, ref count));
            return directoryNode;
        }

        private static void RecursivelyGetImages(TreeNode p, ref ImageList il)
        {
            Bitmap image;
            if (Path.GetExtension(p.Tag.ToString()).ToLower() == ".w4l")
                image = NsShell.Properties.Resources.w4lLogo;
            else
                image = NsShell.Properties.Resources.folder_fill_24x24;
            il.Images.Add(image);
            foreach (TreeNode n in p.Nodes)
                RecursivelyGetImages(n, ref il);
        }

        #endregion
    }

}
