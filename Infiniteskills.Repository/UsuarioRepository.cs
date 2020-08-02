using Infiniteskills.Common;
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
   
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        protected DbSet<Usuario> _DbSetUsuario;

        public UsuarioRepository(ApplicationDbContext applicationContext)
            : base(applicationContext)
        {
            _DbSetUsuario = _applicationDbContext.Set<Usuario>();
        }

        public override string[] IncludeEntity()
        {
            string[] relatedEnties = new string[] {
                    "Personal"
            };
            return relatedEnties;
        }
        public override Expression<Func<Usuario, bool>> BuildWhere(Dictionary<string, object> parameterList)
        {
            var predicate = PredicateBuilder.True<Usuario>();

            return predicate;
        }

        public override List<Usuario> SearchFor(Dictionary<string, object> parameterList, int pageCount, string orderBy)
        {
            return ExecuteSearch(IncludeEntity(), BuildWhere(parameterList), orderBy);
        }

        public void CreateUser(Usuario usuario)
        {

            using (var transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    Cryptor cryptor = new Cryptor();
                    Guid guid = Guid.NewGuid();
                    usuario.PasswordHash = guid.ToByteArray();
                    usuario.Password = cryptor.Encrypt(usuario.Password, usuario.PasswordHash);
                    Usuario usuarioLast = _applicationDbContext.Usuario.Add(usuario);

                    _applicationDbContext.SaveChanges();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

        }

        public Usuario FindByUser(string userName)
        {
            Usuario usuario = _DbSetUsuario.Include(x => x.Personal)
                .Where(x => x.UserName == userName).FirstOrDefault();
            return usuario;
        }

        public bool ValidateUser(int usuarioId, string password)
        {
            Cryptor cryptor = new Cryptor();
            Usuario usuario = _applicationDbContext.Usuario.Find(usuarioId);
            string decryptPassword = cryptor.Decrypt(usuario.Password, usuario.PasswordHash);
            if (decryptPassword == password)
                return true;

            return false;
        }

        public Usuario FindByUserAlmacen(string userName)
        {
            Usuario usuario = _DbSetUsuario.Include(x => x.Personal)
               .Where(x => x.UserName == userName).FirstOrDefault();
            return usuario;

        }

        public Usuario UsuarioAlmacen(int usuarioId)
        {

            return null;
        }

        public IEnumerable<UsuarioSucursal> GetUsuarioSucursal(int usuarioId)
        {
            IEnumerable<UsuarioSucursal> fooResults = null;
            _applicationDbContext.LoadStoredProc("sp_usuario_sucursal")
                     .WithSqlParam("usuarioId", usuarioId)
                     .ExecuteStoredProc((handler) =>
                     {
                         fooResults = handler.ReadToList<UsuarioSucursal>();
                     });

            return fooResults;
        }

        public List<Usuario> ListarUsuario(Dictionary<string, object> parameters)
        {
            var predicate = PredicateBuilder.True<Usuario>();

            IQueryable<Usuario> query = _DbSetUsuario;
            query = query
                .Include(x => x.Personal.SucursalUsuario)
                .Where(predicate);


           return query.ToList();
        }

        public IEnumerable<UsuarioSucursal> GetUsuarioPeriodoEmpresa(Dictionary<string, object> parameters)
        {


            IEnumerable<UsuarioSucursal> fooResults = null;
            _applicationDbContext.LoadStoredProc("sp_usuario_empresa")
                     .WithSqlParam("empresaId", Convert.ToInt32(parameters["empresaId"]))
                     .WithSqlParam("sucursalId", Convert.ToInt32(parameters["sucursalId"]))
                     .WithSqlParam("almacenId", Convert.ToInt32(parameters["almacenId"]))
                     .WithSqlParam("periodoId", Convert.ToInt32(parameters["periodoId"]))
                     .WithSqlParam("usuarioId", Convert.ToInt32(parameters["usuarioId"]))
                     .ExecuteStoredProc((handler) =>
                     {
                         fooResults = handler.ReadToList<UsuarioSucursal>();
                     });

            return fooResults;
        }
    }
}
