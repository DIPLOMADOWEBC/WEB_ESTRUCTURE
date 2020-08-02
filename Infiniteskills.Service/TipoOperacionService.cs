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
    public interface ITipoOperacionService : IEntityServiceBase<TipoOperacionDTO>
    {
        TipoOperacionDTO GetTipoOperacion(string codigo);
    }
    public class TipoOperacionService : IEntityServiceBase<TipoOperacionDTO>, ITipoOperacionService
    {
        private ITipoOperacionRepository _tipoOperacionRepository;

        public TipoOperacionService(ITipoOperacionRepository tipoOperacionRepository)
        {
            _tipoOperacionRepository = tipoOperacionRepository;
        }

        public void Create(TipoOperacionDTO entity)
        {
            try
            {
                TipoOperacion tipoOperacion = Mapper.Map<TipoOperacion>(entity);
                _tipoOperacionRepository.Insert(tipoOperacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TipoOperacionDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoOperacionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TipoOperacionDTO GetTipoOperacion(string codigo)
        {
            try
            {
                TipoOperacion tipoOperacion = _tipoOperacionRepository.GetTipoOperacion(codigo);
                TipoOperacionDTO tipoOperacionDTO = Mapper.Map<TipoOperacionDTO>(tipoOperacion);
                return tipoOperacionDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string[] Insert(TipoOperacionDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoOperacionDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<TipoOperacionDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoOperacionDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoOperacion> tipoOperacionList = _tipoOperacionRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoOperacionDTO> tipoOperacionDTOList = Mapper.Map<List<TipoOperacion>, List<TipoOperacionDTO>>(tipoOperacionList);

                return tipoOperacionDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TipoOperacionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
