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
    public interface ITipoProveedorService : IEntityServiceBase<TipoProveedorDTO>
    {

    }
    public class TipoProveedorService : IEntityServiceBase<TipoProveedorDTO>, ITipoProveedorService
    {
        private readonly ITipoProveedorRepository tipoProveedorRepository;
   

        public TipoProveedorService(ITipoProveedorRepository tipoProveedorRepository)
        {
            this.tipoProveedorRepository = tipoProveedorRepository;
           
        }
        public void Create(TipoProveedorDTO entity)
        {
            try
            {
                TipoProveedor categoria = Mapper.Map<TipoProveedor>(entity);
                tipoProveedorRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TipoProveedorDTO entity)
        {
            try
            {
                TipoProveedor categoria = Mapper.Map<TipoProveedor>(entity);
                tipoProveedorRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(TipoProveedorDTO entity)
        {
            throw new NotImplementedException();
        }
        public TipoProveedorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoProveedorDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoProveedorDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoProveedor> tipoProveedorList = tipoProveedorRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoProveedorDTO> tipoProveedorDTOList = Mapper.Map<List<TipoProveedor>, List<TipoProveedorDTO>>(tipoProveedorList);

                return tipoProveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TipoProveedorDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoProveedorDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
