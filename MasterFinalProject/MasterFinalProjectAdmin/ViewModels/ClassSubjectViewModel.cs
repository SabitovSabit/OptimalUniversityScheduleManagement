using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.ViewModels
{
    public class ClassSubjectViewModel
    {
        public IEnumerable<Subject> AllSubjects { get; set; }
        public IEnumerable<ClassName> AllClasses { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int Id { get; set; }


        public IEnumerable<SelectListItem> GetSubjectsSelectList(IEnumerable<Subject> subjects)
        {
            return subjects.Select((e) => new SelectListItem
                {
                    Text = e.Name.ToString(),
                    Value = e.Id.ToString(),
                    Selected= true
                });
        }
        public IEnumerable<SelectListItem> GetTeachersSelectList(IEnumerable<ClassName> teachers)
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
