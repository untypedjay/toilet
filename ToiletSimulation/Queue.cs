using System;

namespace VPS.ToiletSimulation
{
    public abstract class Queue : IQueue
    {
        private int CompletedProducers = 0;
        private bool AllProducersDone = false;
        protected Queue() { }

        public abstract void Enqueue(IJob job);

        public abstract bool TryDequeue(out IJob job);

        public virtual void CompleteAdding()
        {
            CompletedProducers++;
            if (CompletedProducers == Parameters.Producers)
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
