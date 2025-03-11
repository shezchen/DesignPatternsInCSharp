using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class WeatherSupplier : IObservable<Weather>
    {
        //天气供应商类，实现了IObservable<T>接口
        private readonly List<IObserver<Weather>> _observers;//list包含所有观察者
        private List<Weather> Screens { get; }//这里的Screens是一个List，用于存储所有天气信息
        //实际上此处的Screens没有添加Weather,也就是说并没有保存天气信息
        private List<Weather> GetScreens()
        {
            return Screens;//Screens的get方法
        }

        public WeatherSupplier()
        {
            //构造函数
            _observers = new List<IObserver<Weather>>();
            Screens = new List<Weather>();
        }

        public IDisposable Subscribe(IObserver<Weather> observer)//observer是WeatherMonitor类的实例
        {
            //此处的Subscribe方法在接受订阅的observer之后，将其加入到_observers中，并且将所有天气信息发送给它
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                foreach (var item in GetScreens())
                {
                    observer.OnNext(item);
                }
            }
            return new Unsubscriber<Weather>(_observers, observer);
        }

        public void WeatherConditions(double temp = 0, double humd = 0, double pres = 0)
        {
            //接受一个天气信息但不保存，之后转发给所有的观察者
            var conditions = new Weather(humd, pres, temp);
            foreach (var item in _observers)
                item.OnNext(conditions);

            //结束后将天气信息丢弃
        }
    }
}
