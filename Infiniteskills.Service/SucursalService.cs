using AutoMapper;
using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ISucursalService : IEntityServiceBase<SucursalDTO>
    {

    }
    public class SucursalService : IEntityServiceBase<SucursalDTO>, ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IPeriodoCorrelativoRepository _periodoCorrelativoRepository;

        public SucursalService(ISucursalRepository sucursalRepository, IPeriodoCorrelativoRepository periodoCorrelativoRepository)
        {
            _sucursalRepository = sucursalRepository;
            _periodoCorrelativoRepository = periodoCorrelativoRepository;

        }
        public void Create(SucursalDTO entity)
        {
            try
            {
               
                Sucursal sucursal = Mapper.Map<Sucursal>(entity);
                _sucursalRepository.Insert(sucursal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(SucursalDTO entity)
        {
            try
            {
                Sucursal sucursal = Mapper.Map<Sucursal>(entity);
                _sucursalRepository.Update(sucursal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(SucursalDTO entity)
        {
            try
            {
                Sucursal sucursal = Mapper.Map<Sucursal>(entity);
                _sucursalRepository.Delete(sucursal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SucursalDTO GetById(int id)
        {
            try
            {
                Sucursal sucursal = _sucursalRepository.GetById(id);
                SucursalDTO sucursalDTO = Mapper.Map<SucursalDTO>(sucursal);
                return sucursalDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SucursalDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<SucursalDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Sucursal> sucursalList = _sucursalRepository.SearchFor(parametersList, pageCount, orderBy);
                List<SucursalDTO> sucursalDTOList = Mapper.Map<List<Sucursal>, List<SucursalDTO>>(sucursalList);

                return sucursalDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SucursalDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(SucursalDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
