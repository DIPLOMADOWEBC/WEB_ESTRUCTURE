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
    public interface IMesContableService: IEntityServiceBase<MesContableDTO>
    {

    }
    public class MesContableService : IEntityServiceBase<MesContableDTO>, IMesContableService
    {
        private IMesContableRepository mesContableRepository;
        public MesContableService(IMesContableRepository mesContableRepository)
        {
            this.mesContableRepository = mesContableRepository;
        }
        public void Create(MesContableDTO entity)
        {
            try
            {
                MesContable mesContable = Mapper.Map<MesContable>(entity);
                mesContableRepository.Insert(mesContable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(MesContableDTO entity)
        {
            try
            {
                MesContable mesContable = Mapper.Map<MesContable>(entity);
                mesContableRepository.Update(mesContable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(MesContableDTO entity)
        {
            throw new NotImplementedException();
        }

        public MesContableDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(MesContableDTO entity)
        {
            throw new NotImplementedException();
        }

        public MesContableDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<MesContableDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<MesContableDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                IEnumerable<MesContable> mesContableList = mesContableRepository.SearchFor(parametersList,pageCount,orderBy);
                IEnumerable<MesContableDTO> mesContableDTOList = Mapper.Map<IEnumerable<MesContable>, IEnumerable<MesContableDTO>>(mesContableList);

                return mesContableDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
