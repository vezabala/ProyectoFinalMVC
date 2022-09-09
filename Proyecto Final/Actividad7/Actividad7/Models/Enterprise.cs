namespace Actividad7.Models
{
    public class Enterprise :Entity
    {
        public string Nit { get; private set; }

        public string Name { get; private set; }

        public string Direccion { get; private set; }

        public List<Employee> Employees { get; private set; }

        /// <summary>
        /// for
        /// </summary>
        private Enterprise() : base()
        {

        }

        private Enterprise(int id, string nit, string name, string direccion):base(id)
        {
            Nit = nit;
            Name = name;
            Direccion = direccion;
            Employees = new();
        }

        public static Enterprise Build(int id, string nit, string name, string direccion)
        {
            return new Enterprise(id, nit, name, direccion);
        }

        public void AddEmployees(Employee employee)
        {
            this.Employees.Add(employee);
        }
    }
}
