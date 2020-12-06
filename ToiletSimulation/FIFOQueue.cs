using System;
using System.Collections.Generic;

namespace VPS.ToiletSimulation
{
    public class FIFOQueue : Queue
    {
        private Queue<IJob> queue = new Queue<IJob>();
        public FIFOQueue() { }

        public override void Enqueue(IJob job)
        {
            queue.Enqueue(job);
        }

        public override bool TryDequeue(out IJob job)
        {
            if (queue.Count > 0)
            {
                job = queue.Dequeue();
                return true;
            }

            job = null;
            return false;
        }

        public override void CompleteAdding()
        {
            // TODO ...
            throw new NotImplementedException();
        }
    }
}
