using System;
using System.Collections.Generic;
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


        public MouseCoordinator()
        {
            floatingMouseWindowForm = new FloatingMouseWindow();
            floatingMouseWindowForm.TopMost = true;
        }


        internal void ShowMouseNotification(string nodeName)
        {
            floatingMouseWindowForm.AppendMouseTxtLabel(nodeName);
        }

        public void ShowDialog()
        {
            Task t = Task.Run(() => {
                floatingMouseWindowForm.ShowDialog();
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
    }
}
