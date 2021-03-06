﻿namespace ODEditor
{
    partial class DeviceView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deviceInfoView = new ODEditor.DeviceInfoView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deviceODView1 = new ODEditor.DeviceODView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.devicePDOView1 = new DevicePDOView();
            this.devicePDOView2 = new DevicePDOView();

            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1122, 773);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deviceInfoView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1114, 747);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Device Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deviceInfoView
            // 
            this.deviceInfoView.Location = new System.Drawing.Point(6, 6);
            this.deviceInfoView.Name = "deviceInfoView";
            this.deviceInfoView.Size = new System.Drawing.Size(754, 525);
            this.deviceInfoView.TabIndex = 0;
            this.deviceInfoView.Load += new System.EventHandler(this.deviceInfoView_Load);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deviceODView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1114, 747);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Object Dictionary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deviceODView1
            // 
            this.deviceODView1.Location = new System.Drawing.Point(0, 2);
            this.deviceODView1.Name = "deviceODView1";
            this.deviceODView1.Size = new System.Drawing.Size(1112, 749);
            this.deviceODView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.devicePDOView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1114, 747);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TX PDO Mapping";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // devicePDOView1
            // 
            this.devicePDOView1.Location = new System.Drawing.Point(3, 3);
            this.devicePDOView1.Name = "devicePDOView1";
            this.devicePDOView1.Size = new System.Drawing.Size(1025, 583);
            this.devicePDOView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.devicePDOView2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1114, 747);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "RX PDO Mapping";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // devicePDOView2
            // 
            this.devicePDOView2.Location = new System.Drawing.Point(3, 3);
            this.devicePDOView2.Name = "devicePDOView2";
            this.devicePDOView2.Size = new System.Drawing.Size(973, 695);
            this.devicePDOView2.TabIndex = 0;
            // 
            // DeviceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DeviceView";
            this.Size = new System.Drawing.Size(1122, 773);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private DeviceInfoView deviceInfoView;
        private DevicePDOView devicePDOView1;
        private DeviceODView deviceODView1;
        private System.Windows.Forms.TabPage tabPage4;
        private DevicePDOView devicePDOView2;
    }
}
