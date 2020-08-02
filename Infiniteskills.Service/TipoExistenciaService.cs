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
    public interface ITipoExistenciaService : IEntityServiceBase<TipoExistenciaDTO>
    {

    }
    public class TipoExistenciaService : IEntityServiceBase<TipoExistenciaDTO>, ITipoExistenciaService
    {
        private readonly ITipoExistenciaRepository _tipoProductoRepository;
   

        public TipoExistenciaService(ITipoExistenciaRepository tipoProductoRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
           
        }
        public void Create(TipoExistenciaDTO entity)
        {
            try
            {
                TipoExistencia tipoProducto = Mapper.Map<TipoExistencia>(entity);
                _tipoProductoRepository.Insert(tipoProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(TipoExistenciaDTO entity)
        {
            try
            {
                TipoExistencia tipoProducto = Mapper.Map<TipoExistencia>(entity);
                _tipoProductoRepository.Update(tipoProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(TipoExistenciaDTO entity)
        {
            try
            {
                TipoExistencia tipoProducto = Mapper.Map<TipoExistencia>(entity);
                _tipoProductoRepository.Delete(tipoProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TipoExistenciaDTO GetById(int id)
        {
            try
            {
                TipoExistencia categoria = _tipoProductoRepository.GetById(id);
                TipoExistenciaDTO tipoProductoDTO = Mapper.Map<TipoExistenciaDTO>(categoria);
                return tipoProductoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TipoExistenciaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoExistenciaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoExistencia> tipoProductoList = _tipoProductoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoExistenciaDTO> categoriaDTOList = Mapper.Map<List<TipoExistencia>, List<TipoExistenciaDTO>>(tipoProductoList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TipoExistenciaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoExistenciaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
