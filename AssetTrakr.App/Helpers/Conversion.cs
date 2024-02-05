namespace AssetTrakr.App.Helpers
{
    public static class Conversion
    {
        /// <summary>
        /// Converts a string value from the database to the Index of the ComboBox.
        /// </summary>
        /// <param name="comboBox">Your ComboBox</param>
        /// <param name="value">Database String Value</param>
        /// <returns>
        /// ComboBox SelectedIndex for <paramref name="value"/> otherwise -1.
        /// </returns>
        public static int ConvertDbStringToComboId(ComboBox comboBox, string value)
        {
            if (comboBox.Items.Count == 0)
            {
                throw new Exception("comboBox contains no items");
            }

            int index = -1;
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items[i]?.ToString();

                if (item != null && item == value)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
