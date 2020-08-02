using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface ISucursalUsuarioRepository: IRepositoryBase<SucursalPersonal>
    {

    }
    public class SucursalUsuarioRepository : RepositoryBase<SucursalPersonal>, ISucursalUsuarioRepository
    {
        public SucursalUsuarioRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }
    }
}
