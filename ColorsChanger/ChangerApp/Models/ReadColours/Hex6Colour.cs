namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public class Hex6Colour : ProjectColour
    {
        public Hex6Colour(string rawValue) : base(rawValue) { }

        static public new string Pattern = "#[A-Fa-f0-9]{6}";

        public override string GetStandarizedName(string rawValue)
        {
            return rawValue;
        }
    }
}
