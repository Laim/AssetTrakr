namespace AssetTrakr.Utils.Enums
{
    /// <summary>
    /// List of System Settings.  This is used to prevent having strings all over the place with potential
    /// spelling mistakes.
    /// 
    /// <para>
    /// Usage: nameof(SystemSettings.EnumName)
    /// </para>
    /// 
    /// <para>
    /// Example: nameof(<see cref="AutomaticBackups"/>)
    /// </para>
    /// </summary>
    public enum SystemSettings
    {
        AlertThreshold,
        AutomaticBackups,
        CheckForUpdates,
        NoAssetsAdded,
        AssetsWithoutWarranty,
        AssetsWithExpiredWarranty,
        AssetsWithWarrantyExpiringSoon,
        AssetsWithoutAttachments,
        NoLicensesAdded,
        LicensesWithExpiredSubscriptions,
        LicensesWithSubscriptionsExpiringSoon,
        LicensesWithoutAttachments,
        NoContractsAdded,
        ContractsWithoutAttachments,
        ContractsExpiringSoon
    }
}
