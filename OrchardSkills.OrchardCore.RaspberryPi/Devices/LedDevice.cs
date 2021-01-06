using System;
using System.Device.Gpio;

namespace OrchardSkills.OrchardCore.RaspberryPi.Devices
{
    public class LedDevice : IDisposable
    {
        private const int LedPin = 17;

        private GpioController _controller;
        private bool disposedValue = false;
        private object _locker = new object();
        private bool ledSupported = true;
        public LedDevice()
        {
            try
            {
                _controller = new GpioController();
                _controller.OpenPin(LedPin, PinMode.Output);
                _controller.Write(LedPin, PinValue.Low);
                IsReplayOn = false;
            }
            catch (Exception ex)
            {
                ledSupported = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsReplaySupported = ledSupported;
            }
        }

        public bool IsReplaySupported { get; private set; }
        public bool IsReplayOn { get; private set; }

        public void ReplayOn()
        {
            lock (_locker)
            {
                if (ledSupported) _controller.Write(LedPin, PinValue.High);

                IsReplayOn = true;
            }
        }

        public void ReplayOff()
        {
            lock (_locker)
            {
                if (ledSupported) _controller.Write(LedPin, PinValue.Low);

                IsReplayOn = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (ledSupported) _controller.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
