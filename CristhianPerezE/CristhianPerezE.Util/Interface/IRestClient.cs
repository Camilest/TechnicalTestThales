using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristhianPerezE.Util.Interface
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string url);        
    }
}
