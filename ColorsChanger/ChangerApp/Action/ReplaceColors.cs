using ColorsChanger.ChangerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace ColorsChanger.ChangerApp.Action
{
    internal class ReplaceColors
    {
        private List<UniqueColor> _uniqueColors;
        private readonly ControlCollection _rows;

        public ReplaceColors(List<UniqueColor> uniqueColors, ControlCollection rows)
        {
            _uniqueColors = uniqueColors;
            _rows = rows;
        }

        public void Replace(bool isUseHtmlColors)
        {
            MessageBox.Show("replacing...");
        }
    }
}
