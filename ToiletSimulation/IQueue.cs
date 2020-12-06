namespace VPS.ToiletSimulation
{
    public interface IQueue
    {
        void Enqueue(IJob job);         // enqueue a new job
        bool TryDequeue(out IJob job);  // fetch next job
        void CompleteAdding();          // signal that a producer finished adding jobs
        bool IsCompleted { get; }       // true if all producers finished adding jobs
    }
}
