namespace MasterFinalProjectAdmin.Models
{
    public class Kafedra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassName> ClassNames { get; set; }
        public ICollection<Teacher> Teachers { get; set; }


        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

    }
}
