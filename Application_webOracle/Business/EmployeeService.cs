using Application_webOracle.Data;
using Application_webOracle.Models;
using Oracle.ManagedDataAccess.Client;

namespace Application_webOracle.Business
{
	public class EmployeeService
	{
		private readonly OracleDbContext _context;

        public EmployeeService(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            try
            {
                using (var connection = (OracleConnection)_context.CreateConnection())
                {
                    await connection.OpenAsync();
                    var query = "SELECT * FROM EMP";
                    using var command = new OracleCommand(query, connection);
                    using var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        employees.Add(new Employee
                        {
                            EmpNo = reader.GetInt32(0),
                            EName = reader.GetString(1),
                            Job = reader.GetString(2),
                            Mgr = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            HireDate = reader.GetDateTime(4),
                            Sal = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                            Comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                            DeptNo = reader.GetInt32(7)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Logger l'erreur et/ou lever une exception
                Console.WriteLine($"Erreur : {ex.Message}");
            }
            return employees;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            using var connection = (OracleConnection)_context.CreateConnection();
            await connection.OpenAsync();

            var query = @"INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO) 
                  VALUES (:EmpNo, :EName, :Job, :Mgr, :HireDate, :Sal, :Comm, :DeptNo)";
            using var command = new OracleCommand(query, connection);
            command.Parameters.Add(new OracleParameter("EmpNo", employee.EmpNo));
            command.Parameters.Add(new OracleParameter("EName", employee.EName));
            command.Parameters.Add(new OracleParameter("Job", employee.Job));
            command.Parameters.Add(new OracleParameter("Mgr", employee.Mgr));
            command.Parameters.Add(new OracleParameter("HireDate", employee.HireDate));
            command.Parameters.Add(new OracleParameter("Sal", employee.Sal));
            command.Parameters.Add(new OracleParameter("Comm", employee.Comm));
            command.Parameters.Add(new OracleParameter("DeptNo", employee.DeptNo));

            await command.ExecuteNonQueryAsync();
        }


        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            using var connection = (OracleConnection)_context.CreateConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM EMP WHERE EMPNO = :EmpNo";
            using var command = new OracleCommand(query, connection);
            command.Parameters.Add(new OracleParameter("EmpNo", id));

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Employee
                {
                    EmpNo = reader.GetInt32(0),
                    EName = reader.GetString(1),
                    Job = reader.GetString(2),
                    Mgr = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                    HireDate = reader.GetDateTime(4),
                    Sal = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                    Comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                    DeptNo = reader.GetInt32(7)
                };
            }

            return null;
        }


        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                    using var connection = (OracleConnection)_context.CreateConnection();
                    await connection.OpenAsync();

                    var query = @"UPDATE EMP 
                          SET ENAME = :EName, 
                              JOB = :Job, 
                              MGR = :Mgr, 
                              HIREDATE = :HireDate, 
                              SAL = :Sal, 
                              COMM = :Comm, 
                              DEPTNO = :DeptNo 
                          WHERE EMPNO = :EmpNo";
                    using var command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter("EName", employee.EName));
                    command.Parameters.Add(new OracleParameter("Job", employee.Job));
                    command.Parameters.Add(new OracleParameter("Mgr", employee.Mgr));
                    command.Parameters.Add(new OracleParameter("HireDate", employee.HireDate));
                    command.Parameters.Add(new OracleParameter("Sal", employee.Sal));
                    command.Parameters.Add(new OracleParameter("Comm", employee.Comm));
                    command.Parameters.Add(new OracleParameter("DeptNo", employee.DeptNo));
                    command.Parameters.Add(new OracleParameter("EmpNo", employee.EmpNo));

                    await command.ExecuteNonQueryAsync();

            }
            catch(Exception ex)
            {
                throw new ApplicationException("Erreur lors de la mise à jour de l'employé.", ex);
            }
            
        }


        public async Task DeleteEmployeeAsync(int id)
        {
            using var connection = (OracleConnection)_context.CreateConnection();
            await connection.OpenAsync();

            var query = "DELETE FROM EMP WHERE EMPNO = :EmpNo";
            using var command = new OracleCommand(query, connection);
            command.Parameters.Add(new OracleParameter("EmpNo", id));

            await command.ExecuteNonQueryAsync();
        }



    }
}
