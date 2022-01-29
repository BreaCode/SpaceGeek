
public sealed class TimerSystem 
{
    private int _frameSizeDelaySet =0;
    private int _delayTic = 0;
    private bool _isStartTimer = true;
    private bool _isloopTimer;

    //timeSwich==true ������, timeSwich==false �����.
    //loop ������������ �������.
    //time ������� ������� ��������.
    public TimerSystem(bool timerSwich, bool isloop, float time)
    {
        SetParameters(timerSwich, isloop, time);
    }
    public TimerSystem(bool isloop, float time)
    {
        SetParameters(true, isloop, time);
    }
    public TimerSystem(float time)
    {
        SetParameters(true, true, time);
    }

    private void SetParameters(bool timerSwich, bool isloop, float time)
    {
        _isloopTimer = isloop;
        if(timerSwich)
        {
            float temp = time * 30;
            _frameSizeDelaySet = (int)temp;
        }
        else
        {
            _frameSizeDelaySet =(int)time;
        }
    }
    public bool CheckEvent()
    {
        if (_isStartTimer)
        {
            _delayTic = _frameSizeDelaySet;
            _isStartTimer = false;
        }
        else
        {
            bool eventT;
            TimeTic(ref _delayTic, out eventT);
            return eventT;
        }
        return false;
    }
    private void TimeTic(ref int getTime, out bool eventTimer)
    {
        if (getTime >0)
        {
            getTime--;
            eventTimer = false;
        }
        else
        {
            eventTimer = true;
            if (_isloopTimer)
            {
                _delayTic = _frameSizeDelaySet;
            }
        }
    }
    public void ResetTimer()
    {
        _delayTic = _frameSizeDelaySet;
    }
}