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
    public interface IPeriodoCorrelativoService : IEntityServiceBase<PeriodoCorrelativoDTO>
    {
        string ObtenerCorrelativo(Dictionary<string, object> parameterList);
    }
    public class PeriodoCorrelativoService : IEntityServiceBase<PeriodoCorrelativoDTO>, IPeriodoCorrelativoService
    {
        private readonly IPeriodoCorrelativoRepository _periodoCorrelativoRepository;
        private readonly ITablaRepository _tablaRepository;
   
        public PeriodoCorrelativoService(IPeriodoCorrelativoRepository periodoCorrelativoRepository, 
            ITablaRepository tablaRepository)
        {
            _periodoCorrelativoRepository = periodoCorrelativoRepository;
            _tablaRepository = tablaRepository;
           
        }
        public void Create(PeriodoCorrelativoDTO entity)
        {
            try
            {
                PeriodoCorrelativo periodoCorrelativo = Mapper.Map<PeriodoCorrelativo>(entity);
                _periodoCorrelativoRepository.Insert(periodoCorrelativo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(PeriodoCorrelativoDTO entity)
        {
            try
            {
                PeriodoCorrelativo periodoCorrelativo = Mapper.Map<PeriodoCorrelativo>(entity);
                _periodoCorrelativoRepository.Update(periodoCorrelativo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(PeriodoCorrelativoDTO entity)
        {
            try
            {
                PeriodoCorrelativo periodoCorrelativo = Mapper.Map<PeriodoCorrelativo>(entity);
                _periodoCorrelativoRepository.Delete(periodoCorrelativo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public PeriodoCorrelativoDTO GetById(int id)
        {
            try
            {
                PeriodoCorrelativo periodoCorrelativo = _periodoCorrelativoRepository.GetById(id);
                PeriodoCorrelativoDTO periodoCorrelativoDTO = Mapper.Map<PeriodoCorrelativoDTO>(periodoCorrelativo);
                return periodoCorrelativoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PeriodoCorrelativoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<PeriodoCorrelativoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<PeriodoCorrelativo> periodoCorrelativoList = _periodoCorrelativoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<PeriodoCorrelativoDTO> periodoCorrelativoDTOList = Mapper.Map<List<PeriodoCorrelativo>, List<PeriodoCorrelativoDTO>>(periodoCorrelativoList);

                return periodoCorrelativoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string ObtenerCorrelativo(Dictionary<string, object> parameterList)
        {
            string codigoTabla = parameterList["tabla"].ToString();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
          
            //Tabla tabla = _tablaRepository.GetTablaForCodigo(codigoTabla);

            return null;
        }
        public PeriodoCorrelativoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(PeriodoCorrelativoDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
