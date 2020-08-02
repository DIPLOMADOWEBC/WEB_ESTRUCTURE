using AutoMapper;
using Infiniteskills.Common;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Repository;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Infiniteskills.Service
{
    public interface IPersonalService : IEntityServiceBase<PersonalDTO>
    {
        Task<IEnumerable<PersonalDTO>> ListarPersonal(string nombre);
       IEnumerable<PersonalDTO> ListarPersonal(int id);
        void InsertarUsuario(PersonalDTO personal);
        PersonalDTO GetPersonalId(int id);
    }
    public class PersonalService : IEntityServiceBase<PersonalDTO>, IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly IPeriodoCorrelativoRepository _periodoCorrelativoRepository;
        public PersonalService(IPersonalRepository personalRepository, 
            IPeriodoCorrelativoRepository periodoCorrelativoRepository)
        {
            _personalRepository = personalRepository;
            _periodoCorrelativoRepository = periodoCorrelativoRepository;
           
        }
        public void Create(PersonalDTO entity)
        {
            try
            {
                
                using (TransactionScope tx = new TransactionScope())
                {
                    Personal personal = Mapper.Map<Personal>(entity);
                    _personalRepository.Insert(personal);

                    tx.Complete();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(PersonalDTO entity)
        {
            try
            {
                Personal personal = Mapper.Map<Personal>(entity);
                _personalRepository.Update(personal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(PersonalDTO entity)
        {
            try
            {
                Personal personal = Mapper.Map<Personal>(entity);
                _personalRepository.Delete(personal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public PersonalDTO GetById(int id)
        {
            try
            {
                Personal personal = _personalRepository.GetById(id);
                PersonalDTO personalDTO = Mapper.Map<PersonalDTO>(personal);
                return personalDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PersonalDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<PersonalDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Personal> personalList = _personalRepository.SearchFor(parametersList, pageCount, orderBy);
                List<PersonalDTO> personalDTOList = Mapper.Map<List<Personal>, List<PersonalDTO>>(personalList);

                return personalDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public PersonalDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }
        public string[] Insert(PersonalDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonalDTO>> ListarPersonal(string nombre)
        {
            try
            {
                IEnumerable<Personal> personalList =  await _personalRepository.ListarPersonal(nombre);
                IEnumerable<PersonalDTO> personalDTOList = Mapper.Map<IEnumerable<Personal>, IEnumerable<PersonalDTO>>(personalList);

                return personalDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<PersonalDTO> ListarPersonal(int id)
        {
            try
            {
                IEnumerable<Personal> personalList =  _personalRepository.ListarPersonal(id);
                IEnumerable<PersonalDTO> personalDTOList = Mapper.Map<IEnumerable<Personal>, IEnumerable<PersonalDTO>>(personalList);

                return personalDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertarUsuario(PersonalDTO entity)
        {
            try
            {
                
                Personal personal = Mapper.Map<Personal>(entity);
                Usuario usuario = Mapper.Map<Usuario>(entity.UsuarioDTO);
                personal.Usuario.Add(usuario);

                 _personalRepository.InsertarUsuario(personal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PersonalDTO GetPersonalId(int id)
        {
            try
            {
                Personal personal = _personalRepository.GetPersonalId(id);
                PersonalDTO personalDTO = Mapper.Map<PersonalDTO>(personal);
                personalDTO.SucursalId = personal.SucursalUsuario.FirstOrDefault().SucursalId;
                return personalDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
    }
}
