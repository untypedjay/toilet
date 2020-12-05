using System;

namespace VPS.ToiletSimulation {
  public class ExponentialRandom {
    private Random random;
    private double lambda;

    public ExponentialRandom(Random random, double lambda) {
      this.random = random;
      this.lambda = lambda;
    }

    public double NextDouble() {
      return -Math.Log(random.NextDouble()) / lambda;
    }
  }
}
