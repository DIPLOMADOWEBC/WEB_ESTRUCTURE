using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Base
{
    public interface ISunatClient
    {
        Task<HttpResponseMessage> PostAsJsonAsync(string endpoint, object data, string args = null);
        Task<HttpResponseMessage> PutAsJsonAsync(string endpoint, object data, string args = null);
    }
}
