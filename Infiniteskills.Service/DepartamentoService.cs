using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using AutoMapper;
using Infiniteskills.Domain;
using System.Linq;

namespace Infiniteskills.Service
{
    public interface IDepartamentoService : IEntityServiceBase<DepartamentoDTO>
    {
    }
    public class DepartamentoService : IEntityServiceBase<DepartamentoDTO>, IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
   
        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
           
        }
        public void Create(DepartamentoDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Update(DepartamentoDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(DepartamentoDTO entity)
        {
            throw new NotImplementedException();
        }

        public DepartamentoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DepartamentoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<DepartamentoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Departamento> categoriaList = _departamentoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<DepartamentoDTO> departamentoDTOList = Mapper.Map<List<Departamento>, List<DepartamentoDTO>>(categoriaList);

                return departamentoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DepartamentoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(DepartamentoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
