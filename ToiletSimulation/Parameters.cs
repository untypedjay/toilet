namespace VPS.ToiletSimulation {
  public static class Parameters {
    // number of producers
    public static int Producers {
      get { return 2; }
    }
    // number of generated jobs per producer
    public static int JobsPerProducer {
      get { return 200; }
    }
    // number of consumers
    public static int Consumers {
      get { return 2; }
    }
    // if true, output of job processing is displayed
    public static bool DisplayJobProcessing {
      get { return true; }
    }
    // mean time between arrival of new jobs (milliseconds)
    public static double MeanArrivalTime {
      get { return 100; }
    }
    // mean of the time span in which a job has to be processed (milliseconds)
    public static int MeanDueTime {
      get { return 500; }
    }
    // standard deviation of the time span in which a job has to be processed (milliseconds)
    public static int StdDeviationDueTime {
      get { return 150; }
    }
    // mean of the time required to process a job (milliseconds)
    public static int MeanProcessingTime {
      get { return 100; }
    }
    // standard deviation of the time required to process a job (milliseconds)
    public static int StdDeviationProcessingTime {
      get { return 25; }
    }
  }
}
