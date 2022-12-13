using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public class Hex8Colour : ProjectColour
    {
        static public new string Pattern = "#[A-Fa-f0-9]{8}";
        static public new string Placeholder = @"{{#PLACEHOLDER_H8#}}";
        public Hex8Colour(string rawValue) : base(rawValue) { }

        public override string GetStandarizedName(string rawValue)
        {
            return rawValue.ToLower();
        }
    }
}
