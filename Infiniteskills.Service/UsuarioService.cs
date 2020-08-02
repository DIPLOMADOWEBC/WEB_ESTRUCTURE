using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Infiniteskills.Service
{
   
    public class UsuarioService : IEntityServiceBase<UsuarioDTO>, IUsuarioService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Create(UsuarioDTO entity)
        {
            try
            {
                Usuario usuario = Mapper.Map<Usuario>(entity);
                _usuarioRepository.Insert(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(UsuarioDTO entity)
        {
            try
            {
                Usuario usuario = Mapper.Map<Usuario>(entity);
                _usuarioRepository.Update(usuario);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }
        public void Delete(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO FindByUser(string userName)
        {
            try
            {
                Usuario usuario = _usuarioRepository.FindByUser(userName);
                UsuarioDTO usuarioDTO = Mapper.Map<UsuarioDTO>(usuario);
                return usuarioDTO;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public UsuarioDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(UsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public UsuarioDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<UsuarioDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Usuario> usuarioList = _usuarioRepository.SearchFor(parametersList, pageCount, orderBy);
                List<UsuarioDTO> usuarioDTOList = Mapper.Map<List<Usuario>, List<UsuarioDTO>>(usuarioList);

                return usuarioDTOList.ToList();

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public bool ValidateUser(int usuarioId, string password)
        {
            bool returnValue = _usuarioRepository.ValidateUser(usuarioId, password);
            return returnValue;
        }

        public void CreateUser(UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = Mapper.Map<Usuario>(usuarioDTO);
                _usuarioRepository.CreateUser(usuario);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public UsuarioDTO FindByUserAlmacen(string userName)
        {
            try
            {
                Usuario usuario = _usuarioRepository.FindByUserAlmacen(userName);
                UsuarioDTO usuarioDTO = Mapper.Map<UsuarioDTO>(usuario);
                return usuarioDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UsuarioDTO UsuarioAlmacen(int usuarioId)
        {
            try
            {
                Usuario usuario = _usuarioRepository.UsuarioAlmacen(usuarioId);
                UsuarioDTO usuarioDTO = Mapper.Map<UsuarioDTO>(usuario);
                SucursalDTO sucursalDTO = usuario.Personal.SucursalUsuario.Select(x => new SucursalDTO() {
                    Nombre = x.Sucursal.Nombre,
                    Direccion = x.Sucursal.Direccion
                }).First();

                return usuarioDTO;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public UsuarioSucursalDTO GetUsuarioSucursal(int usuarioId)
        {
            try
            {
                IEnumerable<UsuarioSucursal> usuarioAlmacenList = _usuarioRepository.GetUsuarioSucursal(usuarioId);
                IEnumerable<UsuarioSucursalDTO> usuarioAlmacenDTOList = Mapper
                    .Map<IEnumerable<UsuarioSucursal>, IEnumerable<UsuarioSucursalDTO>>(usuarioAlmacenList);

                return usuarioAlmacenDTOList.FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UsuarioDTO> ListarUsuario(Dictionary<string, object> parameters)
        {
            try
            {
                List<Usuario> usuarioList = _usuarioRepository.ListarUsuario(parameters);
                List<UsuarioDTO> usuarioDTOList = Mapper.Map<List<Usuario>, List<UsuarioDTO>>(usuarioList);

                return usuarioDTOList.ToList();

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public UsuarioSucursalDTO GetUsuarioPeriodoEmpresa(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<UsuarioSucursal> usuarioAlmacenList = _usuarioRepository.GetUsuarioPeriodoEmpresa(parameters);
                IEnumerable<UsuarioSucursalDTO> usuarioAlmacenDTOList = Mapper.Map<IEnumerable<UsuarioSucursal>, 
                    IEnumerable<UsuarioSucursalDTO>>(usuarioAlmacenList);

                return usuarioAlmacenDTOList.FirstOrDefault();

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
