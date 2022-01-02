using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TimerSystem 
{
    private int frameSizeDelaySet =0;
    private int _delayTic = 0;
    private bool _startTimer = true;
    private bool loopTimer;

    //timeSwich==true секуны, timeSwich==false кадры.
    //loop зацикливание таймера.
    //time еденицы времени задержки.
    public TimerSystem(bool timeSwich, bool loop, float time)
    {
        loopTimer = loop;
        if(timeSwich)
        {
            float temp = time * 30;
            frameSizeDelaySet = (int)temp;
        }
        else
        {
            frameSizeDelaySet =(int)time;
        }
    }
    public bool CheckEvent()
    {
        if (_startTimer)
        {
            _delayTic = frameSizeDelaySet;
            _startTimer = false;
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
            if (loopTimer)
            {
                _delayTic = frameSizeDelaySet;
            }
        }
    }
}
