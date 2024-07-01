namespace FuzzPhyte.SystemEvent
{
    using FuzzPhyte.Utility;
    /// <summary>
    /// abstract class for all 'events' for data type classification
    /// </summary>
    public abstract class FPEvent : FP_Data
    {
        public int Priority { get; set; }
        public abstract void Execute(object data = null);
    }
}
