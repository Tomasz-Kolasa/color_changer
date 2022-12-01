using System.Text.RegularExpressions;

namespace ColorsChanger
{
    internal class GroupBoxRow
    {
        public GroupBox groupBoxRow;
        public GroupBox groupBox2;
        public Panel panelOutColourOuter;
        public Panel panelOutColour;
        public TextBox tbOutputColouroOrig;
        public TextBox tbOutputColourHTML;
        public TextBox tbArrow;
        public Panel panelInColourOuter;
        public Panel panelInColour;
        public TextBox tbInputColourOrig;
        public TextBox tbInputColourHTML;

        public GroupBoxRow()
        {
            this.groupBoxRow = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelOutColourOuter = new System.Windows.Forms.Panel();
            this.panelOutColour = new System.Windows.Forms.Panel();
            this.tbOutputColouroOrig = new System.Windows.Forms.TextBox();
            this.tbOutputColourHTML = new System.Windows.Forms.TextBox();
            this.tbArrow = new System.Windows.Forms.TextBox();
            this.panelInColourOuter = new System.Windows.Forms.Panel();
            this.panelInColour = new System.Windows.Forms.Panel();
            this.tbInputColourOrig = new System.Windows.Forms.TextBox();
            this.tbInputColourHTML = new System.Windows.Forms.TextBox();
            this.groupBoxRow.SuspendLayout();
            this.panelOutColourOuter.SuspendLayout();
            this.panelInColourOuter.SuspendLayout();

            // 
            // groupBoxRow
            // 
            this.groupBoxRow.Controls.Add(this.groupBox2);
            this.groupBoxRow.Controls.Add(this.panelOutColourOuter);
            this.groupBoxRow.Controls.Add(this.tbOutputColouroOrig);
            this.groupBoxRow.Controls.Add(this.tbOutputColourHTML);
            this.groupBoxRow.Controls.Add(this.tbArrow);
            this.groupBoxRow.Controls.Add(this.panelInColourOuter);
            this.groupBoxRow.Controls.Add(this.tbInputColourOrig);
            this.groupBoxRow.Controls.Add(this.tbInputColourHTML);
            this.groupBoxRow.Location = new System.Drawing.Point(3, 4);
            this.groupBoxRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxRow.Name = "groupBoxRow";
            this.groupBoxRow.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxRow.Size = new System.Drawing.Size(917, 150);
            this.groupBoxRow.TabIndex = 0;
            this.groupBoxRow.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(359, 117);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(9, 11);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // panelOutColourOuter
            // 
            this.panelOutColourOuter.BackColor = System.Drawing.Color.LightGray;
            this.panelOutColourOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOutColourOuter.Controls.Add(this.panelOutColour);
            this.panelOutColourOuter.Location = new System.Drawing.Point(746, 23);
            this.panelOutColourOuter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutColourOuter.Name = "panelOutColourOuter";
            this.panelOutColourOuter.Size = new System.Drawing.Size(141, 87);
            this.panelOutColourOuter.TabIndex = 6;
            // 
            // panelOutColour
            // 
            this.panelOutColour.BackColor = System.Drawing.Color.LightGray;
            this.panelOutColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOutColour.Location = new System.Drawing.Point(16, 24);
            this.panelOutColour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelOutColour.Name = "panelOutColour";
            this.panelOutColour.Size = new System.Drawing.Size(104, 37);
            this.panelOutColour.TabIndex = 0;
            //this.panelOutColour.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // tbOutputColourRgba
            // 
            this.tbOutputColouroOrig.Location = new System.Drawing.Point(551, 83);
            this.tbOutputColouroOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbOutputColouroOrig.Name = "tbOutputColouroOrig";
            this.tbOutputColouroOrig.Size = new System.Drawing.Size(177, 27);
            this.tbOutputColouroOrig.TabIndex = 5;
            this.tbOutputColouroOrig.Text = "rgba(255, 255, 255, 255)";
            //this.tbOutputColourRgba.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // tbOutputColourHTML
            // 
            this.tbOutputColourHTML.Enabled = false;
            this.tbOutputColourHTML.Location = new System.Drawing.Point(551, 25);
            this.tbOutputColourHTML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbOutputColourHTML.Name = "tbOutputColourHTML";
            this.tbOutputColourHTML.Size = new System.Drawing.Size(177, 27);
            this.tbOutputColourHTML.TabIndex = 4;
            this.tbOutputColourHTML.Text = "0x000000";
            //this.tbOutputColourHTML.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // tbArrow
            // 
            this.tbArrow.Enabled = false;
            this.tbArrow.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbArrow.Location = new System.Drawing.Point(412, 50);
            this.tbArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbArrow.Name = "tbArrow";
            this.tbArrow.Size = new System.Drawing.Size(82, 39);
            this.tbArrow.TabIndex = 3;
            this.tbArrow.Text = "-->";
            this.tbArrow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //this.tbArrow.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // panelInColourOuter
            // 
            this.panelInColourOuter.BackColor = System.Drawing.Color.LightGray;
            this.panelInColourOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInColourOuter.Controls.Add(this.panelInColour);
            this.panelInColourOuter.Location = new System.Drawing.Point(191, 25);
            this.panelInColourOuter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelInColourOuter.Name = "panelInColourOuter";
            this.panelInColourOuter.Size = new System.Drawing.Size(141, 87);
            this.panelInColourOuter.TabIndex = 2;
            // 
            // panelInColour
            // 
            this.panelInColour.BackColor = System.Drawing.Color.LightGray;
            this.panelInColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInColour.Location = new System.Drawing.Point(16, 24);
            this.panelInColour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelInColour.Name = "panelInColour";
            this.panelInColour.Size = new System.Drawing.Size(104, 37);
            this.panelInColour.TabIndex = 0;
            // 
            // tbInputColourRgba
            // 
            this.tbInputColourOrig.Enabled = false;
            this.tbInputColourOrig.Location = new System.Drawing.Point(7, 83);
            this.tbInputColourOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInputColourOrig.Name = "tbInputColourRgba";
            this.tbInputColourOrig.Size = new System.Drawing.Size(162, 27);
            this.tbInputColourOrig.TabIndex = 1;
            // 
            // tbInputColourHTML
            // 
            this.tbInputColourHTML.Enabled = false;
            this.tbInputColourHTML.Location = new System.Drawing.Point(7, 25);
            this.tbInputColourHTML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInputColourHTML.Name = "tbInputColourHTML";
            this.tbInputColourHTML.Size = new System.Drawing.Size(162, 27);
            this.tbInputColourHTML.TabIndex = 0;
        }

        public GroupBox GetRow()
        {
            return this.groupBoxRow;
        }
    }
}
