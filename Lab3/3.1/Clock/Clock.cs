namespace Clock
{
    public class Clock
    {
        Counter _second = new("seconds");
        Counter _minute = new("minutes");
        Counter _hour = new("hours");

        public void Tick()
        {
            _second.Increment();
            if (_second.Tick > 59)
            {
                _second.Reset();
                _minute.Increment();

                if (_minute.Tick > 59)
                {
                    _minute.Reset();
                    _hour.Increment();

                    if (_hour.Tick > 23)
                    {
                        _hour.Reset();
                    }
                }
            }
        }

        public void ResetClock()
        {
            _second.Reset();
            _minute.Reset();
            _hour.Reset();
        }

        public string Time()
        {

            return _hour.Tick.ToString("00") + ":" + _minute.Tick.ToString("00") + ":" + _second.Tick.ToString("00");

        }
    }
}