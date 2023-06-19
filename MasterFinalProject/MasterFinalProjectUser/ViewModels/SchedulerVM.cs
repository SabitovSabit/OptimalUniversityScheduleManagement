using MasterFinalProjectUser.Models;

namespace MasterFinalProjectUser.ViewModels
{
    public class SchedulerVM
    {
        public bool IsTeacher { get; set; }
        
        public List<TimeDayClass> scheduers { get; set; }
    }
}
