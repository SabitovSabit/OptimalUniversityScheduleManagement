namespace MasterFinalProjectAdmin.Helpers
{
    public interface IViewHelper
    {
        string GetKafedraName(int kafedraId);
        List<string> GetAllKafedraNames();
    }
}
