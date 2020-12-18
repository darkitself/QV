using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QV.CustomElements
{
    public class LongClickImageButton : Xamarin.Forms.ImageButton
    {
        public event EventHandler LongPressActivated;

        public void HandleLongPress(object sender, EventArgs e)
        {
            LongPressActivated.Invoke(sender, e);
        }
    }
}
