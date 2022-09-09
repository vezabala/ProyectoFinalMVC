using Actividad7.Data;
using Actividad7.Models;

namespace Actividad7.Services
{
    public class EnterpriseService
    {
        private readonly IRepository repository;

        public EnterpriseService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Create(Enterprise enterprise)
        {
            //comprobar parametros
            if (enterprise is null)
                throw new Exception("Empresa es nula");

            await this.repository.Save(enterprise);
            await this.repository.Commit();
        }

        public async Task Update(Enterprise enterprise)
        {
            this.repository.Update(enterprise);
            await this.repository.Commit();
        }

        public async Task<List<Enterprise>> GetAllEnterprises()
        {
            return await this.repository.GetAll<Enterprise>();
        }

        public async Task<Enterprise> GetById(int id)
        {
            return await this.repository.GetById<Enterprise>(id);
        }

        public async Task Delete(Enterprise enterprise)
        {
            this.repository.Delete(enterprise);
            await this.repository.Commit();
        }
    }
}
