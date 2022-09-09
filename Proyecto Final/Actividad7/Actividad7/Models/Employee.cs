namespace Actividad7.Models
{
    public class Employee :Entity
    {
        public string Identification { get; private set; }

        public string Name { get; private set; }

        public DateTime FechaDeIngreso { get; private set; }

        public int EnterpriseId { get; private set; }

        public Enterprise Enterprise { get; private set; }

        /// <summary>
        /// for
        /// </summary>
        public Employee() :base()
        {

        }

        private Employee(int id, string identification, string name, DateTime fechaDeIngreso, int enterpriseId) : base(id)
        {
            Identification = identification;
            Name = name;
            FechaDeIngreso = fechaDeIngreso;
            EnterpriseId = enterpriseId;
        }

        public static Employee Build(int id, string identification, string name, 
            DateTime fechaDeIngreso, int enterpriseId)
        {
            return new Employee(id, identification, name, fechaDeIngreso, enterpriseId);
        }
    }
}
