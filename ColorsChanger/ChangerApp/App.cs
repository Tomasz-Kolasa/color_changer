using ColorsChanger.ChangerApp.Action;
using ColorsChanger.ChangerApp.Files;
using ColorsChanger.ChangerApp.Models;

namespace ColorsChanger.ChangerApp
{
    public class App
    {
        private readonly Form1 _form;
        public List<UniqueColor> uniqueColors = new List<UniqueColor>();
        private readonly Actions _actions;
        public readonly FilesManager filesManager = new FilesManager();

        public App(Form1 form)
        {
            _form = form;
            _actions = new Actions(this);
            _form.AddActions(_actions);
        }

        public void Run()
        {
            uniqueColors = filesManager.BuildAndGetUniqueColors();
            _form.AddUniqueColorsToWinFormWindow(uniqueColors);
        }

        public Form GetForm()
        {
            return _form;
        }
    }
}
