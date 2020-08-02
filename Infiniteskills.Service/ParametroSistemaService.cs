using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface   IParametroSistemaService : IEntityServiceBase<ParametroSistemaDTO>
    {

    }
    public class ParametroSistemaService : IEntityServiceBase<ParametroSistemaDTO>, IParametroSistemaService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private  IParametroSistemaRepository parametroSistemaRepository;
        public ParametroSistemaService(IParametroSistemaRepository parametroSistemaRepository)
        {
            this.parametroSistemaRepository = parametroSistemaRepository;
        }
     

        public void Update(ParametroSistemaDTO entity)
        {
            try
            {
                ParametroSistema parametroSistema = Mapper.Map<ParametroSistema>(entity);
                parametroSistemaRepository.Update(parametroSistema);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(ParametroSistemaDTO entity)
        {
            throw new NotImplementedException();
        }

        public ParametroSistemaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            List<ParametroSistemaDTO> list = this.SearchFor(parameterList, string.Empty);
            if (list.Count == 0)
                return null;

            return list[0];
        }

        public ParametroSistemaDTO GetById(int id)
        {
            try
            {
                ParametroSistema parametroSistema = parametroSistemaRepository.GetById(id);
                ParametroSistemaDTO parametroSistemaDTO = Mapper.Map<ParametroSistemaDTO>(parametroSistema);

                return parametroSistemaDTO;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public List<ParametroSistemaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            try
            {
                List<ParametroSistema> parametroSistemaList = parametroSistemaRepository.SearchFor(parametersList, 0, orderBy);
                List<ParametroSistemaDTO> parametroSistemaDTOList = Mapper.Map<List<ParametroSistema>, List<ParametroSistemaDTO>>(parametroSistemaList);

                return parametroSistemaDTOList.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public List<ParametroSistemaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(ParametroSistemaDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Create(ParametroSistemaDTO entity)
        {
            try
            {
                ParametroSistema parametroSistema = Mapper.Map<ParametroSistema>(entity);
                parametroSistemaRepository.Insert(parametroSistema);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
