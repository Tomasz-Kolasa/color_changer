using ColorsChanger.ChangerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsChanger.ChangerApp.Files
{
    public class FilesManager
    {
        private ColorReader _colorReader = new ColorReader(
            Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ChangerApp","Files","src")
            );

        public FilesManager()
        {

        }

        public  List<UniqueColor> GetUniqueColors()
        {
            _colorReader.BuildUniqueColorsList();
            return _colorReader.GetUniqueColorsList();
        }
    }
}
