using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infiniteskills.Service
{
    public interface ITipoMovimientoService : IEntityServiceBase<TipoMovimientoDTO>
    {

    }
    public class TipoMovimientoService : IEntityServiceBase<TipoMovimientoDTO>, ITipoMovimientoService
    {
        private ITipoMovimientoRepository tipoMovimientoRepository;

        public TipoMovimientoService(ITipoMovimientoRepository tipoMovimientoRepository)
        {
            this.tipoMovimientoRepository = tipoMovimientoRepository;
        }
        public void Create(TipoMovimientoDTO entity)
        {
            try
            {
                TipoMovimiento tipoMovimiento = Mapper.Map<TipoMovimiento>(entity);
                tipoMovimientoRepository.Insert(tipoMovimiento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(TipoMovimientoDTO entity)
        {
            try
            {
                TipoMovimiento tipoMovimiento = Mapper.Map<TipoMovimiento>(entity);
                tipoMovimientoRepository.Update(tipoMovimiento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(TipoMovimientoDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoMovimientoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoMovimientoDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoMovimientoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<TipoMovimientoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoMovimientoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoMovimiento> tipoMovimientoList = tipoMovimientoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoMovimientoDTO> tipoMovimientoDTOList = Mapper.Map<List<TipoMovimiento>, List<TipoMovimientoDTO>>(tipoMovimientoList);

                return tipoMovimientoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
