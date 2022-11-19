using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace jadedbrowser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private async void refreshList()
        {
            try
            {
                string baseDir = txtBaseDir.Text;
                string search = "*" + txtSearch.Text + "*.*";

                if (baseDir == "")
                {
                    MessageBox.Show("No working folder selected (use drag and drop)");
                    return;
                }

                if (search == "")
                {
                    MessageBox.Show("No search string entered");
                    return;
                }

                string[] fullNames = Directory.GetFiles(baseDir, search, SearchOption.AllDirectories);
                List<string> matchNames = new List<string>();
                Regex validSuffixes = new Regex(".*\\.(jpg|jpeg|png)$");
                
                foreach (string fullName in fullNames)
                {
                    if (!validSuffixes.IsMatch(fullName)) continue;
                    matchNames.Add(fullName);
                }

                lstImages.Items.Clear();
                imageList1.Images.Clear();

                int i = 0;
                this.Text = "Jaded Browser (" + i + " of " + matchNames.Count() + ")";

                ListViewItem[] items = new ListViewItem[matchNames.Count];
                foreach (string fullName in matchNames)
                {
                    FileInfo fi = new FileInfo(fullName);
                    string baseName = fi.Name;

                    Image img = new Bitmap(fullName);
                    imageList1.Images.Add(img);
                    int imageIndex = imageList1.Images.Count - 1;
                    ListViewItem item = new ListViewItem(baseName, imageIndex);
                    item.Tag = fullName;
                    item.ToolTipText = fullName;
                    items[i] = item;

                    i++;
                    this.Text = "Jaded Browser (" + i + " of " + matchNames.Count() + ")";
                    Application.DoEvents();

                }

                lstImages.Items.AddRange(items);
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
                // TODO: Something
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstImages.SelectedItems)
            {
                string fullName = (string)item.Tag;

                Process.Start("explorer.exe", fullName);
            }
        }

        private void openItemFolder()
        {
            foreach (ListViewItem item in lstImages.SelectedItems)
            {
                string fullName = (string)item.Tag;
                FileInfo fi = new FileInfo(fullName);

                Process.Start("explorer.exe", fi.DirectoryName);
            }
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openItemFolder();
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            DragDropEffects effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path))
                    effects = DragDropEffects.Copy;
            }

            e.Effect = effects;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path))
                {
                    txtBaseDir.Text = path;
                    if (path != "")
                    {
                        refreshList();
                    }
                }
            }
        }

        private void lstImages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openItemFolder();
        }
    }
}