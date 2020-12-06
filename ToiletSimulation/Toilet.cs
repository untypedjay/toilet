using System;
using System.Threading;

namespace VPS.ToiletSimulation
{
    public class Toilet
    {
        public string Name { get; private set; }

        private IQueue queue;
        private Thread consumer;

        public Toilet(string name, IQueue queue)
        {
            Name = name;
            this.queue = queue;
        }

        public void Consume()
        {
            consumer = new Thread(Run);
            consumer.Start();
        }

        private void Run()
        {
            while (!queue.IsCompleted)
            {
                if (queue.TryDequeue(out IJob job))
                {
                    job.Process();
                }
                else
                {
                    Console.WriteLine("No jobs in queue.");
                    // TODO: put thread to sleep
                }
            }
            Console.WriteLine("Everything done.");
        }

        public void Join()
        {
            consumer.Join();
        }
    }
}
