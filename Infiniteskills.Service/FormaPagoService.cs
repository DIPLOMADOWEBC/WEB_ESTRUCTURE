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
    public interface IFormaPagoService : IEntityServiceBase<FormaPagoDTO>
    {

    }
    public class FormaPagoService : IEntityServiceBase<FormaPagoDTO>, IFormaPagoService
    {
        private readonly IFormaPagoRepository _formaPagoRepository;
   
        public FormaPagoService(IFormaPagoRepository formaPagoRepository)
        {
            _formaPagoRepository = formaPagoRepository;
           
        }
        public void Create(FormaPagoDTO entity)
        {
            try
            {
                FormaPago formaPago = Mapper.Map<FormaPago>(entity);
                _formaPagoRepository.Insert(formaPago);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(FormaPagoDTO entity)
        {
            try
            {
                FormaPago formaPago = Mapper.Map<FormaPago>(entity);
                _formaPagoRepository.Update(formaPago);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(FormaPagoDTO entity)
        {
            try
            {
                FormaPago formaPago = Mapper.Map<FormaPago>(entity);
                _formaPagoRepository.Delete(formaPago);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FormaPagoDTO GetById(int id)
        {
            try
            {
                FormaPago formaPago = _formaPagoRepository.GetById(id);
                FormaPagoDTO formaPagoDTO = Mapper.Map<FormaPagoDTO>(formaPago);
                return formaPagoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FormaPagoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy); 
        }

        public List<FormaPagoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<FormaPago> formaPagoList = _formaPagoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<FormaPagoDTO> formaPagoDTOList = Mapper.Map<List<FormaPago>, List<FormaPagoDTO>>(formaPagoList);

                return formaPagoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FormaPagoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(FormaPagoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
