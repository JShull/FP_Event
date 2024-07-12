namespace FuzzPhyte.SystemEvent
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class FPEventComponent<T> :MonoBehaviour,IComparable<FPEventComponent<T>> where T : FPEvent
    {
        public T GameEvent;
        public UnityEvent OnEventTriggered;

        protected virtual void Awake()
        {
            if (GameEvent != null)
            {
                OnEventTriggered.AddListener(() => ExecuteEvent());
            }
        }
        protected virtual void OnDisable()
        {
            if (GameEvent != null)
            {
                OnEventTriggered.RemoveAllListeners();
            }
        }
        protected abstract object GetEventData();
        protected abstract void ExecuteEvent();
        public abstract void ManagerEvent();

        public virtual void TriggerEvent()
        {
            if (OnEventTriggered != null)
            {
                OnEventTriggered.Invoke();
            }
            //manager update
            FP_EventManager<T>.Instance.RecordEvent(this);// Pass the component itself
        }
        #region  Return functions
        /// <summary>
        /// This is the unique instance ID for the component
        /// </summary>
        /// <returns></returns>
        public string GetUniqueComponentID()
        {
            return GetInstanceID().ToString();
        }
        /// <summary>
        /// This is a 'unique id' for the event but the event could be shared by other instances of FPEventComponent
        /// </summary>
        /// <returns></returns>
        public string GetEventUniqueID()
        {
            return GameEvent.UniqueID;
        }
        #endregion
        public virtual int CompareTo(FPEventComponent<T> other)
        {
            if (other == null) return 1;
            return GameEvent.Priority.CompareTo(other.GameEvent.Priority);
        }
    }
}
