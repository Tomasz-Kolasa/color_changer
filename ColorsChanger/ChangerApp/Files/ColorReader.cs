using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReader
    {
        private readonly FilesManager _filesManager;
        private readonly string _readColourMarker = @"{{##readColor##}}";

        private List<UniqueColor> _uniqueColors = new List<UniqueColor>();

        public ColorReader(FilesManager filesManager)
        {
            _filesManager = filesManager;
        }


        /// <summary>
        /// read unique colors
        /// IMPORTNAT NOTE: assumed #FFFFFFFF == #FFFFFF == rgab(255,255,255) == rgba(255,255,255,1)
        /// </summary>
        public void BuildUniqueColorsList()
        {

            foreach (var file in _filesManager.GetProjectFilesPaths())
            {
                var content = File.ReadAllText(file);

                foreach (Match match in Regex.Matches(content, Hex8Colour.Pattern))
                {
                    var color = new Hex8Colour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.Hex8ToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.Hex8ToColor(color)));
                    }

                    ReplaceColorWithMarker(ref content, match.Value);
                }

                foreach (Match match in Regex.Matches(content, Hex6Colour.Pattern))
                {
                    var color = new Hex6Colour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.Hex6ToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.Hex6ToColor(color)));
                    }

                    ReplaceColorWithMarker(ref content, match.Value);
                }

                foreach (Match match in Regex.Matches(content, RgbaColour.Pattern))
                {
                    var color = new RgbaColour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.RgbaToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.RgbaToColor(color)));
                    }

                    ReplaceColorWithMarker(ref content, match.Value);
                }

                foreach (Match match in Regex.Matches(content, RgbColour.Pattern))
                {
                    var color = new RgbColour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.RgbToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.RgbToColor(color)));
                    }

                    ReplaceColorWithMarker(ref content, match.Value);
                }
            }
        }

        /// <summary>
        /// in the read file content we need to remove read colors,
        /// otherwise, for eg. reExp for #A1B2C2 will also match #A1B2C2D4
        /// </summary>
        /// <param name="content"></param>
        private void ReplaceColorWithMarker(ref string content, string color)
        {
;           content = Regex.Replace(content, Regex.Escape(color), _readColourMarker);
        }

        public List<UniqueColor> GetUniqueColorsList()
        {
            return _uniqueColors;
        }
    }
}
