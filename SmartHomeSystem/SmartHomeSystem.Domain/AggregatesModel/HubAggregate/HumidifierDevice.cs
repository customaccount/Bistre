﻿using System;

namespace SmartHomeSystem.Domain.AggregatesModel.HubAggregate
{
    public class HumidifierDevice : BaseDevice, IHumidifierDevice
    {
        private const int MaxHumidityPercent = 100;
        private const int MinHumidityPercent = 0;
        private const int DefaultHumidityPercent = 50;

        public int AirHumidityPercent { get; private set; }

        public HumidifierDevice(int deviceId, string deviceCode, string name) : base(deviceId, deviceCode, name)
        {
            AirHumidityPercent = DefaultHumidityPercent;
        }

        public void SetAirHumidityPercent(int humidityPercent)
        {
            if (humidityPercent < MinHumidityPercent || humidityPercent > MaxHumidityPercent)
            {
                throw new ArgumentException($"Air Humidity can not be below {MinHumidityPercent}% or over {MaxHumidityPercent}%");
            }
            AirHumidityPercent = humidityPercent;
        }

        protected override void Reset()
        {
            base.Reset();
            AirHumidityPercent = DefaultHumidityPercent;
        }
    }
}
