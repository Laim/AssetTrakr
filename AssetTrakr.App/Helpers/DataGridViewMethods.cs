using AssetTrakr.Models;
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

            // Hide the non-default columns from the end user
            dgv.Columns["Id"].Visible = false;
        }
    }
}
