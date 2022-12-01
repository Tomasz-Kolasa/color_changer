using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models;
using ColorsChanger.ChangerApp.Models.ReadColours;
using System.Text.RegularExpressions;

namespace ColorsChanger.ChangerApp.Files
{
    internal class ColorReader
    {
        private readonly string _projectPath = string.Empty;
        private List<UniqueColor> _uniqueColors = new List<UniqueColor>();
        private string[] _files = new string[] { };

        public ColorReader(string projectPath)
        {
            _projectPath = projectPath;
            _files = Directory.GetFiles(_projectPath, "*.*", SearchOption.AllDirectories);
        }

        public void BuildUniqueColorsList()
        {

            foreach (var file in _files)
            {
                var content = File.ReadAllText(file);

                foreach (Match match in Regex.Matches(content, Hex6Colour.Pattern))
                {
                    var color = new Hex6Colour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.Hex6ToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.Hex6ToColor(color)));
                    }
                }

                foreach (Match match in Regex.Matches(content, Hex8Colour.Pattern))
                {
                    var color = new Hex8Colour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.Hex8ToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.Hex8ToColor(color)));
                    }
                }

                foreach (Match match in Regex.Matches(content, RgbaColour.Pattern))
                {
                    var color = new RgbaColour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.RgbaToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.RgbaToColor(color)));
                    }
                }

                foreach (Match match in Regex.Matches(content, RgbColour.Pattern))
                {
                    var color = new RgbColour(match.Value);

                    if (_uniqueColors.Where(c => c.Color.Equals(ConvertColor.RgbToColor(color))).ToList().Count == 0)
                    {
                        _uniqueColors.Add(new UniqueColor(color, ConvertColor.RgbToColor(color)));
                    }
                }
            }
        }

        public List<UniqueColor> GetUniqueColorsList()
        {
            return _uniqueColors;
        }
    }
}
