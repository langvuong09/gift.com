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
    
    public int getSpeed(){
        return speed;
    }
    public void setSpeed(int speed){
        this.speed = speed;
    }

    public bool getOn(){
        return on;
    }
    public void setOn(bool on){
        this.on = on;
    }

    public double getRadius(){
        return radius;
    }
    public void setRadius(double radius){
        this.radius = radius;
    }

    public string getColor(){
        return color;
    }
    public void setColor(string color){
        this.color = color;
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
        fan1.setSpeed(Fan.FAST);
        fan1.setRadius(10);
        fan1.setColor("yellow");
        fan1.setOn(true);

        Fan fan2 = new Fan();
        fan1.setSpeed(Fan.MEDIUM);
        fan1.setRadius(5);

        Console.WriteLine(fan1.ToString());
        Console.WriteLine(fan2.ToString());
    }
}