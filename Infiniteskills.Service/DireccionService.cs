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
    public interface IDireccionService: IEntityServiceBase<DireccionProveedorDTO>
    {

    }
    public class DireccionService : IEntityServiceBase<DireccionProveedorDTO>, IDireccionService
    {
        private IDireccionRepository direccionRepository;
        public DireccionService(IDireccionRepository direccionRepository)
        {
            this.direccionRepository = direccionRepository;
        }

        public void Create(DireccionProveedorDTO entity)
        {
            try
            {
                DireccionProveedor direccion = Mapper.Map<DireccionProveedor>(entity);
                direccionRepository.Insert(direccion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(DireccionProveedorDTO entity)
        {
            throw new NotImplementedException();
        }

        public DireccionProveedorDTO GetById(int id)
        {
            try
            {
                DireccionProveedor direccion = direccionRepository.GetById(id);
                DireccionProveedorDTO direccionDTO = Mapper.Map<DireccionProveedorDTO>(direccion);

                return direccionDTO;
            }
            catch (Exception se)
            {

                throw se;
            }
        }

        public string[] Insert(DireccionProveedorDTO entity)
        {
            throw new NotImplementedException();
        }

        public DireccionProveedorDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<DireccionProveedorDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<DireccionProveedorDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<DireccionProveedor> direccionList = direccionRepository.SearchFor(parametersList, pageCount, orderBy);
                List<DireccionProveedorDTO> direccionDTOList = Mapper.Map<List<DireccionProveedor>, List<DireccionProveedorDTO>>(direccionList);

                return direccionDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(DireccionProveedorDTO entity)
        {
            try
            {
                DireccionProveedor direccion = Mapper.Map<DireccionProveedor>(entity);
                direccionRepository.Update(direccion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
