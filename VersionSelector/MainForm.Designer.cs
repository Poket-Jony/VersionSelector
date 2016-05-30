namespace VersionSelector
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewApps = new System.Windows.Forms.ListView();
            this.imgListIcons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listViewApps
            // 
            this.listViewApps.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewApps.AllowDrop = true;
            this.listViewApps.BackColor = System.Drawing.Color.White;
            this.listViewApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewApps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewApps.LargeImageList = this.imgListIcons;
            this.listViewApps.Location = new System.Drawing.Point(0, 0);
            this.listViewApps.MultiSelect = false;
            this.listViewApps.Name = "listViewApps";
            this.listViewApps.Scrollable = false;
            this.listViewApps.ShowGroups = false;
            this.listViewApps.Size = new System.Drawing.Size(503, 324);
            this.listViewApps.TabIndex = 0;
            this.listViewApps.UseCompatibleStateImageBehavior = false;
            this.listViewApps.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewApps_ItemDrag);
            this.listViewApps.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewApps_DragDrop);
            this.listViewApps.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewApps_DragEnter);
            this.listViewApps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewApps_MouseClick);
            // 
            // imgListIcons
            // 
            this.imgListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListIcons.ImageSize = new System.Drawing.Size(40, 40);
            this.imgListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 324);
            this.Controls.Add(this.listViewApps);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Version Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewApps;
        private System.Windows.Forms.ImageList imgListIcons;
    }
}

