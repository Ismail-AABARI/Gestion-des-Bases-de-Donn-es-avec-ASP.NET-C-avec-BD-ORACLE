using Application_webOracle.Data;
using Application_webOracle.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application_webOracle.Business
{
    public class DepartmentService
    {
        private readonly OracleDbContext _context;

        public DepartmentService(OracleDbContext context)
        {
            _context = context;
        }

        // Ajouter un département
        public async Task AddDepartmentAsync(Departement department)
        {
            try
            {
                using var connection = (OracleConnection)_context.CreateConnection();
                await connection.OpenAsync();

                var command = new OracleCommand("INSERT INTO DEPT (DeptNo, Dname, LOC) VALUES (:DeptNo, :Dname, :LOC)", connection);
                command.Parameters.Add(new OracleParameter("DeptNo", department.DeptNo));
                command.Parameters.Add(new OracleParameter("Dname", department.DName));
                command.Parameters.Add(new OracleParameter("LOC", department.Loc));

                await command.ExecuteNonQueryAsync();
            }
            catch (OracleException ex)
            {
                // Log l'erreur ou la lancer si nécessaire
                Console.WriteLine($"Erreur Oracle : {ex.Message}");
            }
        }

        // Récupérer tous les départements
        public async Task<IEnumerable<Departement>> GetDepartmentsAsync()
        {
            var departments = new List<Departement>();

            try
            {
                using var connection = (OracleConnection)_context.CreateConnection();
                await connection.OpenAsync();

                var command = new OracleCommand("SELECT DeptNo, Dname, LOC FROM DEPT", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        departments.Add(new Departement
                        {
                            DeptNo = reader.GetInt32(0),
                            DName = reader.GetString(1),
                            Loc = reader.GetString(2)
                        });
                    }
                }
            }
            catch (OracleException ex)
            {
                // Log l'erreur ou la lancer si nécessaire
                Console.WriteLine($"Erreur Oracle : {ex.Message}");
            }

            return departments;
        }

        // Récupérer un département par son ID (DeptNo)
        public async Task<Departement> GetDepartmentByIdAsync(int deptNo)
        {
            Departement department = null;

            try
            {
                using var connection = (OracleConnection)_context.CreateConnection();
                await connection.OpenAsync();

                var command = new OracleCommand("SELECT DeptNo, Dname, LOC FROM DEPT WHERE DeptNo = :DeptNo", connection);
                command.Parameters.Add(new OracleParameter("DeptNo", deptNo));

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        department = new Departement
                        {
                            DeptNo = reader.GetInt32(0),
                            DName = reader.GetString(1),
                            Loc = reader.GetString(2)
                        };
                    }
                }
            }
            catch (OracleException ex)
            {
                // Log l'erreur ou la lancer si nécessaire
                Console.WriteLine($"Erreur Oracle : {ex.Message}");
            }

            return department;
        }

        // Mettre à jour un département
        public async Task UpdateDepartmentAsync(Departement department)
        {
            try
            {
                using var connection = (OracleConnection)_context.CreateConnection();
                await connection.OpenAsync();

                var command = new OracleCommand("UPDATE DEPT SET Dname = :Dname, LOC = :LOC WHERE DeptNo = :DeptNo", connection);
                command.Parameters.Add(new OracleParameter("DeptNo", department.DeptNo));
                command.Parameters.Add(new OracleParameter("Dname", department.DName));
                command.Parameters.Add(new OracleParameter("LOC", department.Loc));

                try
                {
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Mise à jour réussie");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Erreur Oracle : {ex.Message}");
                }

            }
            catch (OracleException ex)
            {
                // Log l'erreur ou la lancer si nécessaire
                Console.WriteLine($"Erreur Oracle : {ex.Message}");
            }
        }

        // Supprimer un département
        public async Task DeleteDepartmentAsync(int deptNo)
        {
            try
            {
                using var connection = (OracleConnection)_context.CreateConnection();
                await connection.OpenAsync();

                var command = new OracleCommand("DELETE FROM DEPT WHERE DeptNo = :DeptNo", connection);
                command.Parameters.Add(new OracleParameter("DeptNo", deptNo));

                await command.ExecuteNonQueryAsync();
            }
            catch (OracleException ex)
            {
                // Log l'erreur ou la lancer si nécessaire
                Console.WriteLine($"Erreur Oracle : {ex.Message}");
            }
        }
    }
}
