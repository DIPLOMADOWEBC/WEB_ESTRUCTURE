using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface IMenuRepository : IRepositoryBase<Menu>
    {

    }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }
        public override Expression<Func<Menu, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Menu>();

            if (parameterList.ContainsKey("menuId"))
            {
                int value = Convert.ToInt32(parameterList["menuId"]);
                predicate = predicate.And(x => x.MenuId == value);
            }
            if (parameterList.ContainsKey("estado"))
            {
                string value = Convert.ToString(parameterList["estado"]);
                predicate = predicate.And(p => p.Estado == value);
            }

            return predicate;
        }
        public override List<Menu> SearchFor(Dictionary<string, object> parameterList, int pageSize, string orderBy)
        {
            return this.ExecuteSearch(this.IncludeEntity(), this.BuildWhere(parameterList), pageSize, orderBy);
        }
    }
}
