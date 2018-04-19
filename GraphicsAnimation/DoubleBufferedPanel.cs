//Tellon Smith
//DoubledBufferedPanel.cs class
//Custom control derived from Panel with double buffering enabled

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program8_Graphics
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            //enable double buffer
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
        }
    }
}