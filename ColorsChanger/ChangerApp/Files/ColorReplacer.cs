using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReplacer
    {
        private readonly FilesManager _filesManager;
        //private readonly List<Type> _searchedColorTypes= new List<Type>() { };
        public ColorReplacer(FilesManager filesManager)
        {
            _filesManager= filesManager;
            AddColorsTypes();
        }

        private void AddColorsTypes()
        {
            //_searchedColorTypes.AddRange(
            //    new List<Type>() { 
            //        typeof(Hex6Colour),
            //        typeof(Hex8Colour),
            //        typeof(RgbaColour),
            //        typeof(RgbColour),
            //    });
        }

        public void ReplaceColorsInFiles()
        {
            foreach(var filePath in _filesManager.GetProjectFilesPaths())
            {
                // var fileContent = File.ReadAllText(filePath);

                var fileContent = "#aaaaaa   #ffffff   #ffffffff  rgba(1,1,1,1) rgb(1,1,1)";

                var matchList = Regex.Matches(fileContent, Hex8Colour.Pattern).ToArray();
                var hex8list = matchList.Cast<Match>().Select(match => match.Value).ToList();
                fileContent = Regex.Replace(fileContent, Hex8Colour.Pattern, "{{#HEX8#}}");

                matchList = Regex.Matches(fileContent, Hex6Colour.Pattern).ToArray();
                var hex6list = matchList.Cast<Match>().Select(match => match.Value).ToList();
                fileContent = Regex.Replace(fileContent, Hex6Colour.Pattern, "{{#HEX6#}}");

                matchList = Regex.Matches(fileContent, RgbColour.Pattern).ToArray();
                var rgblist = matchList.Cast<Match>().Select(match => match.Value).ToList();
                fileContent = Regex.Replace(fileContent, RgbColour.Pattern, "{{#RGB#}}");

                matchList = Regex.Matches(fileContent, RgbaColour.Pattern).ToArray();
                var rgbalist = matchList.Cast<Match>().Select(match => match.Value).ToList();
                fileContent = Regex.Replace(fileContent, RgbaColour.Pattern, "{{#RGBA#}}");

                foreach (Match match in Regex.Matches(fileContent, Hex6Colour.Pattern))
                {
                    //(match.Value);
                    //ConvertColor.Hex6ToColor(color)
                }

                foreach (UniqueColor uniqueColor in _filesManager.GetUniqueColorsList())
                {
                    //var projColor = Activator.CreateInstance(uniqueColor.Orig.GetType());

                    
                }
            }
        }
    }
}
