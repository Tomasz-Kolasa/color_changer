using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Drawing;

namespace ColorsChanger.ChangerApp.Converter
{
    public static class ConvertColor
    {
        static public Color Hex6ToColor(Hex6Colour hex6Colour)
        {
            int alpha = 255;
            int red, green, blue;

            red = int.Parse( hex6Colour.StandarizedValue.Substring(1, 2), System.Globalization.NumberStyles.HexNumber );
            green = int.Parse(hex6Colour.StandarizedValue.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            blue = int.Parse(hex6Colour.StandarizedValue.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public Color Hex8ToColor(Hex8Colour hex8Colour)
        {
            int alpha, red, green, blue;

            red = int.Parse(hex8Colour.StandarizedValue.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            green = int.Parse(hex8Colour.StandarizedValue.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            blue = int.Parse(hex8Colour.StandarizedValue.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            alpha = int.Parse(hex8Colour.StandarizedValue.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(alpha, red, green, blue);
        }

        static public Color RgbaToColor(RgbaColour rgbaColour)
        {
            int alpha, red, green, blue;

            var open = rgbaColour.StandarizedValue.IndexOf("(");
            var close = rgbaColour.StandarizedValue.IndexOf(")");

            var txt = rgbaColour.StandarizedValue.Substring(open + 1, close - open - 1);

            string[] values = txt.Split(',');

            red = int.Parse(values[0].Trim());
            green = int.Parse(values[1].Trim());
            blue = int.Parse(values[2].Trim());

            float a = float.Parse(values[3].Replace(".",",").Trim());

            float colorAlphaMax = 255;

            alpha = (int)(a * colorAlphaMax);

            return Color.FromArgb(alpha, red, green, blue);
        }

        /// <summary>
        /// Translates Drawing.Color.A to alpha to Html Rgba standard (0-1 value)
        /// </summary>
        /// <param name="color">Drawing.Color color</param>
        static private string CalculateRgbaAlpha(Color color)
        {
            if (color.A == 0)
                return "0";

            double ratio = (double)color.A / (double)255;
            double a = Math.Round(ratio * (double)1, 2);

            var rgbA = a.ToString().Replace(",", ".");

            return rgbA;
        }

        static public Color RgbToColor(RgbColour rgbColour)
        {
            int alpha=255, red, green, blue;

            var open = rgbColour.StandarizedValue.IndexOf("(");
            var close = rgbColour.StandarizedValue.IndexOf(")");

            var txt = rgbColour.StandarizedValue.Substring(open + 1, close - open - 1);

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

        static public Hex8Colour DrawColorToHex8(Color color)
        {
            var alpha = color.Name.Substring(0,2);
            var rgb = color.Name.Substring(2);

            var h8val = $"#{rgb}{alpha}";

            return new Hex8Colour(h8val);
        }

        static public Hex6Colour DrawColorToHex6(Color color)
        {
            var rgb = color.Name.Substring(2);

            var h6val = $"#{rgb}";

            return new Hex6Colour(h6val);
        }

        static public RgbaColour DrawColorToRgba(Color color)
        {
            var alpha = CalculateRgbaAlpha(color);

            var red = color.R.ToString();
            var green = color.G.ToString();
            var blue = color.B.ToString();

            var val = $"rgba({red},{green},{blue},{alpha})";

            return new RgbaColour(val);
        }

        static public RgbColour DrawColorToRgb(Color color)
        {
            var red = color.R.ToString();
            var green = color.G.ToString();
            var blue = color.B.ToString();

            var val = $"rgb({red},{green},{blue})";

            return new RgbColour(val);
        }
    }
}
