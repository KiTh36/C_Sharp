using System;
using System.Globalization;
using System.Collections.Generic;

public class TimeInterval
{
    public TimeOnly Start { get; }
    public TimeOnly End { get; }

    // Base constructor
    public TimeInterval(TimeOnly start, TimeOnly end)
    {
        if (start > end)
        {
            throw new ArgumentException("Початок не може бути пізніше за кінець.");
        }
        Start = start;
        End = end;
    }

    // String constructor
    public TimeInterval(string interval)
    {
        var parts = interval.Split('-', StringSplitOptions.TrimEntries);
        if (parts.Length != 2 ||
            !TimeOnly.TryParseExact(parts[0], "HH:mm", CultureInfo.InvariantCulture, out var start) ||
            !TimeOnly.TryParseExact(parts[1], "HH:mm", CultureInfo.InvariantCulture, out var end))
        {
            throw new FormatException("Неправильний формат. Очікується 'HH:mm-HH:mm'.");
        }

        if (start > end)
        {
            throw new ArgumentException("Початок не може бути пізніше за кінець.");
        }

        Start = start;
        End = end;
    }

    // Override methods
    public override string ToString() => $"[{Start:HH:mm}–{End:HH:mm}]";

    public override bool Equals(object obj)
    {
        if (obj is TimeInterval other)
        {
            return Start == other.Start && End == other.End;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }

    // Additional methods
    public int Length()
    {
        return (int)(End.ToTimeSpan() - Start.ToTimeSpan()).TotalMinutes;
    }

    public bool Overlaps(TimeInterval other)
    {
        return Start <= other.End && End >= other.Start;
    }

    public bool Overlaps(int minute)
    {
        if (minute < 0 || minute >= 24 * 60)
        {
            throw new ArgumentOutOfRangeException(nameof(minute), "Хвилина повинна бути в діапазоні [0, 1439].");
        }
        
        var pointTime = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(minute));
        return Start <= pointTime && pointTime <= End;
    }

    // Equality operators
    public static bool operator ==(TimeInterval left, TimeInterval right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(TimeInterval left, TimeInterval right)
    {
        return !(left == right);
    }
}