using System;

namespace VPS.ToiletSimulation
{
    public abstract class Queue : IQueue
    {
        protected int WorkingProducers = Parameters.Producers;
        protected bool AllProducersDone = false;
        protected Queue() { }

        public abstract void Enqueue(IJob job);

        public abstract bool TryDequeue(out IJob job);

        public virtual void CompleteAdding()
        {
            WorkingProducers--;
            if (WorkingProducers == 0)
            {
                AllProducersDone = true;
            }
        }

        public virtual bool IsCompleted
        {
            get
            {
                return AllProducersDone;
            }
        }
    }
}
