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
    public interface IMarcaService : IEntityServiceBase<MarcaDTO>
    {

    }
    public class MarcaService : IEntityServiceBase<MarcaDTO>, IMarcaService
    {
        private IMarcaRepository marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        public void Create(MarcaDTO entity)
        {
            try
            {

                Marca marca = Mapper.Map<Marca>(entity);
                marcaRepository.Insert(marca);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(MarcaDTO entity)
        {
            throw new NotImplementedException();
        }

        public MarcaDTO GetById(int id)
        {
            try
            {
                Marca categoria = marcaRepository.GetById(id);
                MarcaDTO marcaDTO = Mapper.Map<MarcaDTO>(categoria);
                return marcaDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string[] Insert(MarcaDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Update(MarcaDTO entity)
        {
            try
            {

                Marca marca = Mapper.Map<Marca>(entity);
                marcaRepository.Update(marca);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MarcaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<MarcaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<MarcaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Marca> marcaList = marcaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<MarcaDTO> marcaDTOList = Mapper.Map<List<Marca>, List<MarcaDTO>>(marcaList);

                return marcaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
