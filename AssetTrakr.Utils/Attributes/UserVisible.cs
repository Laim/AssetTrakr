namespace AssetTrakr.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UserVisible : Attribute
    {
        public bool IsVisibleToUser { get; set; }
    }
}
