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
    public class ImpuestoService : IEntityServiceBase<ImpuestoDTO>, IImpuestoService
    {
        private IImpuestoRepository impuestoRepository;

        public ImpuestoService(IImpuestoRepository impuestoRepository)
        {
            this.impuestoRepository = impuestoRepository;
        }
        public void Create(ImpuestoDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImpuestoDTO entity)
        {
            throw new NotImplementedException();
        }

        public ImpuestoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(ImpuestoDTO entity)
        {
            throw new NotImplementedException();
        }

        public ImpuestoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<ImpuestoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<ImpuestoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Impuesto> lineaList = impuestoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<ImpuestoDTO> categoriaDTOList = Mapper.Map<List<Impuesto>, List<ImpuestoDTO>>(lineaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(ImpuestoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
