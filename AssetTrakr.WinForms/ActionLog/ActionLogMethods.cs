using AssetTrakr.Database;
using AssetTrakr.Utils.Enums;

namespace AssetTrakr.WinForms.ActionLog
{ 
    public class ActionLogMethods
    {

        /// <summary>
        /// Logs a new 'ADDED' entry to the Action Log
        /// </summary>
        /// <param name="dbContext">
        /// The existing database context that was used to add the entity
        /// </param>
        /// <param name="category">
        /// The <see cref="ActionAlertCategory"/> of the entity
        /// </param>
        /// <param name="actionName">
        /// The name of the entity
        /// </param>
        public static void Added(DatabaseContext dbContext, ActionAlertCategory category, string actionName)
        {
            dbContext.ActionLogEntries.Add(new Models.ActionLog
            {
                ActionCategory = category,
                ActionType = ActionType.ADDED,
                ActionName = actionName,
                ActionBy = Environment.UserName,
            });

        }

        /// <summary>
        /// Logs a new 'UPDATED' entry to the Action Log
        /// </summary>
        /// <param name="dbContext">
        /// The existing database context that was used to add the entity
        /// </param>
        /// <param name="category">
        /// The <see cref="ActionAlertCategory"/> of the entity
        /// </param>
        /// <param name="actionName">
        /// The name of the entity
        /// </param>
        public static void Updated(DatabaseContext dbContext, ActionAlertCategory category, string actionName)
        {
            dbContext.ActionLogEntries.Add(new Models.ActionLog
            {
                ActionCategory = category,
                ActionType = ActionType.UPDATED,
                ActionName = actionName,
                ActionBy = Environment.UserName,
            });
        }

        /// <summary>
        /// Logs a new 'DELETED' entry to the Action Log
        /// </summary>
        /// <param name="dbContext">
        /// The existing database context that was used to add the entity
        /// </param>
        /// <param name="category">
        /// The <see cref="ActionAlertCategory"/> of the entity
        /// </param>
        /// <param name="actionName">
        /// The name of the entity
        /// </param>
        public static void Deleted(DatabaseContext dbContext, ActionAlertCategory category, string actionName)
        {
            dbContext.ActionLogEntries.Add(new Models.ActionLog
            {
                ActionCategory = category,
                ActionType = ActionType.DELETED,
                ActionName = actionName,
                ActionBy = Environment.UserName,
            });
        }

        public static void Archived(DatabaseContext dbContext, ActionAlertCategory category, string actionName)
        {
            dbContext.ActionLogEntries.Add(new Models.ActionLog
            {
                ActionCategory = category,
                ActionType = ActionType.ARCHIVED,
                ActionName = actionName,
                ActionBy = Environment.UserName,
            });
        }

        public static void Unarchived(DatabaseContext dbContext, ActionAlertCategory category, string actionName)
        {
            dbContext.ActionLogEntries.Add(new Models.ActionLog
            {
                ActionCategory = category,
                ActionType = ActionType.UNARCHIVED,
                ActionName = actionName,
                ActionBy = Environment.UserName,
            });
        }

    }
}
