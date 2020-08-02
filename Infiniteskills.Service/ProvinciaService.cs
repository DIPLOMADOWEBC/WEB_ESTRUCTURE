using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiniteskills.Service
{
    public interface IProvinciaService : IEntityServiceBase<ProvinciaDTO>
    {

    }
    public class ProvinciaService : IEntityServiceBase<ProvinciaDTO>, IProvinciaService
    {
        private readonly IProvinciaRepository _provinciaRepository;
   
        public ProvinciaService(IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
           
        }
        public void Create(ProvinciaDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Update(ProvinciaDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(ProvinciaDTO entity)
        {
            throw new NotImplementedException();
        }

        public ProvinciaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProvinciaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<ProvinciaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Provincia> provinciaList = _provinciaRepository.SearchFor(parametersList, pageCount,orderBy);
                List<ProvinciaDTO> provinciaDTOList = Mapper.Map<List<Provincia>, List<ProvinciaDTO>>(provinciaList);
                return provinciaDTOList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ProvinciaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(ProvinciaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
