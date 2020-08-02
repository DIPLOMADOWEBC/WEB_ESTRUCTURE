using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ITipoBienService : IEntityServiceBase<TipoBienDTO>
    {

    }
    public class TipoBienService : IEntityServiceBase<TipoBienDTO>, ITipoBienService
    {
        private ITipoBienRepository tipoBienService;
        public TipoBienService(ITipoBienRepository tipoBienService)
        {
            this.tipoBienService = tipoBienService;
        }
        public void Create(TipoBienDTO entity)
        {
            try
            {
                TipoBien tipoBien = Mapper.Map<TipoBien>(entity);
                tipoBienService.Insert(tipoBien);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(TipoBienDTO entity)
        {
            try
            {
                TipoBien tipoBien = Mapper.Map<TipoBien>(entity);
                tipoBienService.Update(tipoBien);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(TipoBienDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoBienDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoBienDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoBienDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<TipoBienDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoBienDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoBien> tipoBienList = tipoBienService.SearchFor(parametersList, pageCount, orderBy);
                List<TipoBienDTO> tipoBienDTOList = Mapper.Map<List<TipoBien>, List<TipoBienDTO>>(tipoBienList);

                return tipoBienDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
    }
}
