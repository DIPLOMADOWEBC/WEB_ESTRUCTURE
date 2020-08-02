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
    public interface ITipoUsuarioService : IEntityServiceBase<TipoUsuarioDTO>
    {

    }
    public class TipoUsuarioService : IEntityServiceBase<TipoUsuarioDTO>, ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public void Create(TipoUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Update(TipoUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(TipoUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(TipoUsuarioDTO entity)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<TipoUsuarioDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<TipoUsuario> tipoUsuarioList = _tipoUsuarioRepository.SearchFor(parametersList, pageCount, orderBy);
                List<TipoUsuarioDTO> tipoUsuarioDTOList = Mapper.Map<List<TipoUsuario>, List<TipoUsuarioDTO>>(tipoUsuarioList);

                return tipoUsuarioDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
    }
}
