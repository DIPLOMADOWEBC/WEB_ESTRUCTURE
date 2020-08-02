
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infiniteskills.Infra.Data;

namespace Infiniteskills.Repository
{
    public interface IRolUsuarioRepository : IRepositoryBase<RolUsuario>
    {

    }
    public class RolUsuarioRepository : RepositoryBase<RolUsuario>, IRolUsuarioRepository
    {
        public RolUsuarioRepository(ApplicationDbContext applicationContext) 
            : base(applicationContext)
        {
        }

        public override string[] IncludeEntity()
        {

            string[] relatedEnties = new string[] {
            "Rol",
            "Usuario"
         };
            return relatedEnties;
        }
        public override Expression<Func<RolUsuario, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<RolUsuario>();

            if (parameterList.ContainsKey("rolUsuarioId"))
            {
                int value = Convert.ToInt32(parameterList["rolUsuarioId"]);
                predicate = predicate.And(x => x.RolUsuarioId == value);
            }
            if (parameterList.ContainsKey("rolId"))
            {
                int value = Convert.ToInt32(parameterList["rolId"]);
                predicate = predicate.And(x => x.RolId == value);
            }

            if (parameterList.ContainsKey("usuarioId"))
            {
                int value = Convert.ToInt32(parameterList["usuarioId"]);
                predicate = predicate.And(x => x.UsuarioId == value);
            }

            if (parameterList.ContainsKey("rol"))
            {
                string value = Convert.ToString(parameterList["rol"]);
                predicate = predicate.And(x => x.Rol.Codigo == value);
            }
            if (parameterList.ContainsKey("rolList"))
            {
                List<string> valueList = (List<string>)parameterList["rolList"];
                predicate = predicate.And(p => valueList.Contains(p.Rol.Codigo));
            }
            if (parameterList.ContainsKey("estado"))
            {
                string value = Convert.ToString(parameterList["estado"]);
                predicate = predicate.And(x => x.Usuario.Estado == value);
            }

            return predicate;
        }
        public override List<RolUsuario> SearchFor(Dictionary<string, object> parameterList, int pageSize, string orderBy)
        {
            return this.ExecuteSearch(this.IncludeEntity(), this.BuildWhere(parameterList), pageSize, orderBy);
        }
    }
}
