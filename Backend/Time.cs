namespace Backend;

public class Time
{
    // Fields
    private int _hours;
    private int _minutes;
    private int _seconds;
    private int _millisecounds;



    // Constructors
    public Time()
    {
        Hours= 0;
        Minutes = 0;
        Seconds = 0;
        Millisecounds = 0;

    }

    public Time(int hours)
    {
        Hours = hours;
        Minutes = 0;
        Seconds = 0;
        Millisecounds = 0;  
    }

    public Time(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = 0;
        Millisecounds = 0;
    }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Millisecounds = 0;
    }

    public Time(int hours, int minutes, int seconds, int millisecounds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Millisecounds = millisecounds;
    }
    
    // Properties
    public int Hours { get => _hours; set => _hours = value; }
    public int Minutes { get => _minutes; set => _minutes = value; }
    public int Seconds { get => _seconds; set => _seconds = value; }
    public int Millisecounds { get => _millisecounds; set => _millisecounds = value; }



    // Public Methods
    public long ToMillisecounds() => (long)Hours * 3600000 + (long)Minutes * 60000 + (long)Seconds * 1000 + Millisecounds;

    public long ToSeconds() => (long)Hours * 3600 + (long)Minutes * 60 + Seconds;

    public long ToMinutes() => (long)Hours * 60 + Minutes;

    public Time Add(Time other)
    {
        const int MillisecoundsInADay = 24 * 60 * 60 * 1000;
        long totalMillisecounds = (this.ToMillisecounds() + other.ToMillisecounds()) % MillisecoundsInADay;
        int hours = (int)(totalMillisecounds / 3600000);
        totalMillisecounds %= 3600000;
        int minutes = (int)(totalMillisecounds / 60000);
        totalMillisecounds %= 60000;
        int seconds = (int)(totalMillisecounds / 1000);
        int millisecounds = (int)(totalMillisecounds % 1000);
        return new Time(hours, minutes, seconds, millisecounds);    
    }

    public bool IsOtherDay(Time other)
    {
        return this.ToMillisecounds() > other.ToMillisecounds();
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}.{Millisecounds:D3}";
    }


    // Private Methods

    private int ValidateMillisecounds(int millisecounds)
    {
        if (millisecounds < 0 || millisecounds >= 1000)
            throw new ArgumentOutOfRangeException(nameof(millisecounds), "Millisecounds must be between 0 and 999.");
        return millisecounds; 
    }

    private int ValidateSeconds(int seconds)
    { 
        if(seconds < 0 || seconds >= 60)
            throw new ArgumentOutOfRangeException(nameof(seconds), "Seconds must be between 0 and 59.");
        return seconds; 

    }
    private int ValidateMinutes(int minutes)
    {
        if (minutes < 0 || minutes >= 60)
            throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be between 0 and 59.");
        return minutes;
    }
    private int ValidateHours(int hours)
    {
        if (hours < 0 || hours >= 24)
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours must be between 0 and 23.");
        return hours;
    }
    
}     


