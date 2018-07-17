using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp2.project.mouse
{
    public class CursorIconManager
    {

        //instances
        private CursorIcon cursorIconChecker;
        private ICursorIconCallback cursorIconCallback;

        public CursorIconManager(ICursorIconCallback cursorIconCallback)
        {
            this.cursorIconCallback = cursorIconCallback;
            cursorIconChecker = new CursorIcon();
        }

        internal void NotifyWhenCursorChangedToBeam()
        {
            int cycles = 0;
            while (!IsCursorChangedToBeam())
            {
                cycles++;
                Thread.Sleep(300);
                if (cycles > AppForm.cyclesToWait) { 
                    return;
                }

            }


        }

        private bool IsCursorChangedToBeam()
        {
            return CursorIcon.IsCursorType(Cursors.IBeam.Handle);
        }

        public interface ICursorIconCallback
        {
        }
    }
}
