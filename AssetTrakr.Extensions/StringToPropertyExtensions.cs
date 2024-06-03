using AssetTrakr.Logging;
using AssetTrakr.Utils.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AssetTrakr.Extensions
{
    public static class StringToPropertyExtensions
    {

        /// <summary>
        /// Get's the property Name from the Display attribute
        /// </summary>
        /// <typeparam name="T">
        /// The model you want to get the property from
        /// </typeparam>
        /// <param name="propertyName">
        /// The property name as a string
        /// </param>
        /// <example>
        /// <code>
        /// string displayName = string.GetPropertyDisplayName("IsArchived");
        /// </code>
        /// </example>
        /// <returns>
        /// Name field from Display attribute or propertyName if not found
        /// </returns>
        public static string GetPropertyDisplayName<T>(this string propertyName)
        {
            PropertyInfo? property = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name == propertyName);

            if (property == null)
            {
                return propertyName;
            }

            var displayAttribute = property?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? propertyName;
        }

        /// <summary>
        /// Get's the property visibility from the custom VisibleByDefault attribute
        /// </summary>
        /// <typeparam name="T">
        /// The model you want to get the property from
        /// </typeparam>
        /// <param name="propertyName">
        /// The property name as a string
        /// </param>
        /// <example>
        /// <code>
        /// bool vis = string.GetPropertyVisibility("IsArchived");
        /// </code>
        /// </example> 
        /// <returns>
        /// true or false (false if not found)
        /// </returns>
        public static bool GetPropertyVisibility<T>(this string propertyName)
        {
            PropertyInfo? property = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name == propertyName);

            if(property == null)
            {
                LogManager.Warning($"{property} is null", typeof(DataGridViewExtensions));
            }

            var visibilityAttribute = property?.GetCustomAttributes(typeof(VisibleByDefaultAttribute), false)
                .FirstOrDefault() as VisibleByDefaultAttribute;

            return visibilityAttribute?.IsVisible ?? false;
        }
    }
}
