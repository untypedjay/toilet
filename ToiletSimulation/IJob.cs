using System;

namespace VPS.ToiletSimulation {
  public interface IJob {
    string Id { get; }                // unique ID
    DateTime CreationDate { get; }    // time stamp when the job was created
    DateTime DueDate { get; }         // time stamp when the job has to be completed
    TimeSpan ProcessingTime { get; }  // time span how long the job processing takes
    DateTime ProcessedDate { get; }   // time stamp when the job was completed
    TimeSpan WaitingTime { get; }     // time span how long the job had to wait

    void Process();                   // processing method invoked by the consumer
  }
}
