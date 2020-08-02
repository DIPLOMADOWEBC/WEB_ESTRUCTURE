using Infiniteskills.Service;
using Infiniteskills.Transport;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public class UserManager : UserManager<ApplicationUser>, IUserManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUsuarioService _usuarioService;

        public UserManager(IUsuarioService usuarioService)
            : base(new UserStore<ApplicationUser>())
        {
            _usuarioService = usuarioService;
            this.PasswordHasher = new OldSystemPasswordHasher(usuarioService);
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            Task<ApplicationUser> taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                logger.Info("FindAsync :: Start Execution");

                UsuarioDTO usuario = _usuarioService.FindByUser(userName);
                if (usuario == null)
                    return null;
                
                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(usuario.UsuarioId.ToString(), password);

                if (result == PasswordVerificationResult.Success)
                {
                    ApplicationUser applicationUser = new ApplicationUser(usuario.UsuarioId.ToString());
                    applicationUser.UserName = usuario.UserName;
                    return applicationUser;
                }


                return null;

            });

            return taskInvoke;
        }

        public PasswordVerificationResult VerifyPassword(string userName, string password)
        {
         
            UsuarioDTO usuarioDTO = _usuarioService.FindByUser(userName);

            if (usuarioDTO == null)
                return PasswordVerificationResult.Failed;

            return this.PasswordHasher.VerifyHashedPassword(usuarioDTO.Password, password);
        }

        public UsuarioDTO GetByUserByName(string userName)
        {
            UsuarioDTO usuarioDTO = _usuarioService.FindByUser(userName);
            return usuarioDTO;
        }

        public UsuarioDTO FindByUserAlmacen(string userName)
        {
            UsuarioDTO usuarioDTO = _usuarioService.FindByUserAlmacen(userName);
            return usuarioDTO;
        }
    }

    internal class OldSystemPasswordHasher : PasswordHasher
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUsuarioService _usuarioService;
        public OldSystemPasswordHasher(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public override string HashPassword(string password)
        {
            Byte[] encodeBytes = null;
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                encodeBytes = hash.ComputeHash(enc.GetBytes(password));
            }

            return Convert.ToBase64String(encodeBytes);
        }
        public Byte[] ByteHashPassword(string password)
        {
            Byte[] encodeBytes = null;
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                encodeBytes = hash.ComputeHash(enc.GetBytes(password));
            }

            return encodeBytes;
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {


            if (_usuarioService.ValidateUser(Convert.ToInt32(hashedPassword), providedPassword))
                return PasswordVerificationResult.Success;

            return PasswordVerificationResult.Failed;
        }
    }
}
