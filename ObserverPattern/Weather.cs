namespace ObserverPattern
{
    class Weather
    {
        //weather包含温度、湿度、气压
        public double Pressure { get; }

        public double Humidity { get; }

        public double Temperature { get; }

        public Weather(double humd, double pres, double temp)
        {
            Temperature = temp;
            Pressure = pres;
            Humidity = humd;
        }
    }
}
