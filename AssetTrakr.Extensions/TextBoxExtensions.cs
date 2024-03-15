namespace AssetTrakr.Extensions
{
    public static class TextBoxExtensions
    {
        /// <summary>
        /// Checks if the specific textbox is <see cref="string.IsNullOrEmpty(string?)"/> or if it's length is less than 1.  If the value is empty
        /// it shows the user a <see cref="MessageBox"/> with an error
        /// </summary>
        /// <param name="textBox">
        /// Your <see cref="TextBox"/>
        /// </param>
        /// <param name="fieldName">
        /// The name you want to show the user in the error, i.e Email address
        /// </param>
        /// <returns>
        /// True if empty, false if not
        /// </returns>
        public static bool IsEmpty(this TextBox textBox, string fieldName = "")
        {
            if(string.IsNullOrEmpty(fieldName))
            {
                fieldName = textBox.Name;
            }

            if(textBox.Text.Length < 1 || string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show($"{fieldName} is a required field", fieldName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
