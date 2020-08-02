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
    public interface IDocumentoIdentidadService : IEntityServiceBase<DocumentoIdentidadDTO>
    {

    }
    public class DocumentoIdentidadService : IEntityServiceBase<DocumentoIdentidadDTO>, IDocumentoIdentidadService
    {
        private readonly IDocumentoIdentidadRepository docIdentidadRepository;
   
        public DocumentoIdentidadService(IDocumentoIdentidadRepository docIdentidadRepository)
        {
            this.docIdentidadRepository = docIdentidadRepository;
           
        }
        public void Create(DocumentoIdentidadDTO entity)
        {
            try
            {
                DocumentoIdentidad categoria = Mapper.Map<DocumentoIdentidad>(entity);
                docIdentidadRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(DocumentoIdentidadDTO entity)
        {
            try
            {
                DocumentoIdentidad categoria = Mapper.Map<DocumentoIdentidad>(entity);
                docIdentidadRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(DocumentoIdentidadDTO entity)
        {
            throw new NotImplementedException();
        }

        public DocumentoIdentidadDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DocumentoIdentidadDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<DocumentoIdentidadDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<DocumentoIdentidad> documentoIdentidadList = docIdentidadRepository.SearchFor(parametersList, pageCount, orderBy);
                List<DocumentoIdentidadDTO> documentoIdentidadDTOList = Mapper.Map<List<DocumentoIdentidad>, List<DocumentoIdentidadDTO>>(documentoIdentidadList);

                return documentoIdentidadDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DocumentoIdentidadDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(DocumentoIdentidadDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
