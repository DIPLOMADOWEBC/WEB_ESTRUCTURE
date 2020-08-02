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
    public interface ILineaService : IEntityServiceBase<LineaDTO>
    {

    }
    public class LineaService : IEntityServiceBase<LineaDTO>, ILineaService
    {
        private ILineaRepository lineaRepository;
        public LineaService(ILineaRepository lineaRepository)
        {
            this.lineaRepository = lineaRepository;
        }
        public void Create(LineaDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(LineaDTO entity)
        {
            throw new NotImplementedException();
        }

        public LineaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(LineaDTO entity)
        {
            throw new NotImplementedException();
        }

        public LineaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<LineaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<LineaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Linea> lineaList = lineaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<LineaDTO> categoriaDTOList = Mapper.Map<List<Linea>, List<LineaDTO>>(lineaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(LineaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
