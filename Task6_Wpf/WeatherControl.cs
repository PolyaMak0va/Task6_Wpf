using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task6_Wpf
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        public enum Precipitations : int
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            SmallRain = 3,
            Snow = 4,
            Thunderstorm = 5,
            StormClouds = 6,
            Fog = 7,
            Clear = 8
        }
        private Precipitations precipitations;

        public WeatherControl(int temperature, string windDirection, int windSpeed, Precipitations precipitations)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.precipitations = precipitations;
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.Journal |
                    FrameworkPropertyMetadataOptions.Inherits,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }

        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }

        public string GetInfo()
        {
            return $"{Temperature} {WindDirection} {WindSpeed}";
        }

        void PrintMessage(Precipitations precipitations)
        {
            switch (precipitations)
            {
                case Precipitations.Sunny:
                    Console.WriteLine("Сегодня солнечно.");
                    break;
                case Precipitations.Cloudy:
                    Console.WriteLine("Сегодня облачно.");
                    break;
                case Precipitations.Rain:
                    Console.WriteLine("Сегодня идёт дождь.");
                    break;
                case Precipitations.SmallRain:
                    Console.WriteLine("Ожидается небольшой дождь.");
                    break;
                case Precipitations.Snow:
                    Console.WriteLine("Сегодня идёт снег.");
                    break;
                case Precipitations.Thunderstorm:
                    Console.WriteLine("Сегодня будут молния и грозы.");
                    break;
                case Precipitations.StormClouds:
                    Console.WriteLine("Ожидаются грозовые тучи.");
                    break;                
                case Precipitations.Fog:
                    Console.WriteLine("На улице туман.");
                    break;
                case Precipitations.Clear:
                    Console.WriteLine("Сейчас ясно.");
                    break;
            }
        }
        //public static void Main()
        //{
        //    int[] values = { 0, 1, 2, 4, 5, 6, 7, 8, Int32.MaxValue };
        //    foreach (var value in values)
        //    {
        //        Precipitations status;
        //        if (Enum.IsDefined(typeof(Precipitations), value))
        //            status = (Precipitations)value;
        //        else
        //            status = Precipitations.Sunny;
        //        Console.WriteLine("Converted {0:N0} to {1}", value, status);
        //        Console.ReadKey();
        //    }
        //}
    }
}
