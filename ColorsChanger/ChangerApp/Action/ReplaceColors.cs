using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Files;
using ColorsChanger.ChangerApp.Models;
using static System.Windows.Forms.Control;

namespace ColorsChanger.ChangerApp.Action
{
    internal class ReplaceColors
    {
        private List<UniqueColor> _uniqueColors;
        private readonly ControlCollection _rows;
        private readonly FilesManager _filesManager;

        public ReplaceColors(FilesManager fm, ControlCollection rows)
        {
            _filesManager = fm;
            _uniqueColors = _filesManager.GetUniqueColorsList();
            _rows = rows;
        }

        public void Replace(bool isUseHtmlColors)
        {
            DeterminateNewColors(isUseHtmlColors);

            _filesManager.ReplaceColorsInFiles();
        }

        private void DeterminateNewColors(bool isUseHtmlColors)
        {
            foreach (GroupBox row in _rows)
            {
                var idx = _rows.IndexOf(row);

                var colorType = row.Name.Split(":")[1];
                var outHtmlColor = row.Controls.Find("tbOutputColourHTML", false)[0].Text;
                var userInputNewColor = row.Controls.Find("tbOutputColouroOrig", false)[0].Text;

                bool isUserInputColorValid = ConvertColor.IsValidColor(userInputNewColor, colorType);

                if (isUserInputColorValid && !isUseHtmlColors)
                {
                    var drawCol = ConvertColor.TypeToColor(colorType, userInputNewColor);

                    _uniqueColors.ElementAt(idx).DrawingReplace = drawCol;
                }
                else
                {
                    var drawCol = ConvertColor.TypeToColor(colorType, outHtmlColor);
                    _uniqueColors.ElementAt(idx).DrawingReplace = drawCol;
                }
            }
        }
    }
}
