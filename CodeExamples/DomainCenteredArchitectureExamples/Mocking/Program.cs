// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

void CalculateSomething()
{
    //... some code
    if (IsLeapYear())
    {
        // do something
    }
    else
    {
        // do something else
    }
}
ICurrentTime currentTime = null;


bool IsLeapYear()
{
    DateTime rightNow = currentTime.GetCurrentTime();
    if (rightNow.Year % 100 == 0) // is end of century
    {
        if (rightNow.Year % 400 == 0) // divisible by 400
        {
            return true;
        }

        return false;
    }
    if (rightNow.Year % 4 == 0)
    {
        return true;
    }

    return false;
}
interface ICurrentTime
{
    DateTime GetCurrentTime();
}

class ActualCurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }
}

class MockCurrentTime : ICurrentTime
{
    public DateTime TheTime { get; set; }
    public DateTime GetCurrentTime()
    {
        return TheTime;
    }
}