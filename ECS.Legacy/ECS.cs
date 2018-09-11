namespace ECS.Legacy
{
    public class ECS
    {
        public int Threshold { get; set;}
        private readonly TempSensor _tempSensor;
        private readonly Heater _heater;

        public ECS(int thr)
        {
            Threshold = thr;
            _tempSensor = new TempSensor();
            _heater = new Heater();
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < Threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
