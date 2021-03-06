﻿using LayoutProject.program;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.program.tools;
using WindowsFormsApp1.project;
using WindowsFormsApp1.project.ghost;
using WindowsFormsApp1.Properties;
using Remotes_App_Translation_Project.tools;

namespace WindowsFormsApp1
{
    public partial class AppForm : Form
    {
        //instances
        private AppCoordinator appCoordinator;

        //outside params!
        private static string[] xmlPathsList;
        private static string eventGohstPath;
        internal static bool startOver;
        internal static int cyclesToWait;
        private static string userPauseBtnName;
        private static bool textToSpeech;
        public static string undoBtn;
        public static double freezeTime;

        public AppForm()
        {
            SetInstances();
            InitializeComponent();
            SetCBItems();
            LoadPrefs();
        }

        private void LoadPrefs()
        {
            textToSpeechCB.Checked = Settings.Default.textToSpeech;
            xmlPathTB.Text = Settings.Default.xmlPath;
            undoBtnCB.Text = Settings.Default.undoBtn;
            pauseBtnCB.Text = Settings.Default.pauseBtn;
            freezeCB.Text = Settings.Default.freezeTime;
        }

        private void SaveSettings()
        {
            Settings.Default.Upgrade();
            Settings.Default.textToSpeech = textToSpeech;
            Settings.Default.xmlPath = xmlPathTB.Text;
            Settings.Default.undoBtn = undoBtnCB.Text;
            Settings.Default.pauseBtn = pauseBtnCB.Text;
            Settings.Default.freezeTime = freezeCB.Text;
            Settings.Default.Save();
           

        }

        private void SetInstances()
        {
            appCoordinator = new AppCoordinator(this);
        }

        private void Go_Clicked(object sender, EventArgs e)
        {

            undoBtn = undoBtnCB.Text;
            freezeTime = double.Parse(freezeCB.Text);
            userPauseBtnName = pauseBtnCB.SelectedItem.ToString();
            startOver = startOverCB.Checked;
            goBtn.Enabled = false;
            RegistryHandler.DisableWindowsErrorReporting(true);
            SaveSettings();
            textToSpeech = textToSpeechCB.Checked;
            xmlPathsList = BreakXmlPath(xmlPathTB.Text);
            appCoordinator.StartSequence();
        }

        private string[] BreakXmlPath(string xmlPathTBText)
        {
            if (xmlPathTBText.EndsWith(".xml"))
                return new string[]{xmlPathTBText};
            return Directory.GetFiles(xmlPathTBText, "config.xml", SearchOption.AllDirectories);
        }


        internal static string[] GetxmlPathsList()
        {
            return xmlPathsList;
        }


        internal static string GetEventGohstPath()
        {
            return eventGohstPath;
        }

        internal static string GetUserPauseBtnName()
        {
            return userPauseBtnName;
        }


        //getters
        private void Browse_Xml_Path_clicked(object sender, EventArgs e){xmlPathDialog.ShowDialog();}
        private void Browse_Remote_Pic_Path_clicked(object sender, EventArgs e){remotePicDialog.ShowDialog();}
        private string TitleExporter(string fileLongStr) { return fileLongStr.ToString().Substring(fileLongStr.ToString().IndexOf("FileName: ") + 10); }

        //dialog clicks
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            xmlPathTB.Text = TitleExporter(sender.ToString());
        }


        protected void SetCBItems()
        {
            foreach (string btnName in Enum.GetNames(typeof(VirtualKeyCode))) { 
                this.pauseBtnCB.Items.Add(btnName);
                this.undoBtnCB.Items.Add(btnName);
            }

            pauseBtnCB.SelectedItem = VirtualKeyCode.LeftShift.ToString();
        }

        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }



        private void XmlPathDropHandler(object sender, DragEventArgs e)
        {
            xmlPathTB.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        }

        private void LogBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Logger.GetTxt(), Logger.TITLE);
        }

     
        private void ActionsBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(ActionsTxt.GetTxt(), ActionsTxt.TITLE);
        }

        private void evenGohstPathTB_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool TextToSpeech
        {
            get => textToSpeech;
            set => textToSpeech = value;
        }

        private void pauseBtnCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
