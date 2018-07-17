using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.valuesparser;
using WindowsFormsApp1.project.ghost.screenhelpers.colorchecker;

namespace LayoutProject.program.values
{
    class MouseCoordinator
    {
        //instances
        private FloatingMouseWindow floatingMouseWindowForm;

        //params
        internal static string FIRST_MOUSE_NOTIF = "First Run";
        private string PAUSED = "paused...";


        //variables
        private string previousBtnTxt;

        private TextToSpeechHelper textToSpeech;


        public void ShowForm()
        {
          /*  floatingMouseWindowForm.TopMost = true;
            floatingMouseWindowForm.BringToFront();
       */ }

        public MouseCoordinator()
        {
            floatingMouseWindowForm = new FloatingMouseWindow();
            floatingMouseWindowForm.TopMost = true;
            floatingMouseWindowForm.BringToFront();
        }


        internal void ShowMouseNotification(string nodeName)
        {
            floatingMouseWindowForm.AppendMouseTxtLabel(nodeName);
        }

        public void ShowDialog()
        {
            Thread.Sleep(3200);
            Task t = Task.Run(() => {
                floatingMouseWindowForm.ShowDialog();
                floatingMouseWindowForm.BringToFront();
                floatingMouseWindowForm.TopMost = true;
            });
            
        }

        public FloatingMouseWindow GetFloatingMouseWindowForm()
        {
            return floatingMouseWindowForm;
        }

        internal void ShowUserPausedNotif(bool paused)
        {
            if (paused)
            {
                previousBtnTxt = floatingMouseWindowForm.getMouseTxtLabel().Text;
                ShowMouseNotification(PAUSED);
            }
            else
            {
                ShowMouseNotification(previousBtnTxt);
            }
        }

        public void SetMouseNotificationColor(Color color)
        {
            floatingMouseWindowForm.SetMouseNotificationColor(color);
        }
    }
}
