namespace AssetTrakr.Models.Attributes
{
    [Obsolete("Not used", true)]
    public class UserVisible : Attribute
    {
        public bool IsVisibleToUser { get; set; }
    }
}
