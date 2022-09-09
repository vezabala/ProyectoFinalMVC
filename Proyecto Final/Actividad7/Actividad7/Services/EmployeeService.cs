using Actividad7.Data;
using Actividad7.Models;

namespace Actividad7.Services
{
    public class EmployeeService
    {
        private readonly IRepository repository;

        public EmployeeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Create(Employee employee)
        {
            //comprobar parametros
            if (employee is null)
                throw new Exception("Empresa es nula");

            await this.repository.Save(employee);
            await this.repository.Commit();
        }

        public async Task Update(Employee employee)
        {
            this.repository.Update(employee);
            await this.repository.Commit();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await this.repository.GetAll<Employee>();
        }

        public async Task Delete(Employee employee)
        {
            this.repository.Delete(employee);
            await this.repository.Commit();
        }
    }
}
