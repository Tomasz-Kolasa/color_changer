namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public abstract class ProjectColour
    {
        public string StandarizedValue { get; set; } = string.Empty;

        static public string Pattern { get; set; } = string.Empty;
        static public string Placeholder { get; set; } = string.Empty;

        public ProjectColour(string rawValue)
        {
            StandarizedValue = GetStandarizedName(rawValue);
        }

        public ProjectColour()
        {
        }

        abstract public string GetStandarizedName(string rawValue);

        static public string GetPlaceholder()
        {
            return Placeholder;
        }

        public string GetPattern()
        {
            return Pattern;
        }
    }
}
