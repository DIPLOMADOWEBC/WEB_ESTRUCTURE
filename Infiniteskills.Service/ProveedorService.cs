using System;
using System.Collections.Generic;
using Infiniteskills.Infra.Base;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using AutoMapper;
using Infiniteskills.Repository;
using Infiniteskills.Domain;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Infiniteskills.Common;

namespace Infiniteskills.Service
{
   
    public class ProveedorService : IEntityServiceBase<ProveedorDTO>, IProveedorService
    {
        private IProveedorRepository proveedorRepository;
        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            this.proveedorRepository = proveedorRepository;
        }
        public void Create(ProveedorDTO entity)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    Proveedor proveedor = Mapper.Map<Proveedor>(entity);
                    proveedorRepository.Insert(proveedor);

                    tx.Complete();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(ProveedorDTO entity)
        {
            try
            {
                Proveedor proveedor = Mapper.Map<Proveedor>(entity);
                proveedorRepository.Update(proveedor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(ProveedorDTO entity)
        {
            throw new NotImplementedException();
        }
        public ProveedorDTO GetById(int id)
        {
            try
            {
                Proveedor proveedor = proveedorRepository.GetById(id);
                ProveedorDTO proveedorDTO = Mapper.Map<ProveedorDTO>(proveedor);

                return proveedorDTO;
            }
            catch (Exception se)
            {

                throw se;
            }
        }
        public List<ProveedorDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<ProveedorDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Proveedor> proveedorList = proveedorRepository.SearchFor(parametersList, pageCount, orderBy);
                List<ProveedorDTO> proveedorDTOList = Mapper.Map<List<Proveedor>, List<ProveedorDTO>>(proveedorList);

                return proveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ProveedorDTO SearchFor(Dictionary<string, object> parameterList)
        {
            List<ProveedorDTO> list = SearchFor(parameterList, string.Empty);
            if (list.Count == 0)
                return null;

            return list[0];
        }
        public string[] Insert(ProveedorDTO entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ProveedorDTO>> ListarProveedor(string query)
        {
            try
            {
                IEnumerable<Proveedor> proveedorList = await proveedorRepository.ListarProveedor(query);
                IEnumerable<ProveedorDTO> proveedorDTOList = Mapper.Map<IEnumerable<Proveedor>, IEnumerable<ProveedorDTO>>(proveedorList);

                return proveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<ProveedorDTO>> ListarProveedor(int id)
        {
            try
            {
                IEnumerable<Proveedor> proveedorList = await proveedorRepository.ListarProveedor(id);
                IEnumerable<ProveedorDTO> proveedorDTOList = Mapper.Map<IEnumerable<Proveedor>, IEnumerable<ProveedorDTO>>(proveedorList);

                return proveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ProveedorDTO> BuscarProveedor(int id)
        {

            try
            {
                Proveedor proveedor = await proveedorRepository.BuscarProveedor(id);
                ProveedorDTO proveedorDTO = Mapper.Map<ProveedorDTO>(proveedor);
                ////proveedorDTO.DireccionDTO = proveedor.Direccion
                //    .Where(x => x.Fiscal == DireccionConstant.FISCAL).Select(x => new DireccionProveedorDTO()
                //    {
                //        DireccionId = x.DireccionId,
                //        NombreDireccion = x.NombreDireccion
                //    }).FirstOrDefault();

                return proveedorDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertarCliente(ProveedorDTO entity)
        {
            try
            {
                Proveedor proveedor = Mapper.Map<Proveedor>(entity);

                IEnumerable<Contacto> contactoList = Mapper
                    .Map<IEnumerable<ContactoDTO>,
                    IEnumerable<Contacto>>(entity.ContactoDTOList);

                //proveedor.Direccion = Mapper.Map<List<DireccionProveedorDTO>,
                //    List<DireccionProveedor>>(entity.DireccionDTOList);

                proveedorRepository.InsertarCliente(proveedor, contactoList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ActualizarCliente(ProveedorDTO entity)
        {
            try
            {
                Proveedor proveedor = Mapper.Map<Proveedor>(entity);

                IEnumerable<Contacto> contactoList = Mapper
                    .Map<IEnumerable<ContactoDTO>,
                    IEnumerable<Contacto>>(entity.ContactoDTOList);



                proveedorRepository.ActualizarCliente(proveedor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ProveedorDTO>> BuscarPorRuc(string ruc)
        {
            try
            {
                IEnumerable<Proveedor> proveedorList = await proveedorRepository.BuscarPorRuc(ruc);
                IEnumerable<ProveedorDTO> proveedorDTOList = Mapper.Map<IEnumerable<Proveedor>, IEnumerable<ProveedorDTO>>(proveedorList);

                return proveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<ProveedorDTO> BuscarPorCodigo(int id)
        {
            try
            {
                IEnumerable<Proveedor> proveedorList =  proveedorRepository.BuscarPorCodigo(id);
                IEnumerable<ProveedorDTO> proveedorDTOList = Mapper.Map<IEnumerable<Proveedor>, IEnumerable<ProveedorDTO>>(proveedorList);

                return proveedorDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
