using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReplacer
    {
        private readonly FilesManager _filesManager;

        private readonly string _placeholder = @"{{#REPLACE#}}";
        public ColorReplacer(FilesManager filesManager)
        {
            _filesManager = filesManager;
        }

        public void ReplaceColorsInFiles()
        {
            foreach (var filePath in _filesManager.GetProjectFilesPaths())
            {
                var fileContent = File.ReadAllText(filePath);

                // string fileContent = "#aaaaaa   #ffffff   #ffffffff  rgba(1,1,1,1) rgb(1,1,1)";

                ReplaceHex8(ref fileContent);
                ReplaceHex6(ref fileContent);
                ReplaceRgb(ref fileContent);
                ReplaceRgba(ref fileContent);

                // now replace the file
                // ...
            }


        }

        private void ReplaceHex8(ref string fileContent)
        {
            var matchList = Regex.Matches(fileContent, Hex8Colour.Pattern).ToList();
            var hex8Arr = matchList.Cast<Match>().Select(match => match.Value).ToArray();
            fileContent = Regex.Replace(fileContent, Hex8Colour.Pattern, _placeholder);

            // loop through the list of matched hex8 colors found in a file
            for (var i = 0; i < hex8Arr.Length; i++)
            {
                var hex8Color = new Hex8Colour(hex8Arr[i]);

                // get a list of unique colors (also containing new colors)
                var uniqueList = _filesManager.GetUniqueColorsList();

                // for each colour found in file there is a replace color on unique colors list
                var replaceColor = uniqueList.Where(c => c.Orig.Value == hex8Color.Value);

                // replace the color matched in the current file with new one
                hex8Arr[i] = replaceColor.First().ReplaceVal;
            }

            // now we have hex8Arr array of new colors to replace the placeholders _placeholder in file
            var rx = new Regex(_placeholder);

            foreach (var newColor in hex8Arr)
            {
                // always replace the first match
                fileContent = rx.Replace(fileContent, newColor, 1);
            }
        }

        private void ReplaceHex6(ref string fileContent)
        {

        }

        private void ReplaceRgb(ref string fileContent)
        {

        }

        private void ReplaceRgba(ref string fileContent)
        {

        }
    }
}
