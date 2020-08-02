using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface IMesContableRepository:IRepositoryBase<MesContable>
    {

    }
    public class MesContableRepository : RepositoryBase<MesContable>, IMesContableRepository
    {
        public MesContableRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }
    }
}
