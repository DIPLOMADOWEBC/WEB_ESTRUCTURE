using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Repository
{
    public interface IPersonalRepository : IRepositoryBase<Personal>
    {
        Task<IEnumerable<Personal>> ListarPersonal(string nombre);
        IEnumerable<Personal> ListarPersonal(int id);
        void InsertarUsuario(Personal personal);
        Personal GetPersonalId(int id);
    }
}
