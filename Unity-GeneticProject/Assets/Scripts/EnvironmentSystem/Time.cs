using UnityEngine;
using System.Collections;

public class Time
    : MonoBehaviour
{
    [SerializeField]
    private int _day;
    public int Day { get { return _day; } }

    [SerializeField]
    private int _hour;
    public int Hour { get { return _hour; } }

    [SerializeField]
    private int _minute;
    public int Minute { get { return _minute; } }

    public delegate void DayEvent();
    public delegate void HourEvent();
    public delegate void MinuteEvent();

    public DayEvent DayEventHandler { get; set; }
    public HourEvent HourEventHandler { get; set; }
    public MinuteEvent MinuteEventHandler { get; set;
    }
    private void Awake()
    {
        _day = _hour = _minute = 0;
        InvokeRepeating("UpdateTime", 1.0f, 1.0f);
    }

    private void UpdateTime()
    {
        _minute += 10;

        if (!ReferenceEquals(MinuteEventHandler, null))
        {
            MinuteEventHandler.Invoke();
        }
        if (_minute >= 60)
        {
            _hour += 1;
            _minute = 0;

            if (!ReferenceEquals(HourEventHandler, null))
            {
                HourEventHandler.Invoke();
            }
        }

        if (_hour >= 24)
        {
            _day += 1;
            _hour = 0;

            if (!ReferenceEquals(DayEventHandler, null))
            {
                DayEventHandler.Invoke();
            }
        }
    }
}