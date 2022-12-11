using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Converter
{
    public static class ConvertColor
    {
        static public Color Hex6ToColor(Hex6Colour hex6Colour)
        {
            int alpha = 255;
            int red, green, blue;

            red = int.Parse( hex6Colour.Value.Substring(1, 2), System.Globalization.NumberStyles.HexNumber );
            green = int.Parse(hex6Colour.Value.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            blue = int.Parse(hex6Colour.Value.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public Color Hex8ToColor(Hex8Colour hex8Colour)
        {
            int alpha, red, green, blue;

            red = int.Parse(hex8Colour.Value.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            green = int.Parse(hex8Colour.Value.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            blue = int.Parse(hex8Colour.Value.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            alpha = int.Parse(hex8Colour.Value.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public Color RgbaToColor(RgbaColour rgbaColour)
        {
            int alpha, red, green, blue;

            var open = rgbaColour.Value.IndexOf("(");
            var close = rgbaColour.Value.IndexOf(")");

            var txt = rgbaColour.Value.Substring(open + 1, close - open - 1);

            string[] values = txt.Split(',');

            red = int.Parse(values[0].Trim());
            green = int.Parse(values[1].Trim());
            blue = int.Parse(values[2].Trim());

            float a = float.Parse(values[3].Replace(".",",").Trim());

            float colorAlphaMax = 255;

            alpha = (int)(a * colorAlphaMax);

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public Color RgbToColor(RgbColour rgbColour)
        {
            int alpha=255, red, green, blue;

            var open = rgbColour.Value.IndexOf("(");
            var close = rgbColour.Value.IndexOf(")");

            var txt = rgbColour.Value.Substring(open + 1, close - open - 1);

            string[] values = txt.Split(',');

            red = int.Parse(values[0].Trim());
            green = int.Parse(values[1].Trim());
            blue = int.Parse(values[2].Trim());

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public string ToHtml(Color color)
        {
            var html = ColorTranslator.ToHtml(color);

            Type t = color.GetType();

            if(color.A.ToString() != "255" )
            {
                html += color.A.ToString("X");
            }
            
            return html;
        }

        static public Color TypeToColor(string type, string val)
        {
            Color color = new Color(); 

            switch (type)
            {
                case "Hex6Colour":
                    color = Hex6ToColor(new Hex6Colour(val)); break;
                case "Hex8Colour":
                    color = Hex8ToColor(new Hex8Colour(val)); break;
                case "RgbaColour":
                    color = RgbaToColor(new RgbaColour(val)); break;
                case "RgbColour":
                    color = RgbToColor(new RgbColour(val)); break;
            }

            return color;
        }

        static public ProjectColour TypeToProjectColor(string type, string val)
        {
            ProjectColour color = new RgbColour("#FFFFFF");

            switch (type)
            {
                case "Hex6Colour":
                    color = new Hex6Colour(val); break;
                case "Hex8Colour":
                    color = new Hex8Colour(val); break;
                case "RgbaColour":
                    color = new RgbaColour(val); break;
                case "RgbColour":
                    color = new RgbColour(val); break;
            }

            return color;
        }

        static public bool IsValidColor(string val, string type)
        {
            string pattern = "^";

            switch (type)
            {
                case "Hex6Colour":
                    pattern += Hex6Colour.Pattern; break;
                case "Hex8Colour":
                    pattern += Hex8Colour.Pattern; break;
                case "RgbaColour":
                    pattern += RgbaColour.Pattern; break;
                case "RgbColour":
                    pattern += RgbColour.Pattern; break;
            }

            pattern += "$";

            return Regex.IsMatch(val, pattern);
        }
    }
}
