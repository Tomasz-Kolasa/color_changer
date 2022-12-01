namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public class RgbaColour : ProjectColour
    {
        static public string Pattern = "rgba[(](?:\\s*0*(?:\\d\\d?(?:\\.\\d+)?(?:\\s*%)?|\\.\\d+\\s*%|100(?:\\.0*)?\\s*%|(?:1\\d\\d|2[0-4]\\d|25[0-5])(?:\\.\\d+)?)\\s*,){3}\\s*0*(?:\\.\\d+|1(?:\\.0*)?)\\s*[)]";
        public RgbaColour(string rawValue) : base(rawValue) { }
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
