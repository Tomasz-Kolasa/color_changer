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
        public void AddUniqueColors(List<UniqueColor> uniqueColors)
        {
            foreach(var color in uniqueColors)
            {
                var row = new GroupBoxRow();

                var id = uniqueColors.IndexOf(color).ToString();
                var arr = color.Orig.GetType().ToString().Split(".");
                var colorType = arr[arr.Length - 1];

                row.groupBoxRow.Name = id + ":" + colorType;
                    

                row.tbInputColourHTML.Text = ConvertColor.ToHtml(color.Color);
                row.tbInputColourOrig.Text = color.Orig.Value;
                row.panelInColour.BackColor = color.Color;

                row.tbOutputColourHTML.Text = ConvertColor.ToHtml(color.Color);
                row.tbOutputColouroOrig.Text = color.Orig.Value;
                row.panelOutColour.BackColor = color.Color;

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