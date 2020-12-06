using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VPS.ToiletSimulation
{
    public class ToiletQueue : Queue
    {
        private SortedSet<IJob> queue = new SortedSet<IJob>(new ByDueDate());
        private object _lock = new object();
        public ToiletQueue() { }

        public override void Enqueue(IJob job)
        {
            lock (_lock)
            {
                queue.Add(job);
            }
        }

        public override bool TryDequeue(out IJob job)
        {
            lock (_lock)
            {
                if (queue.Count > 0)
                {
                    job = queue.First();
                    queue.Remove(job);
                    return true;
                }

                job = null;
                return false;
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

    public class ByDueDate : IComparer<IJob>
    {
        public int Compare(IJob x, IJob y)
        {
            if (x.DueDate < DateTime.Now)
            {
                return 1;
            }

            if (y.DueDate < DateTime.Now)
            {
                return -1;
            }

            return DateTime.Compare(y.DueDate, x.DueDate);
        }
    }
}
