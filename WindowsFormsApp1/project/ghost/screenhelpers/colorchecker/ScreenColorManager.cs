using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsFormsApp1.project.ghost;

/* this class will find the color on which the cursor stands. */
namespace WindowsFormsApp2.project.mouse
{
    public class ScreenColorManager
    {
        //instances
        private ScreenColor screenColor;

        //variables
        public static bool isAllowedToReadPixel;
        private static Point staticPoint;

        //callback
        private IScreenColorManagerCallback screenColorIdentifierCallback;
        private string TITLE_MAIN_GOHST_WINDOW = "EventGhost";

        public ScreenColorManager(IScreenColorManagerCallback screenColorIdentifierCallback)
        {
            this.screenColorIdentifierCallback = screenColorIdentifierCallback;
            screenColor = new ScreenColor();
        }


        internal void LookForGreenColor()
        {
            while (UserCommandsListener.isAllowedToReadPixel)
            {
                Thread.Sleep(200);
                Color currentOnScreenColor = screenColor.FindOnScreenColor(staticPoint);
                if (IsColorChanged(currentOnScreenColor))
                {
                    Console.WriteLine("color changed!");
                    screenColorIdentifierCallback.OnRecordBarRaised();
                    return;
                }

            }
        }


            private bool IsColorChanged(Color currentOnScreenColor)
            {
                return !(currentOnScreenColor.R == currentOnScreenColor.G && currentOnScreenColor.G == currentOnScreenColor.B);
            }


            internal static void SetMousePoint(Point point)
            {
                staticPoint = point;
            }

        }

    public interface IScreenColorManagerCallback
    {
        void OnRecordBarRaised();
    }

}

