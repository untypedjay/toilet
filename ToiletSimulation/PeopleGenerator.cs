using System;
using System.Threading;

namespace VPS.ToiletSimulation
{
    public class PeopleGenerator
    {
        public string Name { get; private set; }

        private int personId;
        private Random random;
        private ExponentialRandom exponentialRandom;
        private IQueue queue;

        public PeopleGenerator(string name, IQueue queue, int randomSeed)
        {
            Name = name;
            this.queue = queue;
            random = new Random(randomSeed);
            exponentialRandom = new ExponentialRandom(random, 1.0 / Parameters.MeanArrivalTime);
        }

        public void Produce()
        {
            var thread = new Thread(Run);
            thread.Name = Name;
            thread.Start();
        }

        private void Run()
        {
            personId = 0;
            for (int i = 0; i < Parameters.JobsPerProducer; i++)
            {
                Thread.Sleep((int)Math.Round(exponentialRandom.NextDouble()));
                personId++;
                queue.Enqueue(new Person(random, Name + " - Person " + personId.ToString("00")));
            }
        }
    }
}
