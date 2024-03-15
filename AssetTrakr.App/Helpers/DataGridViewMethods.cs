using AssetTrakr.Models;
using AssetTrakr.Models.Assets;
using AssetTrakr.Extensions;
using System.ComponentModel;

namespace AssetTrakr.App.Helpers
{
    public static class DataGridViewMethods
    {
        /// <summary>
        /// Updates the DataGridView for Subscription Periods and hides the irrelevant columns
        /// </summary>
        /// <param name="periodList">
        /// BindingList of <see cref="Period"/>s
        /// </param>
        /// <param name="dgv">
        /// The DataGridView you want to modify
        /// </param>
        public static void UpdatePeriodsDataGrid(BindingList<Period> periodList, DataGridView dgv)
        {
            if (periodList == null) { return; }

            dgv.DataSource = null;
            dgv.DataSource = periodList;

            // Hide the non-default columns from the end user
            dgv.Columns["PeriodId"].Visible = false;
            dgv.Columns["CreatedDate"].Visible = false;
            dgv.Columns["UpdatedDate"].Visible = false;
            dgv.Columns["CreatedBy"].Visible = false;
            dgv.Columns["UpdatedBy"].Visible = false;
        }

        /// <summary>
        /// Updates the DataGridView for Attachments and hides the irrelevant columns
        /// </summary>
        /// <param name="attachmentList">
        /// BindingList of <see cref="Attachment"/>s
        /// </param>
        /// <param name="dgv">
        /// The DataGridView you want to modify
        /// </param>
        public static void UpdateAttachmentDataGrid(BindingList<Attachment> attachmentList, DataGridView dgv)
        {

            if (attachmentList == null) { return; }

            dgv.DataSource = null;
            dgv.DataSource = attachmentList;

            // Hide the non-default columns from the end user
            dgv.Columns["AttachmentId"].Visible = false;
            dgv.Columns["Data"].Visible = false;
            dgv.Columns["DataType"].Visible = false;
            dgv.Columns["Url"].Visible = false;
            dgv.Columns["IsUrl"].Visible = false;
            dgv.Columns["CreatedDate"].Visible = false;
            dgv.Columns["UpdatedDate"].Visible = false;
            dgv.Columns["CreatedBy"].Visible = false;
            dgv.Columns["UpdatedBy"].Visible = false;
        }

        /// <summary>
        /// Updates a generic DataGridView
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="genericList">
        /// Data to load into the DataGridView
        /// </param>
        /// <param name="dgv">
        /// The DataGridView you want to modify
        /// </param>
        public static void UpdateGenericDataGrid<T>(BindingList<T> genericList, DataGridView dgv)
        {
            if (genericList == null) { return; }

            dgv.DataSource = null;
            dgv.DataSource = genericList;
        }

        /// <summary>
        /// Updates the DataGridView for Hard Drvies and hides the irrelevant columns
        /// </summary>
        /// <param name="driveList">
        /// BindingList of <see cref="AssetHardDrive"/>s
        /// </param>
        /// <param name="dgv">
        /// The DataGridView you want to modify
        /// </param>
        public static void UpdateDriveDataGrid(BindingList<AssetHardDrive> driveList, DataGridView dgv)
        {
            if (driveList == null) { return; }

            dgv.DataSource = null;
            dgv.DataSource = driveList
                .Select(d => new
                {
                    d.AssetHardwareId,
                    d.HardDriveId,
                    d.Name,
                    Manufacturer = d.Manufacturer?.Name ?? "",
                    Size = $"{d.SizeInGB} GB",
                    Serial_Number = d.SerialNumber
                }).ToBindingList();

            // Anonymous Types ignore the DisplayName attribute in models
            // Need to do this to get the nice format
            dgv.Columns["Serial_Number"].HeaderText = "Serial Number";

            // Hide the non-default columns from the end user
            dgv.Columns["AssetHardwareId"].Visible = false;
            dgv.Columns["HardDriveId"].Visible = false;
        }

        /// <summary>
        /// Updates the DataGridView for Network Adapaters and hides the irrelevant columns
        /// </summary>
        /// <param name="networkList">
        /// BindingList of <see cref="AssetNetworkAdapter"/>s
        /// </param>
        /// <param name="dgv">
        /// The DataGridView you want to modify
        /// </param>
        public static void UpdateNetworkDataGrid(BindingList<AssetNetworkAdapter> networkList, DataGridView dgv)
        {
            if (networkList == null) { return; }

            dgv.DataSource = null;
            dgv.DataSource = networkList;

            // Hide the non-default columns from the end user
            dgv.Columns["AssetHardwareId"].Visible = false;
            dgv.Columns["NetworkAdapterId"].Visible = false;
            dgv.Columns["AssetHardware"].Visible = false;
        }
    }
}
