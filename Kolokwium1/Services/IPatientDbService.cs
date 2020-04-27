using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public interface IPatientDbService
    {
        public Patient DeletePatient(int id);
    }
}
