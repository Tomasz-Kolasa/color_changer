namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public class RgbColour : ProjectColour
    {
        static public new string Pattern = "rgb\\(\\d+\\s?,\\s?\\d+\\s?,\\s?\\d+\\)";
        static public new string Placeholder = @"{{#PLACEHOLDER_RGB#}}";
        public RgbColour(string rawColor):base(rawColor)
        {

        }

        public override string GetStandarizedName(string rawColor)
        {
            var open = rawColor.IndexOf("(");
            var close = rawColor.IndexOf(")");

            var txt = rawColor.Substring(open + 1, close - open - 1);

            string[] values = txt.Split(',');

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }

            return $"rgb({values[0]}, {values[1]}, {values[2]})";
        }
    }
}
