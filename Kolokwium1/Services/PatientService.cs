using Kolokwium1.DTOs;
using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public class PatientService : IPatientDbService
    {
        private const string ConnectionString = "Data Source=db-mssql;Initial Catalog=s19677;Integrated Security=true";
        public Patient DeletePatient(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.AddWithValue("idPatient", id);
                    SqlTransaction transcation = connection.BeginTransaction();
                    command.Transaction = transcation;

                    // Jeżeli istnieje wpis w tabeli asocjacyjnej:
                    command.CommandText = "SELECT IdPrescription FROM Prescription WHERE IdPatient = @idPatient";          
                    SqlDataReader dr = command.ExecuteReader();
                    List<int> PrescriptionIds = new List<int>();
                    while (dr.Read())
                    {
                        PrescriptionIds.Add(Int32.Parse(dr[0].ToString()));
                    }

                    dr.Close();
                    foreach (int i in PrescriptionIds)
                    {
                        command.CommandText = "DELETE FROM Prescription_Medicament WHERE IdPrescription = " + i;
                        command.ExecuteNonQuery();  
                    }
     
                    command.CommandText = "DELETE FROM Prescription WHERE IdPatient = @idPatient";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM Patient WHERE IdPatient = @idPatient";
                    command.ExecuteNonQuery();

                    transcation.Commit();

                    return null;
                }
            }
        }
    }
}
