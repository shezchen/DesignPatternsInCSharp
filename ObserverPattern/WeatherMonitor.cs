using System;

namespace ObserverPattern
{
    sealed class WeatherMonitor : IObserver<Weather>
    {
        private IDisposable _cancellation;//用于取消订阅
        private readonly string _name;//观察者名称

        public void Subscribe(WeatherSupplier provider)
        {
            _cancellation = provider.Subscribe(this);//订阅provider，并存储返回的IDisposable对象
            //此处的Subscribe方法在接受订阅的observer之后，将其加入到_observers中，并且将所有天气信息发送给它
            //返回的IDisposable对象是Unsubscriber，用于取消订阅
        }

        public void Unsubscribe()
        {
            _cancellation.Dispose();//使用IDisposable对象取消订阅
        }

        public WeatherMonitor(string name)
        {
            _name = name;//设置观察者名称
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error has occured");
        }

        public void OnNext(Weather value)
        {
            //新获得天气信息之后对其进行处理，此处是打印天气信息
            Console.WriteLine(_name);
            if (_name.Contains("T"))
            {
                string op = $"| Temperature : {value.Temperature} Celsius |";
                Console.Write(op);

            }
            if (_name.Contains("P"))
            {
                string op = $"| Pressure : {value.Pressure} atm |";
                Console.Write(op);
            }
            if (_name.Contains("H"))
            {
                string op = $"| Humidity : {value.Humidity * 100} % |";
                Console.Write(op);
            }
            if (!(_name.Contains("T") || _name.Contains("P") || _name.Contains("H")))
            {
                OnError(new Exception());
            }
            Console.WriteLine();
        }
    }
}
