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
    public interface IContactoService : IEntityServiceBase<ContactoDTO>
    {
        void InsertarContacto(ContactoDTO contactoDTO);
        Task<IEnumerable<ContactoDTO>> ListarContacto(string query);
        Task<IEnumerable<ContactoDTO>> ListarContacto(int id);
    }
    public class ContactoService : IEntityServiceBase<ContactoDTO>, IContactoService
    {
        private IContactoRepository contactoRepository;
        public ContactoService(IContactoRepository contactoRepository)
        {
            this.contactoRepository = contactoRepository;
        }
        public void Create(ContactoDTO entity)
        {
            try
            {
                Contacto contacto = Mapper.Map<Contacto>(entity);
                contactoRepository.Insert(contacto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(ContactoDTO entity)
        {
            try
            {
                Contacto contacto = Mapper.Map<Contacto>(entity);
                contactoRepository.Update(contacto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(ContactoDTO entity)
        {
            throw new NotImplementedException();
        }

        public ContactoDTO GetById(int id)
        {
            try
            {
                Contacto contacto = contactoRepository.GetById(id);
                ContactoDTO contactoDTO = Mapper.Map<ContactoDTO>(contacto);

                return contactoDTO;
            }
            catch (Exception se)
            {

                throw se;
            }
        }

        public string[] Insert(ContactoDTO entity)
        {
            throw new NotImplementedException();
        }

        public void InsertarContacto(ContactoDTO entity)
        {
            try
            {

                Contacto contacto = Mapper.Map<Contacto>(entity);
                ProveedorContacto proveedorContacto = new ProveedorContacto();
                proveedorContacto.ProveedorId = entity.ProveedorId;
                contacto.ProveedorContacto.Add(proveedorContacto);
                contactoRepository.InsertarContacto(contacto);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ContactoDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<ContactoDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<ContactoDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Contacto> contactoList = contactoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<ContactoDTO> contactoDTOList = Mapper.Map<List<Contacto>, List<ContactoDTO>>(contactoList);

                return contactoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ContactoDTO>> ListarContacto(string query)
        {
            try
            {
                IEnumerable<Contacto> contactoList = await contactoRepository.ListarContacto(query);
                IEnumerable<ContactoDTO> contactoDTOList = Mapper.Map<IEnumerable<Contacto>, IEnumerable<ContactoDTO>>(contactoList);

                return contactoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ContactoDTO>> ListarContacto(int id)
        {
            try
            {
                IEnumerable<Contacto> contactoList = await contactoRepository.ListarContacto(id);
                IEnumerable<ContactoDTO> contactoDTOList = Mapper.Map<IEnumerable<Contacto>, IEnumerable<ContactoDTO>>(contactoList);

                return contactoDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
