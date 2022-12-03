namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public abstract class ProjectColour
    {
        public string Value { get; set; } = string.Empty;

        static public string Pattern { get; set; } = string.Empty;

        public ProjectColour(string rawValue)
        {
            Value = GetStandarizedName(rawValue);
        }

        public ProjectColour()
        {
        }

        abstract public string GetStandarizedName(string rawValue);
    }
}
