using AutoMapper;
using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IEmpresaService : IEntityServiceBase<EmpresaDTO>
    {

    }
    public class EmpresaService : IEntityServiceBase<EmpresaDTO>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IPeriodoCorrelativoRepository _periodoCorrelativoRepository;
   
        public EmpresaService(IEmpresaRepository empresaRepository, 
            IPeriodoCorrelativoRepository periodoCorrelativoRepository)
        {
            _empresaRepository = empresaRepository;
            _periodoCorrelativoRepository = periodoCorrelativoRepository;
           
        }
        public void Create(EmpresaDTO entity)
        {
            try
            {
              
                Empresa empresa = Mapper.Map<Empresa>(entity);
                _empresaRepository.Insert(empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(EmpresaDTO entity)
        {
            try
            {
                Empresa empresa = Mapper.Map<Empresa>(entity);
                _empresaRepository.Update(empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(EmpresaDTO entity)
        {
            try
            {
                Empresa empresa = Mapper.Map<Empresa>(entity);
                _empresaRepository.Delete(empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmpresaDTO GetById(int id)
        {
            try
            {
                Empresa empresa = _empresaRepository.GetById(id);
                EmpresaDTO empresaDTO = Mapper.Map<EmpresaDTO>(empresa);
                return empresaDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmpresaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<EmpresaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Empresa> empresaList = _empresaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<EmpresaDTO> empresaDTOList = Mapper.Map<List<Empresa>, List<EmpresaDTO>>(empresaList);

                return empresaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmpresaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(EmpresaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
