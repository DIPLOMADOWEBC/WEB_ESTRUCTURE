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
 
    public class OrdenItemService : IEntityServiceBase<OrdenItemDTO>, IOrdenItemService
    {
        private readonly IOrdenItemRepository _pedidoItemRepository;
   
        public OrdenItemService(IOrdenItemRepository pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
           
        }
        public void Create(OrdenItemDTO entity)
        {
            try
            {
                OrdenItem pedidoItem = Mapper.Map<OrdenItem>(entity);
                _pedidoItemRepository.Insert(pedidoItem);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(OrdenItemDTO entity)
        {
            try
            {
                OrdenItem pedidoItem = Mapper.Map<OrdenItem>(entity);
                _pedidoItemRepository.Update(pedidoItem);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(OrdenItemDTO entity)
        {
            try
            {
                OrdenItem pedidoItem = Mapper.Map<OrdenItem>(entity);
                _pedidoItemRepository.Delete(pedidoItem);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public OrdenItemDTO GetById(int id)
        {
            try
            {
                OrdenItem pedidoItem = _pedidoItemRepository.GetById(id);
                OrdenItemDTO pedidoItemDTO = Mapper.Map<OrdenItemDTO>(pedidoItem);
                return pedidoItemDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<OrdenItemDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<OrdenItemDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<OrdenItem> pedidoItemList = _pedidoItemRepository.SearchFor(parametersList, pageCount, orderBy);
                List<OrdenItemDTO> categoriaDTOList = Mapper.Map<List<OrdenItem>, List<OrdenItemDTO>>(pedidoItemList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public OrdenItemDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }
        public string[] Insert(OrdenItemDTO entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrdenItemDTO> ListarFactura(int id)
        {
            try
            {
                IEnumerable<OrdenItem> ordenItemList = _pedidoItemRepository.ListarFactura(id);
                IEnumerable<OrdenItemDTO> ordenItemDTOList = Mapper.Map<IEnumerable<OrdenItem>, IEnumerable<OrdenItemDTO>>(ordenItemList);

                return ordenItemDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<KardexProductoDTO> ListarKardex(Dictionary<string, object> parameters )
        {
            try
            {
                IEnumerable<KardexProducto> pedidoItemList = _pedidoItemRepository.ListarKardex(parameters);
                IEnumerable<KardexProductoDTO> categoriaDTOList = Mapper.Map<IEnumerable<KardexProducto>, IEnumerable<KardexProductoDTO>>(pedidoItemList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenItemDTO> ListarOrdenItem(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<OrdenItem> pedidoItemList = _pedidoItemRepository.ListarOrdenItem(parameters);
                IEnumerable<OrdenItemDTO> categoriaDTOList = Mapper.Map<IEnumerable<OrdenItem>, IEnumerable<OrdenItemDTO>>(pedidoItemList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenItemDTO> ListarInventario(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<OrdenItem> ordenItemList = _pedidoItemRepository.ListarInventario(parameters);
                IEnumerable<OrdenItemDTO> ordenItemDTOList = Mapper.Map<IEnumerable<OrdenItem>, IEnumerable<OrdenItemDTO>>(ordenItemList);

                return ordenItemDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
