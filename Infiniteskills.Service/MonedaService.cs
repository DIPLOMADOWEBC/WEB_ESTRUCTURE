using Infiniteskills.Infra.Base;
using Infiniteskills.Infra.Core;
using Infiniteskills.Repository;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using AutoMapper;
using Infiniteskills.Domain;
using System.Linq;

namespace Infiniteskills.Service
{
    public interface IMonedaService : IEntityServiceBase<MonedaDTO>
    {

    }
    public class MonedaService : IEntityServiceBase<MonedaDTO>, IMonedaService
    {
        private IMonedaRepository _monedaRepository;

        public MonedaService(IMonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }
        public void Create(MonedaDTO entity)
        {
            try
            {
                Moneda categoria = Mapper.Map<Moneda>(entity);
                _monedaRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(MonedaDTO entity)
        {
            try
            {
                Moneda categoria = Mapper.Map<Moneda>(entity);
                _monedaRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(MonedaDTO entity)
        {
            throw new NotImplementedException();
        }

        public MonedaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(MonedaDTO entity)
        {
            throw new NotImplementedException();
        }

        public MonedaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<MonedaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<MonedaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Moneda> monedaList = _monedaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<MonedaDTO> monedaDTOList = Mapper.Map<List<Moneda>, List<MonedaDTO>>(monedaList);

                return monedaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
    }
}
