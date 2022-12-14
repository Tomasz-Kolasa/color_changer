using ColorsChanger.ChangerApp.Action;
using ColorsChanger.ChangerApp.Converter;
using ColorsChanger.ChangerApp.Models;

namespace ColorsChanger
{
    public partial class Form1 : Form
    {
        private Actions _actions;
        public Form1()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler((sender, e)=>_actions.button1_Click(sender, flowLayoutPanel1.Controls, checkBox1));
        }

        public void AddActions(Actions actions)
        {
            _actions = actions;
        }

        /// <summary>
        /// Lists unique colors rows in windows form
        /// </summary>
        /// <param name="uniqueColors">List of scanned unique colors</param>
        public void AddUniqueColorsToWinFormWindow(List<UniqueColor> uniqueColors)
        {
            foreach(var color in uniqueColors)
            {
                var row = new GroupBoxRow();

                var id = uniqueColors.IndexOf(color).ToString();
                var arr = color.PrjOrig.GetType().ToString().Split(".");
                var colorType = arr[arr.Length - 1];

                row.groupBoxRow.Name = id + ":" + colorType;
                    

                row.tbInputColourHTML.Text = ConvertColor.ToHtml(color.DrawingOrig, color.PrjOrig.GetType().ToString());
                row.tbInputColourOrig.Text = color.PrjOrig.StandarizedValue;
                row.panelInColour.BackColor = color.DrawingOrig;

                row.tbOutputColourHTML.Text = ConvertColor.ToHtml(color.DrawingOrig, color.PrjOrig.GetType().ToString());
                row.tbOutputColouroOrig.Text = color.PrjOrig.StandarizedValue;
                row.panelOutColour.BackColor = color.DrawingOrig;

                row.tbOutputColouroOrig.Leave += new EventHandler((sender, e) => _actions.tbOutputColourRgba_Leave(sender, e, row.groupBoxRow));

                AddRow(row.groupBoxRow);
            }

        }

        public void AddRow(GroupBox row)
        {
            flowLayoutPanel1.Controls.Add(row);
        }
    }
}