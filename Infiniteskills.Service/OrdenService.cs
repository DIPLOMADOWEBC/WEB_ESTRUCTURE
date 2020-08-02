using AutoMapper;
using Infiniteskills.Common;
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

    public class OrdenService : IEntityServiceBase<OrdenDTO>, IOrdenService
    {
        private IOrdenRepository _pedidoRepository;
        private IPeriodoCorrelativoRepository _periodoCorrelativoRepository;
        public OrdenService(IOrdenRepository pedidoRepository, IPeriodoCorrelativoRepository periodoCorrelativoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _periodoCorrelativoRepository = periodoCorrelativoRepository;
        }
        public void Create(OrdenDTO entity)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.PEDIDO }
                };

                entity.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                Orden pedido = Mapper.Map<Orden>(entity);
                _pedidoRepository.Insert(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(OrdenDTO entity)
        {
            try
            {
                Orden pedido = Mapper.Map<Orden>(entity);
                _pedidoRepository.Update(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(OrdenDTO entity)
        {
            try
            {
                Orden pedido = Mapper.Map<Orden>(entity);
                _pedidoRepository.Delete(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string[] Insert(OrdenDTO entity)
        {
            throw new NotImplementedException();
        }
        public OrdenDTO GetById(int id)
        {
            try
            {
                Orden pedido = _pedidoRepository.GetById(id);
                OrdenDTO pedidoDTO = Mapper.Map<OrdenDTO>(pedido);
                return pedidoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<OrdenDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            return SearchFor(parametersList, 0, orderBy);
        }
        public List<OrdenDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Orden> pedidoList = _pedidoRepository.SearchFor(parametersList, pageCount, orderBy);
                List<OrdenDTO> categoriaDTOList = Mapper.Map<List<Orden>, List<OrdenDTO>>(pedidoList);

                return categoriaDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public OrdenDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }
        public void InsertPedidoItem(OrdenDTO pedidoDTO)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.PEDIDO }
                };


                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                //pedido.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                pedido.Codigo = "0001";
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);

                _pedidoRepository.InsertPedidoItem(pedido);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void UpdatePedidoItem(OrdenDTO pedidoDTO)
        {
            try
            {

                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);
                _pedidoRepository.UpdatePedidoItem(pedido);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task InsertIventarioItem(OrdenDTO pedidoDTO)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.INVENTARIO }
                };

                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                //pedido.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                pedido.Codigo = "0001";
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);
               await _pedidoRepository.InsertIventarioItem(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void UpdateInventarioItem(OrdenDTO pedidoDTO)
        {
            try
            {

                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);
                _pedidoRepository.UpdateInventarioItem(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task InsertarTransferencia(OrdenDTO ordenDTO)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.INVENTARIO }
                };


                Orden pedido = Mapper.Map<Orden>(ordenDTO);
                pedido.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(ordenDTO.OrderItemList);
                await _pedidoRepository.InsertarTransferencia(pedido);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<OrdenDTO> BuscarPedidos(int id)
        {
            try
            {
                Orden pedido = await _pedidoRepository.BuscarPedidos(id);
                OrdenDTO pedidoDTO = Mapper.Map<OrdenDTO>(pedido);
                return pedidoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenDTO> BuscarOrdenCompra(string codigo)
        {
            try
            {
                IEnumerable<Orden> ordenList = _pedidoRepository.BuscarOrdenCompra(codigo);
                IEnumerable<OrdenDTO> ordenDTOList = Mapper.Map<IEnumerable<Orden>, IEnumerable<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<OrdenDTO> BuscarInventarioInicial(int id)
        {
            try
            {
                Orden pedido = await _pedidoRepository.BuscarInventarioInicial(id);
                OrdenDTO pedidoDTO = Mapper.Map<OrdenDTO>(pedido);
                return pedidoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task InsertarCompra(OrdenDTO pedidoDTO)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.INVENTARIO }
                };
                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                pedido.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                pedido.NumeroDocumento = pedido.Codigo;
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);
                await _pedidoRepository.InsertarCompra(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task InsertarMovimiento(OrdenDTO pedidoDTO)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "tabla", TablaConstante.INVENTARIO }
                };


                Orden pedido = Mapper.Map<Orden>(pedidoDTO);
                pedido.Codigo = _periodoCorrelativoRepository.ObtenerCorrelativo(parameters);
                pedido.OrdenItem = Mapper.Map<List<OrdenItemDTO>, List<OrdenItem>>(pedidoDTO.OrderItemList);
                await _pedidoRepository.InsertarMovimiento(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<OrdenDTO> ListarInventario(Dictionary<string, object> parameters)
        {
            try
            {
                List<Orden> ordenList = _pedidoRepository.ListarInventario(parameters);
                List<OrdenDTO> ordenDTOList = Mapper.Map<List<Orden>, List<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<OrdenDTO> ListarPedido(Dictionary<string, object> parameters)
        {
            try
            {
                List<Orden> ordenList = _pedidoRepository.ListarPedidos(parameters);
                List<OrdenDTO> ordenDTOList = Mapper.Map<List<Orden>, List<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<OrdenDTO> ListarCompra(Dictionary<string, object> parameters)
        {
            try
            {
                List<Orden> ordenList = _pedidoRepository.ListarCompra(parameters);
                List<OrdenDTO> ordenDTOList = Mapper.Map<List<Orden>, List<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenDTO> ListarMovimiento(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<Orden> ordenList = _pedidoRepository.ListarMovimiento(parameters);
                IEnumerable<OrdenDTO> ordenDTOList = Mapper.Map<IEnumerable<Orden>, IEnumerable<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<OrdenDTO> BuscarMovimientoAsync(int id)
        {
            try
            {
                Orden pedido = await _pedidoRepository.BuscarMovimiento(id);
                OrdenDTO pedidoDTO = Mapper.Map<OrdenDTO>(pedido);
                return pedidoDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenDTO> ListarCotizacion(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<Orden> ordenList = _pedidoRepository.ListarCotizacion(parameters);
                IEnumerable<OrdenDTO> ordenDTOList = Mapper.Map<IEnumerable<Orden>, IEnumerable<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<OrdenDTO> ListarGuiaRemision(Dictionary<string, object> parameters)
        {
            try
            {
                IEnumerable<Orden> ordenList = _pedidoRepository.ListarGuiaRemision(parameters);
                IEnumerable<OrdenDTO> ordenDTOList = Mapper.Map<IEnumerable<Orden>, IEnumerable<OrdenDTO>>(ordenList);

                return ordenDTOList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
