using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IBienServicioService : IEntityServiceBase<BienServicioDTO>
    {
        Task<IEnumerable<BienServicioDTO>> ListarBienServicio(string query);
    }
}
