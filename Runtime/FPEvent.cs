namespace FuzzPhyte.SystemEvent
{
    using FuzzPhyte.Utility;
    using System;
    /// <summary>
    /// abstract class for all 'events' for data type classification
    /// </summary>
    [Serializable]
    public abstract class FPEvent : FP_Data,IComparable<FPEvent>
    {
        /// <summary>
        /// Important for the order of execution
        /// </summary>
        public int Priority { get; set; }
        public abstract void Execute(object data = null);
        public virtual int CompareTo(FPEvent other)
        {
            if (other == null) return 1;
            return Priority.CompareTo(other.Priority);
        }
    }
}
