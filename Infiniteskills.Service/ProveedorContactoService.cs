using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IProveedorContactoService: IEntityServiceBase<ProveedorContactoDTO>
    {

    }
    public class ProveedorContactoService : IEntityServiceBase<ProveedorContactoDTO>, IProveedorContactoService
    {
        private IProveedorContactoRepository proveedorContactoRepository;
        public ProveedorContactoService(IProveedorContactoRepository proveedorContactoRepository)
        {
            this.proveedorContactoRepository = proveedorContactoRepository;
        }
        public void Create(ProveedorContactoDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProveedorContactoDTO entity)
        {
            throw new NotImplementedException();
        }

        public ProveedorContactoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(ProveedorContactoDTO entity)
        {
            throw new NotImplementedException();
        }

        public ProveedorContactoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorContactoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<ProveedorContactoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<ProveedorContacto> proveedorContactoList = proveedorContactoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<ProveedorContactoDTO> proveedorContactoDTOList = Mapper.Map<List<ProveedorContacto>, List<ProveedorContactoDTO>>(proveedorContactoList);

                return proveedorContactoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(ProveedorContactoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
