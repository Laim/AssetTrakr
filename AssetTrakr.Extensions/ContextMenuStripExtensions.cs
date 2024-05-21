namespace AssetTrakr.Extensions
{
    public static class ContextMenuStripExtensions
    {

        /// <summary>
        /// Hides all items in the ContextMenuStrip starting from the choosen startIndex
        /// </summary>
        /// <param name="cms">
        /// The ContextMenuStrip you want to modify
        /// </param>
        /// <param name="startIndex">
        /// The index within <see cref="ContextMenuStrip"/> Items that you want to hide
        /// </param>
        public static void HideItems(this ContextMenuStrip cms, int startIndex = 3)
        {
            for (int i = startIndex; i < cms.Items.Count; i++) // Start from index 1 to skip the first item
            {
                // Set the Visible property to false for each item except the first one
                cms.Items[i].Visible = false;
            }
        }

        /// <summary>
        /// Shows all items in the ContextMenuStrip starting from the choosen startIndex
        /// </summary>
        /// <param name="cms">
        /// The ContextMenuStrip you want to modify
        /// </param>
        /// <param name="startIndex">
        /// The index within <see cref="ContextMenuStrip"/> Items that you want to show
        /// </param>
        public static void ShowItems(this ContextMenuStrip cms, int startIndex = 3)
        {
            for(int i = startIndex; i < cms.Items.Count; i++)
            {
                cms.Items[i].Visible = true;
            }
        }
    }
}
