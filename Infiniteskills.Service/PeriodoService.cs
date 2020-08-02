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
    public interface IPeriodoService : IEntityServiceBase<PeriodoDTO>
    {
    }
    public class PeriodoService : IEntityServiceBase<PeriodoDTO>, IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;
   
        public PeriodoService(IPeriodoRepository periodoRepository)
        {
            _periodoRepository = periodoRepository;
           
        }
        public void Create(PeriodoDTO entity)
        {
            try
            {
                Periodo periodo = Mapper.Map<Periodo>(entity);
                _periodoRepository.Insert(periodo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(PeriodoDTO entity)
        {
            try
            {
                Periodo periodo = Mapper.Map<Periodo>(entity);
                _periodoRepository.Update(periodo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(PeriodoDTO entity)
        {
            try
            {
                Periodo periodo = Mapper.Map<Periodo>(entity);
                _periodoRepository.Delete(periodo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PeriodoDTO GetById(int id)
        {
            try
            {
                Periodo periodo = _periodoRepository.GetById(id);
                PeriodoDTO periodoDTO = Mapper.Map<PeriodoDTO>(periodo);
                return periodoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PeriodoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<PeriodoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Periodo> periodoList = _periodoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<PeriodoDTO> periodoDTOList = Mapper.Map<List<Periodo>, List<PeriodoDTO>>(periodoList);

                return periodoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PeriodoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(PeriodoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
