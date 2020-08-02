using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infiniteskills.Service
{
    public interface IDistritoService : IEntityServiceBase<DistritoDTO>
    {
        IEnumerable<DistritoDTO> Ubigeo(string codigo);
    }
    public class DistritoService : IEntityServiceBase<DistritoDTO>, IDistritoService
    {
        private readonly IDistritoRepository _distritoRepository;
   
        public DistritoService(IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
           
        }
      
        public void Update(DistritoDTO entity)
        {
          
        }
        public void Delete(DistritoDTO entity)
        {
           
        }

        public void Create(DistritoDTO entity)
        {
            throw new NotImplementedException();
        }

        public DistritoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DistritoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<DistritoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Distrito> distritoList = _distritoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<DistritoDTO> distritoDTOList = Mapper.Map<List<Distrito>, List<DistritoDTO>>(distritoList);

                return distritoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DistritoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(DistritoDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistritoDTO> Ubigeo(string codigo)
        {
            try
            {
                IEnumerable<Distrito> distritoList = _distritoRepository.Ubigeo(codigo);
                IEnumerable<DistritoDTO> distritoDTOList = Mapper.Map<IEnumerable<Distrito>, IEnumerable<DistritoDTO>>(distritoList);

                return distritoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}