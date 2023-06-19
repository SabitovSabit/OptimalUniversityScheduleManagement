using MasterFinalProjectAdmin.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.Helpers
{
    public class DbHelper:IDbHelper
    {
        private readonly SchoolDb db;
        public DbHelper(SchoolDb db)
        {
            this.db = db;
        }
        public  IEnumerable<SelectListItem> GetClassNames()
        {
            List<SelectListItem> dropItems = new List<SelectListItem>();

            var d = db.ClassNames.ToList();
            foreach (var x in d)
            {
                dropItems.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }
            return dropItems;
        }
    }
}
