using System.ComponentModel;
using AssetTrakr.Models;

namespace AssetTrakr.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Converts a List{T} to BindingList
        /// </summary>
        /// <typeparam name="T">Type, such as <see cref="Models.Attachment"/></typeparam>
        /// <param name="source">Source data from LINQ, use .ToBindingList() where you would usually use .ToList()</param>
        /// <returns><see cref="BindingList{T}"/></returns>
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> source)
        {
            return new BindingList<T>(source.ToList());
        }

        /// <summary>
        /// Gets the required data from the SELECT, formats it as an attachment and then outputs it as a BindingList{T}
        /// </summary>
        /// <param name="attachments"></param>
        /// <returns>
        /// <see cref="BindingList{Attachment}"/>
        /// </returns>
        public static BindingList<Attachment> ToModelAttachment(this IQueryable<Attachment> attachments)
        {
            ArgumentNullException.ThrowIfNull(attachments);

            var mappedList = attachments.Select(x => new Attachment
            {
                AttachmentId = x.AttachmentId,
                Name = x.Name,
                Description = x.Description,
                Type = x.Type,
            }).ToList();

            return new BindingList<Attachment>(mappedList);
        }

        /// <summary>
        /// Gets the required data from the SELECT, formats it as an attachment and then outputs it as a BindingList{T}
        /// </summary>
        /// <param name="attachments"></param>
        /// <returns>
        /// <see cref="BindingList{SubscriptionPeriod}"/>
        /// </returns>
        public static BindingList<Period> ToModelSubscriptionPeriod(this IQueryable<Period> subscriptionPeriods)
        {
            ArgumentNullException.ThrowIfNull(subscriptionPeriods);

            var mappedList = subscriptionPeriods.Select(x => new Period
            {
                PeriodId = x.PeriodId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,

            }).ToList();

            return new BindingList<Period>(mappedList);
        }

        /// <summary>
        /// Converts a List{string} to List{string} with a blank entry at index 0
        /// </summary>
        /// <typeparam name="T">Type, such as <see cref="Attachment"/></typeparam>
        /// <param name="source">Source data from LINQ</param>
        /// <returns><see cref="List{string}"/> with blank value at index 0</returns>
        public static List<string> ToComboList(this IEnumerable<string> source)
        {
            List<string> list =
                [
                    "",
                    .. from i in source
                       select i,
                ];

            return list.ToList();
        }
    }
}
