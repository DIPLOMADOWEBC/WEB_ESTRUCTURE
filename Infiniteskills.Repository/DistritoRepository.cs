
using Infiniteskills.Domain;
using Infiniteskills.Infra.Core;
using Infiniteskills.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infiniteskills.Repository
{
    public interface IDistritoRepository : IRepositoryBase<Distrito>
    {
        IEnumerable<Distrito> Ubigeo(string codigo);
    }
    public class DistritoRepository : RepositoryBase<Distrito>, IDistritoRepository
    {
        private DbSet<Distrito> _distritoSet;
        public DistritoRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _distritoSet = _applicationDbContext.Distrito;
        }
        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] { };
            return relatedEnties;
        }

        public override List<Distrito> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }
        public override Expression<Func<Distrito, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Distrito>();
            if (parameterList.ContainsKey("provinciaId"))
            {
                int value = Convert.ToInt32(parameterList["provinciaId"]);
                predicate = predicate.And(x => x.ProvinciaId == value);
            }
            return predicate;
        }

        public IEnumerable<Distrito> Ubigeo(string codigo)
        {
            var ubigeo = GetNextChars(codigo, 2);
            string departamento = ubigeo.ElementAt(0);
            string provincia = ubigeo.ElementAt(1);
            string distrito = ubigeo.ElementAt(2);

            
        var query = _distritoSet.
                Include(x => x.Provincia.Departamento.Pais)
                .Where(x=>x.Provincia.Departamento.Codigo == departamento 
                && x.Provincia.Codigo == provincia && x.Codigo == distrito);

            return query.ToList();
        }

        private IEnumerable<string> GetNextChars(string str, int iterateCount)
        {
            var words = new List<string>();

            for (int i = 0; i < str.Length; i += iterateCount)
                if (str.Length - i >= iterateCount) words.Add(str.Substring(i, iterateCount));
                else words.Add(str.Substring(i, str.Length - i));

            return words;
        }
    }
}