﻿/*
    This file is part of libEDSsharp.

    libEDSsharp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    libEDSsharp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with libEDSsharp.  If not, see <http://www.gnu.org/licenses/>.
  
  
    Copyright(c) 2016 Robin Cornelius <robin.cornelius@gmail.com>
*/

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
using libEDSsharp;
using System.Globalization;
using Xml2CSharp;


namespace ODEditor
{
    public partial class ODEditor_MainForm : Form
    {

        public static Dictionary<UInt16, EDSsharp> TXCobMap = new Dictionary<UInt16, EDSsharp>();

        public ODEditor_MainForm()
        {
            InitializeComponent();
            loadprofiles();

            insertToolStripMenuItem.Enabled = false;
        }

        private void loadprofiles()
        {
            string[] profilelist = Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+Path.DirectorySeparatorChar+"Profiles");
            ToolStripMenuItem[] items = new ToolStripMenuItem[profilelist.Length];

            int x = 0;
            foreach(string file in profilelist)
            {
            
                ToolStripMenuItem i = new ToolStripMenuItem();
                i.Name = Path.GetFileName(file);
                i.Text = Path.GetFileName(file);
                i.Click += ProfileAddClick;
                items[x++] = i;   
            }

            insertToolStripMenuItem.DropDownItems.AddRange(items);
        
        }

        void ProfileAddClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                DeviceView dv = (DeviceView)tabControl1.SelectedTab.Controls[0];
               
                ToolStripMenuItem item = (ToolStripMenuItem)sender;

                string filename = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "Profiles" + Path.DirectorySeparatorChar + item.Name;

                CanOpenXML coxml = new CanOpenXML();
                coxml.readXML(filename);

                Bridge b = new Bridge();

                EDSsharp eds;
                Device dev; //one day this will be multiple devices

                eds = b.convert(coxml.dev);
                dev = coxml.dev;

                foreach(KeyValuePair<UInt16,ODentry> kvp in eds.ods)
                {
                    if (!dv.eds.ods.ContainsKey(kvp.Key))
                        dv.eds.ods.Add(kvp.Key, kvp.Value);
                }

                
                dv.dispatch_updateOD();

            }
        }

        private void openEDSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EDSsharp eds;
            Device dev; //one day this will be multiple devices

            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "Electronic Data Sheets (*.eds)|*.eds";
            if (odf.ShowDialog() == DialogResult.OK)
            {

                Warnings.warning_list.Clear();

                eds = new EDSsharp();

                //fix me enable exceptions for production code

                try
                {
                    eds.loadfile(odf.FileName);
                    Bridge bridge = new Bridge(); //tell me again why bridge is not static?
                    dev = bridge.convert(eds);

                    DeviceView device = new DeviceView();

                    device.eds = eds;
                    tabControl1.TabPages.Add(eds.di.ProductName);
                    tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(device);

                    device.dispatch_updateOD();
                    
                }
                catch(Exception ex)
                {
                    Warnings.warning_list.Add(ex.ToString());  
                }

                if(Warnings.warning_list.Count!=0)
                {
                    WarningsFrm frm = new WarningsFrm();
                    frm.ShowDialog();
                }


            }
        }

        private void exportCanOpenNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                DeviceView dv = (DeviceView)tabControl1.SelectedTab.Controls[0];

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.CheckFileExists = false;

                
                sfd.FileName = "CO_OD.c";
                sfd.InitialDirectory = dv.eds.fi.exportFolder;
                sfd.RestoreDirectory = true;

                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string savePath = Path.GetDirectoryName(sfd.FileName);
                    dv.eds.fi.exportFolder = savePath;

                    CanOpenNodeExporter cone = new CanOpenNodeExporter();
                    cone.export(savePath, dv.eds);                   
                }
            }
             

        }

        private void openCanOpenNodeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EDSsharp eds;
            Device dev; //one day this will be multiple devices

            OpenFileDialog odf = new OpenFileDialog();
            odf.Filter = "XML (*.xml)|*.xml";
            if (odf.ShowDialog() == DialogResult.OK)
            { 

                CanOpenXML coxml = new CanOpenXML();
                coxml.readXML(odf.FileName);

                Bridge b = new Bridge();

                eds = b.convert(coxml.dev);

                dev = coxml.dev;

                tabControl1.TabPages.Add(eds.di.ProductName);

                DeviceView device = new DeviceView();

                device.eds = eds;
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(device);

                device.dispatch_updateOD();

            }

        }


        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveEDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                DeviceView dv = (DeviceView)tabControl1.SelectedTab.Controls[0];
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Electronic Data Sheets (*.eds)|*.eds";

                sfd.FileName = dv.eds.fi.FileName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dv.eds.savefile(sfd.FileName);
                }

            }
        }

        private void saveProjectXMLToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (tabControl1.SelectedTab != null)
                {
                    DeviceView dv = (DeviceView)tabControl1.SelectedTab.Controls[0];
                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "Canopen Node XML (*.xml)|*.xml";

                    sfd.FileName = dv.eds.fi.FileName;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //dv.eds.savefile(sfd.FileName);

                        Bridge b = new Bridge();
                        Device d = b.convert(dv.eds);

                        CanOpenXML coxml = new CanOpenXML();
                            coxml.dev = d;

                            coxml.writeXML(sfd.FileName);
    
                    }


                }
            }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EDSsharp eds = new EDSsharp();
            eds.di.ProductName = "New Product";

            tabControl1.TabPages.Add(eds.di.ProductName);

            DeviceView device = new DeviceView();

            device.eds = eds;
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(device);

            device.dispatch_updateOD();
        }

        private void tabControl1_ControlsChanged(object sender, ControlEventArgs e)
        {
                insertToolStripMenuItem.Enabled = tabControl1.TabCount>0;
                saveEDSToolStripMenuItem.Enabled = tabControl1.TabCount>0;
                saveProjectXMLToolStripMenuItem.Enabled = tabControl1.TabCount>0;
                exportCanOpenNodeToolStripMenuItem.Enabled = tabControl1.TabCount>0;
                closeFileToolStripMenuItem.Enabled = tabControl1.TabCount>0;       
        }
    }
}
