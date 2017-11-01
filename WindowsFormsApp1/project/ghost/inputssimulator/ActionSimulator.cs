using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace WindowsFormsApp1.project.ghost.inputssimulator
{
    class ActionSimulator
    {

        //instances
        private static InputSimulator inputSim = new InputSimulator();

        private const int CLICK_WAIT_TIME = 50;

        public static void ClickOnBtn(VirtualKeyCode virtualKeyCode)
        {
            inputSim.Keyboard.KeyPress(virtualKeyCode);
            Thread.Sleep(CLICK_WAIT_TIME);
        }


        public static void ClickLeftMouseBtn()
        {
            inputSim.Mouse.LeftButtonClick();
            Thread.Sleep(50);
        }

        public static void HoldDownOnBtn(VirtualKeyCode virtualKeyCode)
        {
            inputSim.Keyboard.KeyDown(virtualKeyCode);
            Thread.Sleep(50);
        }


        public static void ReleaseBtn(VirtualKeyCode virtualKeyCode)
        {
            inputSim.Keyboard.KeyUp(virtualKeyCode);
            Thread.Sleep(50);
        }

        public static void ClickRightMouseBtn()
        {
            inputSim.Mouse.RightButtonClick();
            Thread.Sleep(50);
        }
    }
}
