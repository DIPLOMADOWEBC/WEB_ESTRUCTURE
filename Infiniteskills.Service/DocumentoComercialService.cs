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
    public interface IDocumentoComercialService : IEntityServiceBase<DocumentoComercialDTO>
    {

    }
    public class DocumentoComercialService : IEntityServiceBase<DocumentoComercialDTO>, IDocumentoComercialService
    {
        private readonly IDocumentoComercialRepository _docComercialRepository;
   
        public DocumentoComercialService(IDocumentoComercialRepository docComercialRepository)
        {
            _docComercialRepository = docComercialRepository;
           
        }

        public void Create(DocumentoComercialDTO entity)
        {
            try
            {
                DocumentoComercial documentoComercial = Mapper.Map<DocumentoComercial>(entity);
                _docComercialRepository.Insert(documentoComercial);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(DocumentoComercialDTO entity)
        {
            try
            {
                DocumentoComercial documentoComercial = Mapper.Map<DocumentoComercial>(entity);
                _docComercialRepository.Update(documentoComercial);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(DocumentoComercialDTO entity)
        {
            try
            {
                DocumentoComercial documentoComercial = Mapper.Map<DocumentoComercial>(entity);
                _docComercialRepository.Delete(documentoComercial);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DocumentoComercialDTO GetById(int id)
        {
            try
            {
                DocumentoComercial documentoComercial = _docComercialRepository.GetById(id);
                DocumentoComercialDTO documentoComercialDTO = Mapper.Map<DocumentoComercialDTO>(documentoComercial);
                return documentoComercialDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DocumentoComercialDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<DocumentoComercialDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<DocumentoComercial> documentoComercialList = _docComercialRepository.SearchFor(parametersList, pageCount, orderBy);
                List<DocumentoComercialDTO> documentoComercialDTOList = Mapper.Map<List<DocumentoComercial>, List<DocumentoComercialDTO>>(documentoComercialList);

                return documentoComercialDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DocumentoComercialDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

   

     

        public string[] Insert(DocumentoComercialDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
