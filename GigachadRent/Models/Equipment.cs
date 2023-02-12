using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigachadRent.Models
{
    public class Equipment
    {
        public static readonly List<Equipment> List = new();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
    }
}
