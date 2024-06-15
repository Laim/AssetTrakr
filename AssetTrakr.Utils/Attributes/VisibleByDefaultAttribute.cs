namespace AssetTrakr.Utils.Attributes
{
    /// <summary>
    /// 
    ///     VisibleByDefault is a general purpose attribute that can be retreived using Reflection for use on whether or not
    ///     the property should by visible to the user by default.  For example, usage in a DataGridView for a Column Selector.
    /// 
    /// </summary>

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class VisibleByDefaultAttribute : Attribute
    {
        public bool IsVisible { get; }

        public VisibleByDefaultAttribute(bool isVisible = true)
        {
            IsVisible = isVisible;
        }
    }

}
