namespace ColorsChanger.ChangerApp.Models.ReadColours
{
    public abstract class ProjectColour
    {
        public string Value { get; set; } = string.Empty;

        public ProjectColour(string rawValue)
        {
            Value = GetStandarizedName(rawValue);
        }

        abstract public string GetStandarizedName(string rawValue);
    }
}
