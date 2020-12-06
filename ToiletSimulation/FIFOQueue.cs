using System;

namespace VPS.ToiletSimulation
{
    public class FIFOQueue : Queue
    {
        public FIFOQueue() { }

        public override void Enqueue(IJob job)
        {
            // TODO ...
            throw new NotImplementedException();
        }

        public override bool TryDequeue(out IJob job)
        {
            // TODO ...
            throw new NotImplementedException();
        }

        public override void CompleteAdding()
        {
            // TODO ...
            throw new NotImplementedException();
        }
    }
}
