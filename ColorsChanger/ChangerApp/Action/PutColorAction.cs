using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Action
{
    internal class PutColorAction
    {
        private readonly GroupBox _row;
        public PutColorAction(GroupBox row)
        {
            _row = row;
        }

        public void handleLeaveTextBox()
        {
            var colorType = _row.Name.Split(":")[1];
            var textBoxVal = _row.Controls.Find("tbOutputColouroOrig", false)[0].Text;

            if(IsValidColor(textBoxVal, colorType))
            {
                Color drawColor;

                if(colorType=="Hex6Colour")
                {
                    drawColor = ConvertColor.Hex6ToColor(new Hex6Colour(textBoxVal));
                }
                else if(colorType=="Hex8Colour")
                {
                    drawColor = ConvertColor.Hex8ToColor(new Hex8Colour(textBoxVal));
                } else if(colorType=="RgbColour")
                {
                    drawColor = ConvertColor.RgbToColor(new RgbColour(textBoxVal));
                }
                else
                {
                    drawColor = ConvertColor.RgbaToColor(new RgbaColour(textBoxVal));
                }
               

                // change row colors
                _row.Controls.Find("tbOutputColourHTML", false)[0].Text = ConvertColor.ToHtml(drawColor);
                _row.Controls.Find("panelOutColourOuter", false)[0].
                    Controls.Find("panelOutColour", false)[0].BackColor = drawColor;
            }
            else
            {
                MessageBox.Show("Nieprawidłowa wartość, kolor nie zostanie zastąpiony.");
            }

            //MessageBox.Show($"Name: {_row.Name.ToString()}, type: {colorType}");
        }

        private bool IsValidColor(string val, string type)
        {
            string pattern = "^";

            switch(type)
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
