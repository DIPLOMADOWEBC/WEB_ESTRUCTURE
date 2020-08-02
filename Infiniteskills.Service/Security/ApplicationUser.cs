using System;
using Microsoft.AspNet.Identity;

namespace Infiniteskills.Service
{
    public class ApplicationUser : IUser
    {
        private string _id = string.Empty;
        public ApplicationUser(string id)
        {
            _id = id;
        }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Id
        {
            get { return _id.ToString(); }
        }

    }
}
