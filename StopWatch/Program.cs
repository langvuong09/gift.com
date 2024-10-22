using System;

class Stopwatch
{
    private DateTime startTime;
    private DateTime endTime;

    public Stopwatch()
    {
        startTime = DateTime.Now;
    }

    public void Start()
    {
        startTime = DateTime.Now;
    }

    public void Stop()
    {
        endTime = DateTime.Now;
    }

    public double GetElapsedTime()
    {
        TimeSpan elapsedTime = endTime - startTime;
        return elapsedTime.TotalMilliseconds;
    }

    public DateTime GetStartTime()
    {
        return startTime;
    }

    public DateTime GetEndTime()
    {
        return endTime;
    }
}

class Program
{
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    public static void Main(string[] args)
    {
        int n = 100000;
        int[] array = new int[n];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            array[i] = rand.Next(0, 1000000);
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        SelectionSort(array);
        stopwatch.Stop();
        Console.WriteLine($"Thời gian thực thi thuật toán sắp xếp chọn (Selection Sort) là: {stopwatch.GetElapsedTime()} mili giây.");
    }
}
