using EventHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.project.ghost.mouselistener
{
    class MouseEventListener
    {
        private IFindMouseBarPositionCallback findMouseBarPositionCallback;

        public MouseEventListener(IFindMouseBarPositionCallback findMouseBarPositionCallback)
        {
            this.findMouseBarPositionCallback = findMouseBarPositionCallback;
        }
        public void AskForRightClickOnBar()
        {
            MouseWatcher.Start();
            MouseWatcher.OnMouseInput += (s, e) =>
            {
                ExeWindowTitleReader.GetActiveWindowTitle();
                if (e.Message == EventHook.Hooks.MouseMessages.WM_RBUTTONUP) { 
                    MouseWatcher.Stop();
                }
            };
        }


        public static Point GetMousePos()
        {
            return new Point(Cursor.Position.X, Cursor.Position.Y);
        }


        public interface IFindMouseBarPositionCallback
        {
        }
    }
}
