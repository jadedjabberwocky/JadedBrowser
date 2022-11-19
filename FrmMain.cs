using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace jadedbrowser
{
    public partial class FrmMain : Form
    {
        bool busy = false;
        bool interrupt = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(string baseDir) : this()
        {
            txtBaseDir.Text = baseDir;
        }

        private async void refreshList()
        {
            if (txtBaseDir.Text == "")
            {
                txtBaseDir.BackColor = System.Drawing.Color.Red;
                Application.DoEvents();
                Thread.Sleep(500);
                txtBaseDir.BackColor = System.Drawing.Color.White;
                Application.DoEvents();
                return;
            }

            if (txtSearch.Text == "")
            {
                txtSearch.BackColor = System.Drawing.Color.Red;
                Application.DoEvents();
                Thread.Sleep(500);
                txtSearch.BackColor = System.Drawing.Color.White;
                Application.DoEvents();
                return;
            }

            if (busy)
            {
                if (MessageBox.Show("Already busy - interrupt?", "Jaded Browser", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    interrupt = true;
                } else
                {
                    return;
                }
            }

            lock (this)
            {
                busy = true;
                interrupt = false;

                try
                {
                    string baseDir = txtBaseDir.Text;
                    string search = "*" + txtSearch.Text + "*.*";

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

                    List<ListViewItem> items = new List<ListViewItem>();
                    foreach (string fullName in matchNames)
                    {
                        if (interrupt) return;

                        FileInfo fi = new FileInfo(fullName);
                        string baseName = fi.Name;

                        try
                        {
                            Image img = new Bitmap(fullName);
                            img = new Bitmap(img, imageList1.ImageSize.Width, imageList1.ImageSize.Height);
                            imageList1.Images.Add(img);
                            int imageIndex = imageList1.Images.Count - 1;

                            ListViewItem item = new ListViewItem(baseName, imageIndex);
                            item.Tag = fullName;
                            item.ToolTipText = fullName;
                            items.Add(item);

                            i++;
                            this.Text = "Jaded Browser (" + i + " of " + matchNames.Count() + ")";
                            Application.DoEvents();
                        }
                        catch (Exception ex)
                        {
                            // TODO: Log errors
                        }
                    }

                    lstImages.Items.AddRange(items.ToArray());
                }
                catch (Exception ex)
                {
                    this.Text = ex.Message;
                    // TODO: Something
                } finally
                {
                    busy = false;
                    interrupt = false;
                }
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                refreshList();
            }
        }

        private void txtBaseDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                refreshList();
            }
        }
    }
}