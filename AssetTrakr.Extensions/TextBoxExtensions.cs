using System.Runtime.Versioning;

namespace AssetTrakr.Extensions
{
    [SupportedOSPlatform("windows")]
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

        /// <summary>
        /// Checks if the specific textbox is <see cref="string.IsNullOrEmpty(string?)"/> or if it's length is equal to 0 OR more than maxLength.
        /// If the value is empty or higher than maxLength it shows the user a <see cref="MessageBox"/> with an error
        /// </summary>
        /// <param name="textBox">
        /// Your <see cref="TextBox"/>
        /// </param>
        /// <param name="fieldName">
        /// The name you want to show the user in the error, i.e Email address
        /// </param>
        /// <param name="maxLength"></param>
        /// <returns>
        /// True if has error, false if not
        /// </returns>
        public static bool IsRequired(this TextBox textBox, string fieldName = "", int maxLength = 150)
        {
            if(string.IsNullOrEmpty(fieldName))
            {
                fieldName = textBox.Name;
            }

            if (textBox.Text.Length > maxLength|| textBox.Text.Length == 0)
            {
                MessageBox.Show($"{fieldName} is a required field and must be no more than {maxLength} characters.", fieldName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
