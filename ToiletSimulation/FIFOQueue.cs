using System;
using System.Collections.Generic;
using System.Threading;

namespace VPS.ToiletSimulation
{
    public class FIFOQueue : Queue
    {
        private Queue<IJob> queue = new Queue<IJob>();
        private static Mutex mutex = new Mutex();
        public FIFOQueue() { }

        public override void Enqueue(IJob job)
        {
            queue.Enqueue(job);
        }

        public override bool TryDequeue(out IJob job)
        {
            try
            {
                mutex.WaitOne();
                if (queue.Count > 0)
                {
                    job = queue.Dequeue();
                    return true;
                }

                job = null;
                return false;
            }
            finally
            {
                mutex.ReleaseMutex();
            }

        }

        public override void CompleteAdding()
        {
            WorkingProducers--;
            if (WorkingProducers == 0)
            {
                AllProducersDone = true;
            }
        }
    }
}
