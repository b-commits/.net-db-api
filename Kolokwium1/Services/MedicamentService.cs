using Kolokwium1.DTOs;
using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public class MedicamentService : IMedicamentDbService
    {
        private const string ConnectionString = "Data Source=db-mssql;Initial Catalog=s19677;Integrated Security=true";

        public MedicamentRequest GetMedInfo(int id) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.AddWithValue("idMed", id);
                command.CommandText = "SELECT Name, Type, Description, Details, Dose, Date, DueDate, IdPatient, IdDoctor " +
                    "                  FROM Medicament m, Prescription p, Prescription_Medicament pd " +
                    "                  WHERE m.IdMedicament = pd.IdMedicament AND p.IdPrescription = pd.IdPrescription AND m.IdMedicament = @idMed";
                SqlDataReader dr = command.ExecuteReader();
                MedicamentRequest result = new MedicamentRequest();
                List<Prescription> prescriptions = new List<Prescription>();
                while (dr.Read())
                {
                    result.Name = dr[0].ToString();
                    result.Type = dr[1].ToString();
                    result.Description = dr[2].ToString();
                    prescriptions.Add(new Prescription
                    {
                        Dose = Int32.Parse(dr[4].ToString()),
                        Details = dr[3].ToString(),
                        Date = DateTime.Parse(dr[5].ToString()),
                        DueDate = DateTime.Parse(dr[6].ToString()),
                        IdPatient = Int32.Parse(dr[7].ToString()),
                        IdDoctor = Int32.Parse(dr[8].ToString()),
                    }) ;
                }
                prescriptions.OrderByDescending(x => x.Date);
                result.Prescriptions = prescriptions;

                return result;
            }
        }
    }
}
