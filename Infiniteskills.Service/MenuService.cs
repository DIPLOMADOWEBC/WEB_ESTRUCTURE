using Infiniteskills.Domain;
using Infiniteskills.Infra.Base;
using Infiniteskills.Transport;
using Infiniteskills.Repository;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infiniteskills.Service
{
    public interface IMenuService : IEntityServiceBase<MenuDTO>
    {

    }
    public class MenuService : IEntityServiceBase<MenuDTO>, IMenuService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public void Create(MenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public MenuDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string[] Insert(MenuDTO entity)
        {
            throw new NotImplementedException();
        }

        public MenuDTO SearchFor(Dictionary<string, object> parameterList)
        {
            throw new NotImplementedException();
        }

        public List<MenuDTO> SearchFor(Dictionary<string, object> parametersList, string orderBy)
        {
            try
            {
                return this.SearchFor(parametersList, 0, orderBy).ToList<MenuDTO>();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public List<MenuDTO> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy)
        {
            try
            {
                List<Menu> menuList = _menuRepository.SearchFor(parametersList, pageCount, string.Empty);

                List<MenuDTO> menuDTOList = AutoMapper.Mapper.Map<List<MenuDTO>>(menuList);

    
                return menuDTOList.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        public void Update(MenuDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
