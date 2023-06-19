using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.ViewModels
{
    public class TeacherSubjectViewModel
    {
        public IEnumerable<Subject> AllSubjects { get; set; }
        public IEnumerable<Teacher> AllTeachers { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public IEnumerable<SelectListItem> GetSubjectsSelectList(IEnumerable<Subject> subjects)
        {
            return subjects.Select((e) => new SelectListItem
                {
                    Text = e.Name.ToString(),
                    Value = e.Id.ToString(),
                    Selected= true
                });
        }
        public IEnumerable<SelectListItem> GetTeachersSelectList(IEnumerable<Teacher> teachers)
        {
            return teachers.Select((e) => new SelectListItem
            {
                Text = e.Name.ToString(),
                Value = e.Id.ToString(),
                Selected = true
            });
        }

    }
}
