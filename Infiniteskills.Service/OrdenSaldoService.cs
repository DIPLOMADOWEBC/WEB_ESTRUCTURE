using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IOrdenSaldoService : IEntityServiceBase<OrdenSaldoDTO>
    {
        List<OrdenSaldoDTO> ListarKardexProducto();
    }
    public class OrdenSaldoService : IEntityServiceBase<OrdenSaldoDTO>, IOrdenSaldoService
    {
        private IOrdenSaldoRepository ordenSaldoRepository;
        public OrdenSaldoService(IOrdenSaldoRepository ordenSaldoRepository)
        {
            this.ordenSaldoRepository = ordenSaldoRepository;
        }
        public void Create(OrdenSaldoDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrdenSaldoDTO entity)
        {
            throw new NotImplementedException();
        }

        public OrdenSaldoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(OrdenSaldoDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<OrdenSaldoDTO> ListarKardexProducto()
        {
            try
            {
                List<OrdenSaldo> menuList = ordenSaldoRepository.ListarKardexProducto();

                List<OrdenSaldoDTO> ordenSaldoDTOList = AutoMapper.Mapper.Map<List<OrdenSaldoDTO>>(menuList);


                return ordenSaldoDTOList.ToList();
            }
            catch (Exception ex)
            {
        
                throw ex;
            }
        }

        public OrdenSaldoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<OrdenSaldoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<OrdenSaldoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public void Update(OrdenSaldoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
