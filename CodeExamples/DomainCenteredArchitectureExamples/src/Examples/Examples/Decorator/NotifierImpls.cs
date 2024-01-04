namespace Examples.Decorator;

public class SmsNotifier : INotifier
{
    private readonly INotifier? next;

    public SmsNotifier(INotifier? next)
        => this.next = next;

    public void Send(string msg)
    {
        // send sms
        next?.Send(msg);
    }
}

public class FacebookNotifier : INotifier
{
    private readonly INotifier? next;

    public FacebookNotifier(INotifier? next)
        => this.next = next;


    public void Send(string msg)
    {
        // send msg on Facebook
        next?.Send(msg);
    }
}

public class NotifierEnd : INotifier
{
    public void Send(string msg) {}
}

public class NotificationService
{
    public void SendNotification(string msg)
    {
        INotifier sms = new SmsNotifier(null);
        INotifier fb = new FacebookNotifier(sms);

        fb.Send("Hello World");
    }
}