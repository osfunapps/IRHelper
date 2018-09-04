using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.project.hexwindow
{
    partial class HexWindow
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
            this.focusBtn = new System.Windows.Forms.Button();
            this.hexesCLB = new System.Windows.Forms.CheckedListBox();
            this.validateBtn = new System.Windows.Forms.Button();
            this.remoteNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // focusBtn
            // 
            this.focusBtn.Location = new System.Drawing.Point(685, 518);
            this.focusBtn.Name = "focusBtn";
            this.focusBtn.Size = new System.Drawing.Size(1, 1);
            this.focusBtn.TabIndex = 1;
            this.focusBtn.Text = "button1";
            this.focusBtn.UseVisualStyleBackColor = true;
            // 
            // hexesCLB
            // 
            this.hexesCLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.hexesCLB.ForeColor = System.Drawing.Color.Maroon;
            this.hexesCLB.FormattingEnabled = true;
            this.hexesCLB.HorizontalScrollbar = true;
            this.hexesCLB.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hexesCLB.Location = new System.Drawing.Point(13, 13);
            this.hexesCLB.Name = "hexesCLB";
            this.hexesCLB.Size = new System.Drawing.Size(971, 469);
            this.hexesCLB.TabIndex = 2;
            this.hexesCLB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemChecked);
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(460, 492);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(78, 46);
            this.validateBtn.TabIndex = 3;
            this.validateBtn.Text = "Done";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // remoteNameLabel
            // 
            this.remoteNameLabel.AutoSize = true;
            this.remoteNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remoteNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.remoteNameLabel.Location = new System.Drawing.Point(13, 492);
            this.remoteNameLabel.Name = "remoteNameLabel";
            this.remoteNameLabel.Text = "Calibrating...";
            this.remoteNameLabel.Size = new System.Drawing.Size(170, 31);
            this.remoteNameLabel.TabIndex = 4;
            // 
            // HexWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 546);
            this.Controls.Add(this.remoteNameLabel);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.hexesCLB);
            this.Controls.Add(this.focusBtn);
            this.DoubleBuffered = true;
            this.Name = "HexWindow";
            this.ShowIcon = false;
            this.Text = "Hexes Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button focusBtn;
        private CheckedListBox hexesCLB;
        private Button validateBtn;
        private Label remoteNameLabel;
    }
}