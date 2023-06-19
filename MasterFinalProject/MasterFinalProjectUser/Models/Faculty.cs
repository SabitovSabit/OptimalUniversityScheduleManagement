namespace MasterFinalProjectUser.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Kafedra> Kafedras { get; set; }
    }
}
