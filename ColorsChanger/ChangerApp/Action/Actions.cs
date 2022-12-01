namespace ColorsChanger.ChangerApp.Action
{
    public class Actions
    {
        private readonly App _app;
        public Actions(App app)
        {
            _app = app;
            
        }

        /// <summary>
        /// Color change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="senderGroupBoxRow"></param>
        public void tbOutputColourRgba_Leave(object sender, EventArgs e, GroupBox senderGroupBoxRow)
        {
            //TextBox tb = (TextBox)sender;

            var action = new PutColorAction(senderGroupBoxRow);
            action.handleLeaveTextBox();
        }

        /// <summary>
        /// Handles "replace" button pressed
        /// </summary>
        public void ReplaceColors()
        {
            var uniqueColors = _app.uniqueColors;
            MessageBox.Show("ReplaceColors");
        }
    }
}
