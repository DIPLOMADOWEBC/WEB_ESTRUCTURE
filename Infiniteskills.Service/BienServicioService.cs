using AutoMapper;
using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
   
    public class BienServicioService : IEntityServiceBase<BienServicioDTO>, IBienServicioService
    {
        private readonly IBienServicioRepository _productoRepository;
        private readonly IPeriodoCorrelativoRepository _periodoCorrelativoRepository;
        public BienServicioService(IBienServicioRepository productoRepository,
            IPeriodoCorrelativoRepository periodoCorrelativoRepository)
        {
            _productoRepository = productoRepository;
            _periodoCorrelativoRepository = periodoCorrelativoRepository;
       }
        public void Create(BienServicioDTO entity)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.PRODUCTO }
                };
           
                BienServicio producto = Mapper.Map<BienServicio>(entity);
                producto.Codigo = "0001";
                _productoRepository.Insert(producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(BienServicioDTO entity)
        {
            try
            {
                BienServicio producto = Mapper.Map<BienServicio>(entity);
                _productoRepository.Update(producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(BienServicioDTO entity)
        {
            try
            {
                BienServicio producto = Mapper.Map<BienServicio>(entity);
                _productoRepository.Delete(producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public BienServicioDTO GetById(int id)
        {
            try
            {
                BienServicio producto = _productoRepository.GetById(id);
                BienServicioDTO productoDTO = Mapper.Map<BienServicioDTO>(producto);
                return productoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<BienServicioDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<BienServicioDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<BienServicio> productoList = _productoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<BienServicioDTO> productoDTOList = Mapper.Map<List<BienServicio>, List<BienServicioDTO>>(productoList);

                return productoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public BienServicioDTO SearchFor(Dictionary<string, object> parameterList)
        {
            List<BienServicioDTO> list = SearchFor(parameterList, string.Empty);
            if (list.Count == 0)
                return null;

            return list[0];
        }

        public string[] Insert(BienServicioDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BienServicioDTO>> ListarBienServicio(string query)
        {
            try
            {
                IEnumerable<BienServicio> productoList = await _productoRepository.ListarBienServicio(query);
                IEnumerable<BienServicioDTO> productoDTOList = Mapper.Map<IEnumerable<BienServicio>, IEnumerable<BienServicioDTO>>(productoList);

                return productoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
