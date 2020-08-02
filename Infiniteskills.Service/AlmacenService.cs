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
    public interface IAlmacenService :IEntityServiceBase<AlmacenDTO>
    {
        IEnumerable<AlmacenDTO> ListarAlmacen(int sucursalId);
    }
    public class AlmacenService : IEntityServiceBase<AlmacenDTO>, IAlmacenService
    {
        private IAlmacenRepository almacenRepository;

        public AlmacenService(IAlmacenRepository almacenRepository)
        {
            this.almacenRepository = almacenRepository;
        }

        public void Create(AlmacenDTO entity)
        {
            try
            {
                Almacen almacen = Mapper.Map<Almacen>(entity);
                almacenRepository.Insert(almacen);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(AlmacenDTO entity)
        {
            throw new NotImplementedException();
        }

        public AlmacenDTO GetById(int id)
        {
            try
            {
                Almacen almacen = almacenRepository.GetById(id);
                AlmacenDTO almacenDTO = Mapper.Map<AlmacenDTO>(almacen);
                return almacenDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string[] Insert(AlmacenDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlmacenDTO> ListarAlmacen(int sucursalId)
        {
            try
            {
                IEnumerable<Almacen> categoriaList = almacenRepository.ListarAlmacen(sucursalId);
                IEnumerable<AlmacenDTO> categoriaDTOList = Mapper.Map<IEnumerable<Almacen>, IEnumerable<AlmacenDTO>>(categoriaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AlmacenDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<AlmacenDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<AlmacenDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Almacen> categoriaList = almacenRepository.SearchFor(parametersList, pageCount, orderBy);
                List<AlmacenDTO> categoriaDTOList = Mapper.Map<List<Almacen>, List<AlmacenDTO>>(categoriaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(AlmacenDTO entity)
        {
            try
            {
                Almacen almacen = Mapper.Map<Almacen>(entity);
                almacenRepository.Update(almacen);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
