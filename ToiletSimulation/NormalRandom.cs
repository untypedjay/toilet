using System;

namespace VPS.ToiletSimulation {
  public class NormalRandom {
    private Random random;
    private double mu;
    private double sigma;

    public NormalRandom(Random random, double mu, double sigma) {
      this.random = random;
      this.mu = mu;
      this.sigma = sigma;
    }

    public double NextDouble() {
      double a = random.NextDouble();
      double b = random.NextDouble();
      double c = Math.Sqrt(-2.0 * Math.Log(a)) * Math.Cos(2.0 * Math.PI * b);

      return c * sigma + mu;
    }
  }
}
