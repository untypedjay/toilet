using System;

namespace VPS.ToiletSimulation {
  public static class Analysis {
    private static object locker = new object();
    private static int jobs = 0;
    private static int starvedJobs = 0;
    private static TimeSpan totalWaitingTime = TimeSpan.Zero;

    public static void Reset() {
      lock (locker) {
        jobs = 0;
        starvedJobs = 0;
        totalWaitingTime = TimeSpan.Zero;
      }
    }

    public static void CountJob(IJob job) {
      lock (locker) {
        jobs++;
        if (job.ProcessedDate > job.DueDate) {
          starvedJobs++;
        }
        totalWaitingTime += job.WaitingTime;
      }
    }

    public static void Display() {
      lock (locker) {
        Console.WriteLine();
        Console.WriteLine("Parameters:");
        Console.WriteLine("-----------");
        Console.WriteLine($"Mean Arrival Time:         {TimeSpan.FromMilliseconds(Parameters.MeanArrivalTime)}");
        Console.WriteLine($"Mean Due Time:             {TimeSpan.FromMilliseconds(Parameters.MeanDueTime)}");
        Console.WriteLine($"Std. Dev. Due Time:        {TimeSpan.FromMilliseconds(Parameters.StdDeviationDueTime)}");
        Console.WriteLine($"Mean Processing Time:      {TimeSpan.FromMilliseconds(Parameters.MeanProcessingTime)}");
        Console.WriteLine($"Std. Dev. Processing Time: {TimeSpan.FromMilliseconds(Parameters.StdDeviationProcessingTime)}");

        Console.WriteLine();
        Console.WriteLine("Analysis:");
        Console.WriteLine("---------");
        Console.WriteLine($"Jobs:                      {jobs}");
        Console.WriteLine($"Starved Jobs:              {starvedJobs}");
        Console.WriteLine($"Starvation Ratio:          {starvedJobs / ((double)jobs) * 100}%");
        Console.WriteLine($"Total Waiting Time:        {totalWaitingTime}");
        Console.WriteLine($"Mean Waiting Time:         {TimeSpan.FromMilliseconds(totalWaitingTime.TotalMilliseconds / jobs)}");
      }
    }
  }
}
