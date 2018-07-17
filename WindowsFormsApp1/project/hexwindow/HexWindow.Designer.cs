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
            this.hexRTB = new System.Windows.Forms.RichTextBox();
            this.focusBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hexRTB
            // 
            this.hexRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.hexRTB.ForeColor = System.Drawing.Color.Maroon;
            this.hexRTB.Location = new System.Drawing.Point(0, 0);
            this.hexRTB.Name = "hexRTB";
            this.hexRTB.Size = new System.Drawing.Size(996, 601);
            this.hexRTB.TabIndex = 0;
            this.hexRTB.Text = "";
            this.hexRTB.WordWrap = false;
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
            // HexWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 601);
            this.Controls.Add(this.focusBtn);
            this.Controls.Add(this.hexRTB);
            this.DoubleBuffered = true;
            this.Name = "HexWindow";
            this.ShowIcon = false;
            this.Text = "Hexes Window";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox hexRTB;
        private Button focusBtn;
    }
}