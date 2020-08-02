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
    public interface IPaisService : IEntityServiceBase<PaisDTO>
    {

    }
    public class PaisService : IEntityServiceBase<PaisDTO>, IPaisService
    {
        private readonly IPaisRepository _paisRepository;
   
        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
           
        }

        public void Create(PaisDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Update(PaisDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(PaisDTO entity)
        {
            throw new NotImplementedException();
        }

        public PaisDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PaisDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<PaisDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Pais> paisList = _paisRepository.SearchFor(parametersList, pageCount, orderBy);
                List<PaisDTO> categoriaDTOList = Mapper.Map<List<Pais>, List<PaisDTO>>(paisList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PaisDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(PaisDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
