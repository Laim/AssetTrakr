using System.ComponentModel;
using AssetTrakr.Models.System;

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
        /// Checks if the system setting is enabled
        /// </summary>
        /// <param name="source">
        /// source DbSet
        /// </param>
        /// <param name="settingName">
        /// Setting you are looking for
        /// </param>
        /// <returns>
        /// true if enabled, else false
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> is missing
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if settingName is <see cref="string.IsNullOrWhiteSpace(string?)"/>
        /// </exception>
        public static bool WhereEnabled(this IQueryable<SystemSetting> source, string settingName)
        {
            ArgumentNullException.ThrowIfNull(nameof(source));

            if (string.IsNullOrWhiteSpace(settingName))
            {
                throw new ArgumentException("Setting name cannot be null or empty.", nameof(settingName));
            }

            // Use Any to check if any elements match the predicate
            return source.Any(ss => ss.Name == settingName && ss.Enabled);
        }
    }
}
