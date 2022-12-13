namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public class RgbaColour : ProjectColour
    {
        static public new string Pattern = "rgba\\((\\d{1,3}),\\s*(\\d{1,3}),\\s*(\\d{1,3}),\\s*(\\d*(?:\\.\\d+)?)\\)";
        static public new string Placeholder = @"{{#PLACEHOLDER_RGBA#}}";
        public RgbaColour(string rawValue) : base(rawValue) { }

        public RgbaColour()
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

            return $"rgba({values[0]}, {values[1]}, {values[2]}, {values[3]})";
        }
    }
}
