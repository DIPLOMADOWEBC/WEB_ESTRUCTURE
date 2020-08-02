using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ISerieService:IEntityServiceBase<SerieDTO>
    {

    }
    public class SerieService : IEntityServiceBase<SerieDTO>, ISerieService
    {
        private ISerieRepository serieRepository;
        public SerieService(ISerieRepository serieRepository)
        {
            this.serieRepository = serieRepository;
        }

        public void Create(SerieDTO entity)
        {
            try
            {
                Serie serie = Mapper.Map<Serie>(entity);
                serieRepository.Insert(serie);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(SerieDTO entity)
        {
            throw new NotImplementedException();
        }

        public SerieDTO GetById(int id)
        {
            try
            {
                Serie serie = serieRepository.GetById(id);
                SerieDTO serieDTO = Mapper.Map<SerieDTO>(serie);
                return serieDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string[] Insert(SerieDTO entity)
        {
            throw new NotImplementedException();
        }

        public SerieDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<SerieDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<SerieDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Serie> clienteList = serieRepository.SearchFor(parametersList, pageCount, orderBy);
                List<SerieDTO> clienteDTOList = Mapper.Map<List<Serie>, List<SerieDTO>>(clienteList);

                return clienteDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(SerieDTO entity)
        {
            try
            {
                Serie serie = Mapper.Map<Serie>(entity);
                serieRepository.Update(serie);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
