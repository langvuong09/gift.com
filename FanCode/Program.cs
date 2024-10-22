class Fan
{
    public const int SLOW = 1, MEDIUM = 2, FAST = 3;
    private int speed;
    private bool on;
    private double radius;
    private string color;

    public Fan(int speed, bool on, double radius, string color)
    {
        this.speed = speed;
        this.on = on;
        this.radius = radius;
        this.color = color;
    }

    public Fan(){
        speed = SLOW;
        on = false;
        radius = 5;
        color = "blue";
    }
    
    public int Speed{
        get{ return speed;}
        set{speed = value;}
    }

    public bool On{
        get{ return on;}
        set{ on = value;}
    }

    public double Radius{
        get{ return radius;}
        set{ radius = value;}
    }

    public string Color{
        get{ return color;}
        set{ color = value;}
    }

    public override string ToString()
    {
        if (on)
        {
            return $"Fan is on: Speed = {speed}, Color = {color}, Radius = {radius}";
        }
        else
        {
            return $"Fan is off: Color = {color}, Radius = {radius}";
        }
    }
}

class Program
{
    public static void Main(string[] args){
        Fan fan1 = new Fan();
        fan1.Speed = Fan.FAST;
        fan1.Radius = 10;
        fan1.Color = "yellow";
        fan1.On = true;

        Console.WriteLine(fan1.ToString());

        Fan fan2 = new Fan();
        fan1.Speed = Fan.MEDIUM;
        fan1.Radius = 5;
        fan1.Color = "blue";
        fan1.On = false;

        Console.WriteLine(fan2.ToString());
    }
}