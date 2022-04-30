using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent; // ConcurrentBag
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Helpers
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        public static ConcurrentBag<string> keys = new ConcurrentBag<string>();
        #region ConcurrencyBag ile ilgili
        // cache alınmış olan nesnelerin isimlerini tutmak için özel bir generic list kullanacağız
        // ConcurrencyBag isimli bu generic list List<> lere hiç benzemez amaçları kendisine aynı anda multi thread erişim olduğunda hata almaması ve bu gelen trafiği iyi yönetmesidir.List<> tiğindeki generic listler Çok kanallı işlemler için uygun değillerdir.
        // neden çok kanallı işlem yapacağız memory işlemleri her kullanıcı için ortak olduğundan bu ICacheManager static yani singleton olmalıdır.Bu sebebten içindeki listelerde yoğun bir etkileşime marus kalacaktır.
        // Neden db işlemlerinde multithread ile ilgili hata almamamızın sebebi işlemlerin db de olmasıdır db aynı anda birden fazla erişime uygun olarak geliştirilmiştir.ama şuanda bizim keyleri tutacağımız generic list bir db değişdir. 
        #endregion

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            var result = _memoryCache.Get<T>(key);
            if (result == null)
            {
                Delete(key);
            }
            return result;
        }

        public void Set(string key, object data)
        {
            RemoveKey(key);
            keys.Add(key);
            _memoryCache.Set(key, data);
        }

        public void Delete(string key)
        {
            _memoryCache.Remove(key);
            RemoveKey(key);

        }

        public void Clear()
        {
            var list = keys.ToList();
            foreach (var item in list)
            {
                Delete(item);
                RemoveKey(item);
            }
        }
        // product.1.images
        // product.1.detail
        // product.1
        // product.2.images
        // product.2.detail
        // product.3
        public void Clear(string header)
        {
            var list = keys.AsQueryable().Where(x => x.StartsWith(header)).ToList();
            foreach (var item in list)
            {
                Delete(item);
                RemoveKey(item);
            }
        }

        private void RemoveKey(string key)
        {
            var data = keys.AsQueryable().Where(x => x == key).FirstOrDefault();
            if (data != null)
            {
                data = null;
            }
            keys.ToList().Remove(key);
        }
    }
}
