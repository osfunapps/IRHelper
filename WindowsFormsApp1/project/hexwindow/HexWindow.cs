using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.project.hexwindow
{
    public partial class HexWindow : Form
    {
        private const string VALIDATE_BTN_STATE_VALIDATE = "Validate";
        private const string VALIDATE_BTN_STATE_DONE = "Done";


        private Task t;
        private IntPtr handle;
        private IHexWindowCallback callback;

        public HexWindow(IHexWindowCallback callback)
        {
            InitializeComponent();
            validateBtn.Enabled = false;
            this.callback = callback;
        }


        public void SetKeyAndHex(string key, string hex)
        {
            hexesCLB.Invoke(new MethodInvoker(delegate { hexesCLB.Items.Add(key + ": " + hex); }));
            focusBtn.Invoke(new MethodInvoker(delegate { focusBtn.Focus(); }));
        }


        public void Show()
        {
            t = Task.Run(() =>
            {
                ShowDialog();
                BringToFront();
                TopMost = true;
            });
        }



        private void DoneBtn_Click(object sender, EventArgs e)
        {
            var it = hexesCLB.CheckedItems.GetEnumerator();
            var markedItems = hexesCLB.CheckedItems.OfType<string>().ToArray();
            var markedNodesKeys = new List<string>();
            //var markedNodesKeys = markedItems.Select(item => item.Split(':')[0]).ToList();
            foreach (string markedItem in markedItems)
            {
                markedNodesKeys.Add(markedItem.Split(':')[0]);
                hexesCLB.Items.Remove(markedItem);
            }
            callback.OnValidateClicked(markedNodesKeys);
            ToggleValidateBtnEnabled(false);
            ToggleValidateBtnText();
            /*todo:
             * make marked notes list by running on all of this array and split each string with " ". By that it will be list of keys list.
             * remove the marked nodes from the list
             * change the button name to Go
             * disable Go button untill all done and is legal
             * when saying the Go btn's legal, delete the mouse notification
             * when all good call the exit (no robot interference needed)
             **/

        }

        public void ToggleValidateBtnEnabled(bool enable)
        {
            validateBtn.Invoke(new MethodInvoker(delegate { validateBtn.Enabled = enable; }));
        }


        public void ToggleValidateBtnText(int checkedItems = -1)
        {
            validateBtn.Invoke(new MethodInvoker(delegate
            {
                if (checkedItems == -1)
                    checkedItems = hexesCLB.CheckedItems.Count;

                validateBtn.Text = checkedItems > 0 ? VALIDATE_BTN_STATE_VALIDATE : VALIDATE_BTN_STATE_DONE;
                //validateBtn.Text = hexesCLB.CheckedItems.Count > 0 ? VALIDATE_BTN_STATE_VALIDATE : VALIDATE_BTN_STATE_DONE ;
            }));

        }

        private void OnItemChecked(object sender, ItemCheckEventArgs e)
        {
            int newValChecked = 0;
            if (e.NewValue != e.CurrentValue && e.NewValue == CheckState.Checked)
                newValChecked = 1;
            if (e.NewValue != e.CurrentValue && e.NewValue == CheckState.Unchecked)
                newValChecked = -1;

            var count = hexesCLB.CheckedItems.Count + newValChecked;
            ToggleValidateBtnText(count);
        }
    }

    public interface IHexWindowCallback
        {
            void OnValidateClicked(List<String> corruptNodes);
        }


    }
