using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReplacer
    {
        private readonly FilesManager _filesManager;

        public ColorReplacer(FilesManager filesManager)
        {
            _filesManager = filesManager;
        }

        public void ReplaceColorsInFiles()
        {
            foreach (var filePath in _filesManager.GetProjectFilesPaths())
            {
                var fileContent = File.ReadAllText(filePath);

                var h8Arr = ExtractColorsPutPlaceholders(ref fileContent, Hex8Colour.Pattern, Hex8Colour.Placeholder);
                var h6Arr = ExtractColorsPutPlaceholders(ref fileContent, Hex6Colour.Pattern, Hex6Colour.Placeholder);
                var rgbArr = ExtractColorsPutPlaceholders(ref fileContent, RgbColour.Pattern, RgbColour.Placeholder);
                var rgbaArr = ExtractColorsPutPlaceholders(ref fileContent, RgbaColour.Pattern, RgbaColour.Placeholder);

                ReplaceHex8(ref fileContent, h8Arr);
                //ReplaceHex6(ref fileContent);
                //ReplaceRgb(ref fileContent);
                //ReplaceRgba(ref fileContent);

                // now replace the file
                // ...
            }
        }

        private string[] ExtractColorsPutPlaceholders(ref string fileContent, string pattern, string placeholder)
        {
            var matchList = Regex.Matches(fileContent, pattern).ToList();
            fileContent = Regex.Replace(fileContent, pattern, placeholder);

            var hex8Arr = matchList.Cast<Match>().Select(match => match.Value).ToArray();
            return hex8Arr;
        }

        private void ReplaceHex8(ref string fileContent, string[] h8Arr)
        {
            // loop through the list of matched hex8 colors found in a file
            for (var i = 0; i < h8Arr.Length; i++)
            {
                var hex8Color = new Hex8Colour(h8Arr[i]);

                // get a list of unique colors (also containing new colors)
                var uniqueList = _filesManager.GetUniqueColorsList();

                // for each colour found in file there is a replace color on unique colors list
                var replaceColor = uniqueList.Where(c => c.PrjOrig.StandarizedValue == hex8Color.StandarizedValue);

                // replace the color matched in the current file with new one
                h8Arr[i] = replaceColor.First().ReplaceVal;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder in file
            var rx = new Regex(Hex8Colour.Placeholder);

            foreach (var newColor in h8Arr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }
    }
}
