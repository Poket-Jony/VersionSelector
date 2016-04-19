using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VersionSelector
{
    public partial class MainForm : Form
    {
        public App currentApp;
        public Settings settings;

        public MainForm(string[] args)
        {
            InitializeComponent();
            settings = new Settings();
            ParseArguments(args);
            LoadIconList();
        }

        private void ParseArguments(string[] args)
        {
            if (args.Length != 0)
            {
                if (args[0] == "clear")
                {
                    settings.ClearDefaultApps();
                    settings.SaveSettings();
                    MessageBox.Show("Cleared!");
                    return;
                }

                try
                {
                    List<string> argsList = new List<string>();
                    argsList = args.ToList();
                    argsList.RemoveAt(0);
                    currentApp = new App(args[0], argsList);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Please open with an application!");
                Environment.Exit(1);
            }
        }

        private void LoadIconList()
        {
            ClearItems();
            List<DefaultApp> apps = settings.GetDefaultAppsByExtension(currentApp.FileExtension);
            foreach(DefaultApp app in apps)
            {
                AddItem(app.FilePath, app.GetFileIcon().ToBitmap(), app);
            }
            AddItem("addIcon", Properties.Resources.add);
            AddItem("delIcon", Properties.Resources.del);
        }

        private void AddItem(string imageKey, Image icon, DefaultApp defaultApp = null)
        {
            imgListIcons.Images.Add(imageKey, icon);
            ListViewItem item = new ListViewItem();
            item.ImageKey = imageKey;
            if (defaultApp != null)
            {
                item.Text = defaultApp.GetApplicationName();
                item.Tag = defaultApp;
            }
            listViewApps.Items.Add(item);
        }

        private void RemoveItem(ListViewItem item)
        {
            listViewApps.Items.Remove(item);
            imgListIcons.Images.RemoveByKey(item.ImageKey);
        }

        private void ClearItems()
        {
            listViewApps.Clear();
            imgListIcons.Images.Clear();
        }

        private void listViewApps_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewApps.FocusedItem.Bounds.Contains(e.Location) == true)
            {
                OnItemSelectionChanged(listViewApps.SelectedItems[0], e);
            }
        }

        private void OnItemSelectionChanged(ListViewItem item, MouseEventArgs mouse)
        {
            if (mouse.Button == MouseButtons.Left)
            {
                if (item.ImageKey == "addIcon")
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Title = "Select application to open:";
                    openDialog.Filter = "Applications|*.exe|All Files|*.*";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        DefaultApp app = new DefaultApp(openDialog.FileName, currentApp.FileExtension);
                        settings.AddDefaultApp(app);
                        settings.SaveSettings();
                        app.StartProgram(currentApp);
                        Application.Exit();
                    }
                }
                else if(item.ImageKey != "delIcon")
                {
                    DefaultApp app = (DefaultApp)item.Tag;
                    app.StartProgram(currentApp);
                    Application.Exit();
                }
            }
        }

        private void listViewApps_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listViewApps.DoDragDrop(listViewApps.SelectedItems, DragDropEffects.Move);
        }

        private void listViewApps_DragEnter(object sender, DragEventArgs e)
        {
            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void listViewApps_DragDrop(object sender, DragEventArgs e)
        {
            if (listViewApps.SelectedItems.Count == 0)
                return;
            Point cp = listViewApps.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = listViewApps.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
                return;
            ListViewItem fromItem = listViewApps.SelectedItems[0];
            if (dragToItem.ImageKey == "delIcon" && fromItem.ImageKey != "addIcon" && fromItem.ImageKey != "delIcon")
            {
                RemoveItem(fromItem);
                settings.DelDefaultApp((DefaultApp)fromItem.Tag, currentApp.FileExtension);
                settings.SaveSettings();
            }
        }
    }
}
