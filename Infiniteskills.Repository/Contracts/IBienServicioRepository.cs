using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IBienServicioRepository : IRepositoryBase<BienServicio>
    {
        Task<IEnumerable<BienServicio>> ListarBienServicio(string query);
    }
}
