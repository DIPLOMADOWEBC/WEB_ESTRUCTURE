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
    public interface ITablaService : IEntityServiceBase<TablaDTO>
    {

    }
    public class TablaService : IEntityServiceBase<TablaDTO>, ITablaService
    {
        private readonly ITablaRepository _tablaRepository;
   
        public TablaService(ITablaRepository tablaRepository)
        {
            _tablaRepository = tablaRepository;
           
        }
        public void Create(TablaDTO entity)
        {
            try
            {
                Tabla tabla = Mapper.Map<Tabla>(entity);
                _tablaRepository.Insert(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(TablaDTO entity)
        {
            try
            {
                Tabla tabla = Mapper.Map<Tabla>(entity);
                _tablaRepository.Update(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TablaDTO entity)
        {
            try
            {
                Tabla tabla = Mapper.Map<Tabla>(entity);
                _tablaRepository.Delete(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TablaDTO GetById(int id)
        {
            try
            {
                Tabla tabla = _tablaRepository.GetById(id);
                TablaDTO tablaDTO = Mapper.Map<TablaDTO>(tabla);
                return tablaDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TablaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TablaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Tabla> tablaList = _tablaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TablaDTO> tablaDTOList = Mapper.Map<List<Tabla>, List<TablaDTO>>(tablaList);

                return tablaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TablaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TablaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
