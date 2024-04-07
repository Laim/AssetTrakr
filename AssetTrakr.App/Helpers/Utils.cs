namespace AssetTrakr.App.Helpers
{
    // TODO: Need to move this to one of the .DLL libraries but can't remember which one
    // includes win forms in it lol
    public static class Utils
    {
        public static void SetReadOnly(Control control, ToolStripMenuItem menuStripItem)
        {
            foreach (Control ctrl in control.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tbx:
                        tbx.ReadOnly = true;
                        break;

                    case ComboBox cbx:
                        cbx.Enabled = false;
                        break;

                    case Button btn:
                        btn.Visible = false;
                        break;

                    case DateTimePicker dtp:
                        dtp.Enabled = false;
                        break;

                    case LinkLabel ll:
                        ll.Visible = false;
                        break;

                    case CheckBox cbk:
                        cbk.Visible = false;
                        break;
                }

                if (ctrl.HasChildren)
                {
                    SetReadOnly(ctrl, menuStripItem);
                }
            }

            // deletetoolstripmenuitem
            menuStripItem.Enabled = false;
        }
    }
}
