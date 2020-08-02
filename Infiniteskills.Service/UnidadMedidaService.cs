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
    public interface IUnidadMedidaService : IEntityServiceBase<UnidadMedidaDTO>
    {

    }
    public class UnidadMedidaService : IEntityServiceBase<UnidadMedidaDTO>,IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository unidadMedidaRepository;
   
        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository)
        {
            this.unidadMedidaRepository = unidadMedidaRepository;
           
        }

        public void Create(UnidadMedidaDTO entity)
        {
            try
            {
                UnidadMedida categoria = Mapper.Map<UnidadMedida>(entity);
                unidadMedidaRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(UnidadMedidaDTO entity)
        {
            try
            {
                UnidadMedida categoria = Mapper.Map<UnidadMedida>(entity);
                unidadMedidaRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(UnidadMedidaDTO entity)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }
        public UnidadMedidaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<UnidadMedidaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, string.Empty);
        }
        public List<UnidadMedidaDTO> SearchFor(Dictionary<string, object> parametersList, int pageSize, string orderBy)
        {
            try
            {
                List<UnidadMedida> UnidadMedidaList = unidadMedidaRepository.SearchFor(parametersList, pageSize, orderBy);
                List<UnidadMedidaDTO> UnidadMedidaDTOList = Mapper.Map<List<UnidadMedida>, List<UnidadMedidaDTO>>(UnidadMedidaList);

                return UnidadMedidaDTOList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UnidadMedidaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(UnidadMedidaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
