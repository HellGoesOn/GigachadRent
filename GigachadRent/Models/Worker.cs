using System.Collections.Generic;

namespace GigachadRent.Models
{
    public class Worker
    {
        public static readonly List<Worker> List = new();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }

        public string Composite => Name + $" ({Specialty})";
    }
}
