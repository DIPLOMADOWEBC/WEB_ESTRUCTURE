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
    public interface IPeriodoEmpresaService : IEntityServiceBase<PeriodoEmpresaDTO>
    {

    }
    public class PeriodoEmpresaService : IEntityServiceBase<PeriodoEmpresaDTO>, IPeriodoEmpresaService
    {
        private readonly IPeriodoEmpresaRepository _periodoEmpresaRepository;
   
        public PeriodoEmpresaService(IPeriodoEmpresaRepository periodoEmpresaRepository)
        {
            _periodoEmpresaRepository = periodoEmpresaRepository;
           
        }
        public void Create(PeriodoEmpresaDTO entity)
        {
            try
            {
                PeriodoEmpresa periodoEmpresa = Mapper.Map<PeriodoEmpresa>(entity);
                _periodoEmpresaRepository.Insert(periodoEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(PeriodoEmpresaDTO entity)
        {
            try
            {
                PeriodoEmpresa periodoEmpresa = Mapper.Map<PeriodoEmpresa>(entity);
                _periodoEmpresaRepository.Update(periodoEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(PeriodoEmpresaDTO entity)
        {
            try
            {
                PeriodoEmpresa periodoEmpresa = Mapper.Map<PeriodoEmpresa>(entity);
                _periodoEmpresaRepository.Delete(periodoEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PeriodoEmpresaDTO GetById(int id)
        {
            try
            {
                PeriodoEmpresa periodoEmpresa = _periodoEmpresaRepository.GetById(id);
                PeriodoEmpresaDTO periodoEmpresaDTO = Mapper.Map<PeriodoEmpresaDTO>(periodoEmpresa);
                return periodoEmpresaDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PeriodoEmpresaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<PeriodoEmpresaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<PeriodoEmpresa> periodoEmpresaList = _periodoEmpresaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<PeriodoEmpresaDTO> periodoEmpresaDTOList = Mapper.Map<List<PeriodoEmpresa>, List<PeriodoEmpresaDTO>>(periodoEmpresaList);

                return periodoEmpresaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PeriodoEmpresaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(PeriodoEmpresaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
