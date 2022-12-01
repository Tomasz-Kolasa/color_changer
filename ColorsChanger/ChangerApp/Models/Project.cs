using ColorsChanger.ChangerApp.Models.ReadColours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsChanger.ChangerApp.Models
{
    internal class Project
    {
        private string _path { get; set; } = string.Empty;
        private List<Hex6Colour> _hex { get; set; }
        private List<RgbColour> _rgb { get; set; }
        private List<RgbaColour> _rgba { get; set; }

        public Project(string path)
        {
            _path = path;
        }
    }
}
