using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.DTOs
{
    public class MedicamentRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
