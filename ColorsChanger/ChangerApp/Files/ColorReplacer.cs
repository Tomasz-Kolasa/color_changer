using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReplacer
    {
        private readonly FilesManager _filesManager;
        private bool useHtml = false;

        public ColorReplacer(FilesManager filesManager)
        {
            _filesManager = filesManager;
        }

        public void ReplaceColorsInFiles(bool isUseHtmlColors)
        {
            useHtml= isUseHtmlColors;

            foreach (var filePath in _filesManager.GetProjectFilesPaths())
            {
                var fileContent = File.ReadAllText(filePath);

                var h8Arr = ExtractColorsPutPlaceholders(ref fileContent, Hex8Colour.Pattern, Hex8Colour.Placeholder);
                var h6Arr = ExtractColorsPutPlaceholders(ref fileContent, Hex6Colour.Pattern, Hex6Colour.Placeholder);
                var rgbArr = ExtractColorsPutPlaceholders(ref fileContent, RgbColour.Pattern, RgbColour.Placeholder);
                var rgbaArr = ExtractColorsPutPlaceholders(ref fileContent, RgbaColour.Pattern, RgbaColour.Placeholder);

                ReplaceHex8(ref fileContent, h8Arr);
                ReplaceHex6(ref fileContent, h6Arr);
                ReplaceRgb(ref fileContent, rgbArr);
                ReplaceRgba(ref fileContent, rgbaArr);

                // now replace the file
                File.WriteAllText(filePath, fileContent);
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
                var item = uniqueList.Where(uc => uc.DrawingOrig.Equals(ConvertColor.Hex8ToColor(hex8Color))).ToList();
                //var replaceColor = uniqueList.Where(c => c.PrjOrig.StandarizedValue == hex8Color.StandarizedValue);

                // replace the color with matched replacement
                var replaceDrawColor = item.First().DrawingReplace;
                var replacePrjHex8 = ConvertColor.DrawColorToHex8(replaceDrawColor);
                h8Arr[i] = replacePrjHex8.StandarizedValue;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder with
            var rx = new Regex(Hex8Colour.Placeholder);

            foreach (var newColor in h8Arr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }

        private void ReplaceHex6(ref string fileContent, string[] h6Arr)
        {
            // loop through the list of matched hex8 colors found in a file
            for (var i = 0; i < h6Arr.Length; i++)
            {
                var hex6Color = new Hex6Colour(h6Arr[i]);

                // get a list of unique colors (also containing new colors)
                var uniqueList = _filesManager.GetUniqueColorsList();

                // for each colour found in file there is a replace color on unique colors list
                var item = uniqueList.Where(uc => uc.DrawingOrig.Equals(ConvertColor.Hex6ToColor(hex6Color))).ToList();

                // replace the color with matched replacement
                var replaceDrawColor = item.First().DrawingReplace;
                var replacePrjHex6 = ConvertColor.DrawColorToHex6(replaceDrawColor);
                h6Arr[i] = replacePrjHex6.StandarizedValue;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder with
            var rx = new Regex(Hex6Colour.Placeholder);

            foreach (var newColor in h6Arr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }

        private void ReplaceRgba(ref string fileContent, string[] rgbaArr)
        {
            // loop through the list of matched hex8 colors found in a file
            for (var i = 0; i < rgbaArr.Length; i++)
            {
                var rgbaColor = new RgbaColour(rgbaArr[i]);

                // get a list of unique colors (also containing new colors)
                var uniqueList = _filesManager.GetUniqueColorsList();

                // for each colour found in file there is a replace color on unique colors list
                var item = uniqueList.Where(uc => uc.DrawingOrig.Equals(ConvertColor.RgbaToColor(rgbaColor))).ToList();

                // replace the color with matched replacement
                var replaceDrawColor = item.First().DrawingReplace;
                
                var replaceVal = useHtml ?
                    ConvertColor.DrawColorToHex8(replaceDrawColor).StandarizedValue :
                    ConvertColor.DrawColorToRgba(replaceDrawColor).StandarizedValue;
                rgbaArr[i] = replaceVal;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder with
            var rx = new Regex(RgbaColour.Placeholder);

            foreach (var newColor in rgbaArr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }

        private void ReplaceRgb(ref string fileContent, string[] rgbArr)
        {
            // loop through the list of matched hex8 colors found in a file
            for (var i = 0; i < rgbArr.Length; i++)
            {
                var rgbColor = new RgbColour(rgbArr[i]);

                // get a list of unique colors (also containing new colors)
                var uniqueList = _filesManager.GetUniqueColorsList();

                // for each colour found in file there is a replace color on unique colors list
                var item = uniqueList.Where(uc => uc.DrawingOrig.Equals(ConvertColor.RgbToColor(rgbColor))).ToList();

                // replace the color with matched replacement
                var replaceDrawColor = item.First().DrawingReplace;

                var replaceVal = useHtml ?
                    ConvertColor.DrawColorToHex8(replaceDrawColor).StandarizedValue :
                    ConvertColor.DrawColorToRgb(replaceDrawColor).StandarizedValue;
                rgbArr[i] = replaceVal;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder with
            var rx = new Regex(RgbColour.Placeholder);

            foreach (var newColor in rgbArr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }
    }
}
