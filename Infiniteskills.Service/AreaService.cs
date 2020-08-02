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
    public interface IAreaService : IEntityServiceBase<AreaDTO>
    {
    }
    public class AreaService : IEntityServiceBase<AreaDTO>, IAreaService
    {
        private IAreaRepository areaRepository;
        public AreaService(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;

        }
        public void Create(AreaDTO entity)
        {
            try
            {
                Area categoria = Mapper.Map<Area>(entity);
                areaRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(AreaDTO entity)
        {
            throw new NotImplementedException();
        }

        public AreaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(AreaDTO entity)
        {
            throw new NotImplementedException();
        }

        public AreaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<AreaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<AreaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Area> categoriaList = areaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<AreaDTO> categoriaDTOList = Mapper.Map<List<Area>, List<AreaDTO>>(categoriaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(AreaDTO entity)
        {
            try
            {
                Area categoria = Mapper.Map<Area>(entity);
                areaRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
