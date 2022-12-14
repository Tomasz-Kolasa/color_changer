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

            if(ConvertColor.IsValidColor(textBoxVal, colorType))
            {
                Color drawColor;

                if(colorType=="Hex6Colour")
                {
                    drawColor = ConvertColor.Hex6ToColor(new Hex6Colour(textBoxVal));
                }
                else if(colorType=="Hex8Colour")
                {
                    if(textBoxVal.Length != 9) throw new Exception("Invalid Hex8 Pattern!");

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
                _row.Controls.Find("tbOutputColourHTML", false)[0].Text =
                    ConvertColor.ToHtml(drawColor, colorType);
                _row.Controls.Find("panelOutColourOuter", false)[0].
                    Controls.Find("panelOutColour", false)[0].BackColor = drawColor;
            }
            else
            {
                MessageBox.Show($"Nieprawidłowa wartość, kolor nie zostanie zastąpiony. Wprowadź wartość koloru w pierwotnym formacie ({colorType}).");
            }
        }


    }
}
