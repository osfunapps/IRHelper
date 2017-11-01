using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class AppForm
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
            this.goBtn = new System.Windows.Forms.Button();
            this.xmlPathTB = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.evenGohstPathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xmlPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.XmlBrowseBtn = new System.Windows.Forms.Button();
            this.RemotePicBrowseBtn = new System.Windows.Forms.Button();
            this.remotePicDialog = new System.Windows.Forms.OpenFileDialog();
            this.startOverCB = new System.Windows.Forms.CheckBox();
            this.cyclesWaitScroller = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pauseBtnCB = new System.Windows.Forms.ComboBox();
            this.logBtn = new System.Windows.Forms.LinkLabel();
            this.actionsBtn = new System.Windows.Forms.LinkLabel();
            this.textToSpeechCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cyclesWaitScroller)).BeginInit();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBtn.Location = new System.Drawing.Point(202, 199);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(100, 51);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.Go_Clicked);
            // 
            // xmlPathTB
            // 
            this.xmlPathTB.AllowDrop = true;
            this.xmlPathTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlPathTB.Location = new System.Drawing.Point(115, 16);
            this.xmlPathTB.Name = "xmlPathTB";
            this.xmlPathTB.Size = new System.Drawing.Size(268, 20);
            this.xmlPathTB.TabIndex = 1;
            this.xmlPathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.XmlPathDropHandler);
            this.xmlPathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(12, 20);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(49, 13);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Xml Path";
            // 
            // evenGohstPathTB
            // 
            this.evenGohstPathTB.AllowDrop = true;
            this.evenGohstPathTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evenGohstPathTB.Location = new System.Drawing.Point(115, 42);
            this.evenGohstPathTB.Name = "evenGohstPathTB";
            this.evenGohstPathTB.Size = new System.Drawing.Size(268, 20);
            this.evenGohstPathTB.TabIndex = 3;
            this.evenGohstPathTB.TextChanged += new System.EventHandler(this.evenGohstPathTB_TextChanged);
            this.evenGohstPathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.EventGohstPathDropHandler);
            this.evenGohstPathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EventGohst Path";
            // 
            // xmlPathDialog
            // 
            this.xmlPathDialog.FileName = "xmlPathDialog";
            this.xmlPathDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // XmlBrowseBtn
            // 
            this.XmlBrowseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XmlBrowseBtn.Location = new System.Drawing.Point(389, 14);
            this.XmlBrowseBtn.Name = "XmlBrowseBtn";
            this.XmlBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.XmlBrowseBtn.TabIndex = 5;
            this.XmlBrowseBtn.Text = "Browse...";
            this.XmlBrowseBtn.UseVisualStyleBackColor = true;
            this.XmlBrowseBtn.Click += new System.EventHandler(this.Browse_Xml_Path_clicked);
            // 
            // RemotePicBrowseBtn
            // 
            this.RemotePicBrowseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemotePicBrowseBtn.Location = new System.Drawing.Point(389, 39);
            this.RemotePicBrowseBtn.Name = "RemotePicBrowseBtn";
            this.RemotePicBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.RemotePicBrowseBtn.TabIndex = 6;
            this.RemotePicBrowseBtn.Text = "Browse...";
            this.RemotePicBrowseBtn.UseVisualStyleBackColor = true;
            this.RemotePicBrowseBtn.Click += new System.EventHandler(this.Browse_Remote_Pic_Path_clicked);
            // 
            // remotePicDialog
            // 
            this.remotePicDialog.FileName = "openFileDialog1";
            this.remotePicDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.RemotePicDialog_FileOk);
            // 
            // startOverCB
            // 
            this.startOverCB.AutoSize = true;
            this.startOverCB.Location = new System.Drawing.Point(12, 199);
            this.startOverCB.Name = "startOverCB";
            this.startOverCB.Size = new System.Drawing.Size(142, 17);
            this.startOverCB.TabIndex = 7;
            this.startOverCB.Text = "Run over existing values";
            this.startOverCB.UseVisualStyleBackColor = true;
            // 
            // cyclesWaitScroller
            // 
            this.cyclesWaitScroller.Location = new System.Drawing.Point(115, 80);
            this.cyclesWaitScroller.Name = "cyclesWaitScroller";
            this.cyclesWaitScroller.Size = new System.Drawing.Size(268, 45);
            this.cyclesWaitScroller.TabIndex = 8;
            this.cyclesWaitScroller.Value = 6;
            this.cyclesWaitScroller.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Freeze Wait Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "With Pause Button";
            // 
            // pauseBtnCB
            // 
            this.pauseBtnCB.DisplayMember = "Space";
            this.pauseBtnCB.FormattingEnabled = true;
            this.pauseBtnCB.Location = new System.Drawing.Point(142, 125);
            this.pauseBtnCB.Name = "pauseBtnCB";
            this.pauseBtnCB.Size = new System.Drawing.Size(222, 21);
            this.pauseBtnCB.Sorted = true;
            this.pauseBtnCB.TabIndex = 15;
            // 
            // logBtn
            // 
            this.logBtn.AutoSize = true;
            this.logBtn.Location = new System.Drawing.Point(435, 237);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(29, 13);
            this.logBtn.TabIndex = 18;
            this.logBtn.TabStop = true;
            this.logBtn.Text = "LOG";
            this.logBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogBtn_LinkClicked);
            // 
            // actionsBtn
            // 
            this.actionsBtn.AutoSize = true;
            this.actionsBtn.Location = new System.Drawing.Point(12, 168);
            this.actionsBtn.Name = "actionsBtn";
            this.actionsBtn.Size = new System.Drawing.Size(42, 13);
            this.actionsBtn.TabIndex = 23;
            this.actionsBtn.TabStop = true;
            this.actionsBtn.Text = "Actions";
            this.actionsBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionsBtn_LinkClicked);
            // 
            // textToSpeechCB
            // 
            this.textToSpeechCB.AutoSize = true;
            this.textToSpeechCB.Location = new System.Drawing.Point(12, 229);
            this.textToSpeechCB.Name = "textToSpeechCB";
            this.textToSpeechCB.Size = new System.Drawing.Size(103, 17);
            this.textToSpeechCB.TabIndex = 24;
            this.textToSpeechCB.Text = "Text To Speech";
            this.textToSpeechCB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textToSpeechCB.UseVisualStyleBackColor = true;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 265);
            this.Controls.Add(this.textToSpeechCB);
            this.Controls.Add(this.actionsBtn);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pauseBtnCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cyclesWaitScroller);
            this.Controls.Add(this.startOverCB);
            this.Controls.Add(this.RemotePicBrowseBtn);
            this.Controls.Add(this.XmlBrowseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.evenGohstPathTB);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.xmlPathTB);
            this.Controls.Add(this.goBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AppForm";
            this.Text = "IR Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosedHandler);
            ((System.ComponentModel.ISupportInitialize)(this.cyclesWaitScroller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void onFormClosedHandler(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("closing!");
            appCoordinator.OnAllNodesSet();
        }

        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox xmlPathTB;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox evenGohstPathTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog xmlPathDialog;
        private System.Windows.Forms.Button XmlBrowseBtn;
        private System.Windows.Forms.Button RemotePicBrowseBtn;
        private System.Windows.Forms.OpenFileDialog remotePicDialog;
        private CheckBox startOverCB;
        private TrackBar cyclesWaitScroller;
        private Label label2;
        private Label label4;
        private ComboBox pauseBtnCB;
        private LinkLabel logBtn;
        private LinkLabel actionsBtn;
        private CheckBox textToSpeechCB;
    }
}