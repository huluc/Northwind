using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager( new LoggerFactory()); //Burada IoC Container kullanılabilirdi.

        }
        
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Burada duruma göre MyLogger dışında farklı bir logger da verilebilir.Mesela web config de bir değer tutup ona bakılabilir. IoC de tek seçeneğe yönşendiriyor.
            return new MyLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Burada duruma göre MyLogger dışında farklı bir logger da verilebilir.Mesela web config de bir değer tutup ona bakılabilir. IoC de tek seçeneğe yönşendiriyor.
            return new MyLogger();
        }
    }

    public interface ILoggerFactory
    {
       ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class MyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;//DependencyInjection 
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            //MyLogger mylogger = new MyLogger();
            //mylogger.Log();
            //ILogger logger = new LoggerFactory().CreateLogger(); //Burada LoggerFactory e bağımlı kaldık.Bu yüzden DependencyInjection yapacağız.
            ILogger logger =_loggerFactory.CreateLogger();
            logger.Log();
        }
    }
    
}
