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
            this.xmlPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.XmlBrowseBtn = new System.Windows.Forms.Button();
            this.remotePicDialog = new System.Windows.Forms.OpenFileDialog();
            this.startOverCB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pauseBtnCB = new System.Windows.Forms.ComboBox();
            this.logBtn = new System.Windows.Forms.LinkLabel();
            this.actionsBtn = new System.Windows.Forms.LinkLabel();
            this.textToSpeechCB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.undoBtnCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freezeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBtn.Location = new System.Drawing.Point(160, 338);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(139, 72);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.Go_Clicked);
            // 
            // xmlPathTB
            // 
            this.xmlPathTB.AllowDrop = true;
            this.xmlPathTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlPathTB.Location = new System.Drawing.Point(72, 29);
            this.xmlPathTB.Name = "xmlPathTB";
            this.xmlPathTB.Size = new System.Drawing.Size(234, 20);
            this.xmlPathTB.TabIndex = 1;
            this.xmlPathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.XmlPathDropHandler);
            this.xmlPathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(17, 31);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(49, 13);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Xml Path";
            // 
            // xmlPathDialog
            // 
            this.xmlPathDialog.FileName = "xmlPathDialog";
            this.xmlPathDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // XmlBrowseBtn
            // 
            this.XmlBrowseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XmlBrowseBtn.Location = new System.Drawing.Point(323, 23);
            this.XmlBrowseBtn.Name = "XmlBrowseBtn";
            this.XmlBrowseBtn.Size = new System.Drawing.Size(61, 30);
            this.XmlBrowseBtn.TabIndex = 5;
            this.XmlBrowseBtn.Text = "Browse...";
            this.XmlBrowseBtn.UseVisualStyleBackColor = true;
            this.XmlBrowseBtn.Click += new System.EventHandler(this.Browse_Xml_Path_clicked);
            // 
            // remotePicDialog
            // 
            this.remotePicDialog.FileName = "openFileDialog1";
            // 
            // startOverCB
            // 
            this.startOverCB.AutoSize = true;
            this.startOverCB.Location = new System.Drawing.Point(12, 300);
            this.startOverCB.Name = "startOverCB";
            this.startOverCB.Size = new System.Drawing.Size(142, 17);
            this.startOverCB.TabIndex = 7;
            this.startOverCB.Text = "Run over existing values";
            this.startOverCB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "With Pause Button";
            // 
            // pauseBtnCB
            // 
            this.pauseBtnCB.DisplayMember = "Space";
            this.pauseBtnCB.FormattingEnabled = true;
            this.pauseBtnCB.Location = new System.Drawing.Point(130, 32);
            this.pauseBtnCB.Name = "pauseBtnCB";
            this.pauseBtnCB.Size = new System.Drawing.Size(254, 21);
            this.pauseBtnCB.Sorted = true;
            this.pauseBtnCB.TabIndex = 15;
            this.pauseBtnCB.SelectedIndexChanged += new System.EventHandler(this.pauseBtnCB_SelectedIndexChanged);
            // 
            // logBtn
            // 
            this.logBtn.AutoSize = true;
            this.logBtn.Location = new System.Drawing.Point(395, 397);
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
            this.actionsBtn.Location = new System.Drawing.Point(12, 273);
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
            this.textToSpeechCB.Location = new System.Drawing.Point(12, 330);
            this.textToSpeechCB.Name = "textToSpeechCB";
            this.textToSpeechCB.Size = new System.Drawing.Size(103, 17);
            this.textToSpeechCB.TabIndex = 24;
            this.textToSpeechCB.Text = "Text To Speech";
            this.textToSpeechCB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textToSpeechCB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "With Undo Button";
            // 
            // undoBtnCB
            // 
            this.undoBtnCB.DisplayMember = "Space";
            this.undoBtnCB.FormattingEnabled = true;
            this.undoBtnCB.Location = new System.Drawing.Point(130, 65);
            this.undoBtnCB.Name = "undoBtnCB";
            this.undoBtnCB.Size = new System.Drawing.Size(254, 21);
            this.undoBtnCB.Sorted = true;
            this.undoBtnCB.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pauseBtnCB);
            this.groupBox1.Controls.Add(this.undoBtnCB);
            this.groupBox1.Location = new System.Drawing.Point(30, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 105);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Commands";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.freezeCB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pathLabel);
            this.groupBox2.Controls.Add(this.xmlPathTB);
            this.groupBox2.Controls.Add(this.XmlBrowseBtn);
            this.groupBox2.Location = new System.Drawing.Point(30, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 126);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "seconds after each transmit";
            // 
            // freezeCB
            // 
            this.freezeCB.FormattingEnabled = true;
            this.freezeCB.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2.0",
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "2.5"});
            this.freezeCB.Location = new System.Drawing.Point(109, 78);
            this.freezeCB.Name = "freezeCB";
            this.freezeCB.Size = new System.Drawing.Size(50, 21);
            this.freezeCB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Wait for";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textToSpeechCB);
            this.Controls.Add(this.actionsBtn);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.startOverCB);
            this.Controls.Add(this.goBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AppForm";
            this.Text = "IR Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosedHandler);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void onFormClosedHandler(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("closing!");
            appCoordinator.OnAllNodesValidated();
        }

        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox xmlPathTB;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.OpenFileDialog xmlPathDialog;
        private System.Windows.Forms.Button XmlBrowseBtn;
        private System.Windows.Forms.OpenFileDialog remotePicDialog;
        private CheckBox startOverCB;
        private Label label4;
        private ComboBox pauseBtnCB;
        private LinkLabel logBtn;
        private LinkLabel actionsBtn;
        private CheckBox textToSpeechCB;
        private Label label3;
        private ComboBox undoBtnCB;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private ComboBox freezeCB;
    }
}