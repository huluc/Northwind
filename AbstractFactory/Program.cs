using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1()); //Burada isteğimiz senaryoya uygun Factory i seçiyoruz
            productManager.GetAll();
            Console.ReadLine();
        }
        public abstract class Logging
        {
            public abstract void Log(string message);
        }
        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with log4net!");
            }
        }
        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with NLogger!");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }
        public class RedisCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RedisCache");
            }
        }
        public abstract class CrossCuttingConcernsFactory //Fabrikamız duruma göre bizim için gerekli kombinasyonları üreten yer.
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }
        public class Factory1 : CrossCuttingConcernsFactory //İlk fabrika Cachleme için RedisCache Loglama için Log4Net kullanıyor.
        {
            public override Caching CreateCaching()
            {
                return new RedisCache() ;
            }

            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
        }
        public class Factory2 : CrossCuttingConcernsFactory //2. fabrika Cachleme için MemCache Loglama için NLogger kullanıyor.
        {
            public override Caching CreateCaching()
            {
                return new MemCache();
            }

            public override Logging CreateLogger()
            {
                return new NLogger();
            }
        }
        //şimdi Client sınıfımızı yazıyoruz.
        //Factory Pattern sayesinde projede değişiklik olduğunda client tarafında değişikliğe gerek yok. Çünkü inheritance kullandık. 
        public class ProductManager
        {
            private CrossCuttingConcernsFactory _crossCuttingsConcernsFactory;
            private Logging _logging;
            private Caching _caching; 
            public ProductManager(CrossCuttingConcernsFactory crossCuttingsConcernsFactory)
            {
                _crossCuttingsConcernsFactory= crossCuttingsConcernsFactory;
                _logging = _crossCuttingsConcernsFactory.CreateLogger();
                _caching = _crossCuttingsConcernsFactory.CreateCaching();
            }
            public void GetAll()
            {

                //_crossCuttingsConcernsFactory.CreateLogger().Log("ss");
                _logging.Log("xmö");
                _caching.Cache("cfccf");
                Console.WriteLine("Products are listed.");
            }
        }
    }
}
