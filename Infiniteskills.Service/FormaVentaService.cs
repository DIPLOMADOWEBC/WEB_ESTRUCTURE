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
    public interface IFormaVentaService:IEntityServiceBase<FormaVentaDTO>
    {

    }
    public class FormaVentaService : IEntityServiceBase<FormaVentaDTO>, IFormaVentaService
    {
        private IFormaVentaRepository formaVentaRepository;
        public FormaVentaService(IFormaVentaRepository formaVentaRepository)
        {
            this.formaVentaRepository = formaVentaRepository;
        }
        public void Create(FormaVentaDTO entity)
        {
            try
            {
                FormaVenta categoria = Mapper.Map<FormaVenta>(entity);
                formaVentaRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(FormaVentaDTO entity)
        {
            throw new NotImplementedException();
        }

        public FormaVentaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(FormaVentaDTO entity)
        {
            throw new NotImplementedException();
        }

        public FormaVentaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<FormaVentaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<FormaVentaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<FormaVenta> formaVentaList = formaVentaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<FormaVentaDTO> categoriaDTOList = Mapper.Map<List<FormaVenta>, List<FormaVentaDTO>>(formaVentaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(FormaVentaDTO entity)
        {
            try
            {
                FormaVenta categoria = Mapper.Map<FormaVenta>(entity);
                formaVentaRepository.Update(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
