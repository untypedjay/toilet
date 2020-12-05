using System;

namespace VPS.ToiletSimulation {
  public abstract class Queue : IQueue {
    protected Queue() { }

    public abstract void Enqueue(IJob job);

    public abstract bool TryDequeue(out IJob job);

    public virtual void CompleteAdding() {
      // TODO ...
      throw new NotImplementedException();
    }

    public virtual bool IsCompleted {
      get {
        // TODO ...
        throw new NotImplementedException();
      }
    }
  }
}
