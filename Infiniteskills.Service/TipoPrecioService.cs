using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ITipoPrecioService : IEntityServiceBase<TipoPrecioDTO>
    {

    }
    public class TipoPrecioService : IEntityServiceBase<TipoPrecioDTO>, ITipoPrecioService
    {
        private ITipoPrecioRepository tipoPrecioRepository;
        public TipoPrecioService(ITipoPrecioRepository tipoPrecioRepository)
        {
            this.tipoPrecioRepository = tipoPrecioRepository;
        }
        public void Create(TipoPrecioDTO entity)
        {
            try
            {
                TipoPrecio categoria = Mapper.Map<TipoPrecio>(entity);
                tipoPrecioRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TipoPrecioDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoPrecioDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoPrecioDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoPrecioDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<TipoPrecioDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoPrecioDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoPrecio> categoriaList = tipoPrecioRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoPrecioDTO> categoriaDTOList = Mapper.Map<List<TipoPrecio>, List<TipoPrecioDTO>>(categoriaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TipoPrecioDTO entity)
        {
            try
            {
                TipoPrecio categoria = Mapper.Map<TipoPrecio>(entity);
                tipoPrecioRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
