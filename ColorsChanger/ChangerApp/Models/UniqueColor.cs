using ColorsChanger.ChangerApp.Models.ReadColours;
namespace ColorsChanger.ChangerApp.Models
{
    public class UniqueColor
    {
        /// <summary>
        /// the first matched unique original color name. If the same colour is matched written in different format
        /// (e.g. #FFFFFF vs rgba(255,255,255, 1)) only the first matched format is remembered.
        /// As the app assumes #FFFFFF and rgba(255,255,255,1) to be the same colors, but can display only two: #FFFFFF & any other first matched format
        /// </summary>
        public ProjectColour Orig;
        public Color Color = new Color();

        public UniqueColor(ProjectColour orig, Color color)
        {
            Orig = orig;
            Color = color;
        }
    }
}
