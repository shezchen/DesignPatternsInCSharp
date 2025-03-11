namespace ObserverPattern
{
    static class Program
    {
        static void Main()
        {
            var provider = new WeatherSupplier();
            var observer1 = new WeatherMonitor("TP");
            var observer2 = new WeatherMonitor("H");
            provider.WeatherConditions(32.0, 0.05, 1.5);//发布天气信息，但不会储存
            //此处没有订阅者，所以没有输出
            observer1.Subscribe(provider);//此处触发了provider的Subscribe方法，将observer1加入到_observers中，并且将所有天气信息发送给它
            provider.WeatherConditions(33.5, 0.04, 1.7);//输出一个天气信息
            observer2.Subscribe(provider);
            provider.WeatherConditions(37.5, 0.07, 1.2);//输出两个天气信息，来自observer1和observer2


        }
    }
}
