using Kolokwium1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public interface IMedicamentDbService
    {
        public MedicamentRequest GetMedInfo(int id);
    }
}
