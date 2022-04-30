using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Helpers
{
    public interface ICacheManager
    {
        /*
         Çıktı Ön Bellekleme
        Data Cache
         */
        T Get<T>(string key);
        void Set(string key, object data);
        void Delete(string key);
        void Clear();
        /*
         
         */
        void Clear(string header);
    }
}
