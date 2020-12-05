using System;
using System.Threading;

namespace VPS.ToiletSimulation {
  public class Person : IJob {
    public string Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public TimeSpan ProcessingTime { get; private set; }
    public TimeSpan WaitingTime { get; private set; }
    public DateTime ProcessedDate { get; private set; }

    private Person() { }
    public Person(Random random, string id) {
      Id = id;
      CreationDate = DateTime.Now;
      WaitingTime = TimeSpan.MaxValue;
      ProcessedDate = DateTime.MaxValue;

      // calculate due date (normally distributed)
      NormalRandom dueTimeRandom = new NormalRandom(random, Parameters.MeanDueTime, Parameters.StdDeviationDueTime);
      TimeSpan dueTime = TimeSpan.FromMilliseconds((int)Math.Round(dueTimeRandom.NextDouble()));
      DueDate = CreationDate + dueTime;

      // calculate required processing time (normally distributed)
      NormalRandom processingTimeRandom = new NormalRandom(random, Parameters.MeanProcessingTime, Parameters.StdDeviationProcessingTime);
      double processingTime;
      do {
        processingTime = processingTimeRandom.NextDouble();
      }
      while (processingTime <= 0.0);
      ProcessingTime = TimeSpan.FromMilliseconds((int)Math.Round(processingTime));
    }

    public void Process() {
      WaitingTime = DateTime.Now - CreationDate;

      if (Parameters.DisplayJobProcessing) Console.WriteLine(Id + ": Processing ...   ");
      Thread.Sleep(ProcessingTime);  // simulate processing

      ProcessedDate = DateTime.Now;

      if (Parameters.DisplayJobProcessing) {
        if (ProcessedDate <= DueDate) {
          Console.WriteLine(Id + ": Ahhhhhhh, much better ...");
        } else {
          Console.WriteLine(Id + ": OOOOh no, too late ......");
        }
      }

      Analysis.CountJob(this);
    }
  }
}
