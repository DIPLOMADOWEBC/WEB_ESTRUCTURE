using AutoMapper;
using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface ICategoriaService : IEntityServiceBase<CategoriaDTO>
    {

    }
    public class CategoriaService : IEntityServiceBase<CategoriaDTO>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }
        public void Delete(CategoriaDTO entity)
        {
            throw new NotImplementedException();
        }

        public CategoriaDTO GetById(int id)
        {
            try
            {
                Categoria categoria = _categoriaRepository.GetById(id);
                CategoriaDTO categoriaDTO = Mapper.Map<CategoriaDTO>(categoria);
                return categoriaDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Create(CategoriaDTO entity)
        {
            try
            {
                Categoria categoria = Mapper.Map<Categoria>(entity);
                _categoriaRepository.Insert(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CategoriaDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }

        public List<CategoriaDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Categoria> categoriaList = _categoriaRepository.SearchFor(parametersList, pageCount, orderBy);
                List<CategoriaDTO> categoriaDTOList = Mapper.Map<List<Categoria>, List<CategoriaDTO>>(categoriaList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(CategoriaDTO entity)
        {
            Categoria categoria = Mapper.Map<Categoria>(entity);
            _categoriaRepository.Update(categoria);
        }

        public string[] Insert(CategoriaDTO entity)
        {
            throw new NotImplementedException();
        }

        public void InsertarProductoCategoria(CategoriaDTO categoriaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
