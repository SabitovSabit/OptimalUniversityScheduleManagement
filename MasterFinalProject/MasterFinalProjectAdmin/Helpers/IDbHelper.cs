using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.Helpers
{
    public interface IDbHelper
    {
        IEnumerable<SelectListItem> GetClassNames();
    }
}
