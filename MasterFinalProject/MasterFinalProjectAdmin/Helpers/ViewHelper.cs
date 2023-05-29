using MasterFinalProjectAdmin.Data;

namespace MasterFinalProjectAdmin.Helpers
{
    public class ViewHelper:IViewHelper
    {
        private readonly SchoolDb schoolDb;
        public ViewHelper(SchoolDb schoolDb) 
        {
            this.schoolDb = schoolDb;
        }
        public  string GetKafedraName(int kafedraId)
        {
            return schoolDb.Kafedras.Where(x=>x.Id==kafedraId).Select(x=>x.Name).ToString();
            
        }
        public List<string> GetAllKafedraNames()
        {
            return schoolDb.Kafedras.Select(x => x.Name).ToList();

        }
    }
}
