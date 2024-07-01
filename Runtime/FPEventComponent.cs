namespace FuzzPhyte.SystemEvent
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class FPEventComponent<T> : MonoBehaviour where T : FPEvent
    {
        public T gameEvent;
        public UnityEvent OnEventTriggered;

        protected virtual void Awake()
        {
            if (gameEvent != null)
            {
                OnEventTriggered.AddListener(() => ExecuteEvent());
            }
        }
        protected virtual void OnDisable()
        {
            if (gameEvent != null)
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
        public string GetUniqueComponentID()
        {
            return GetInstanceID().ToString();
        }
        public string GetUniqueID()
        {
            return gameEvent.UniqueID;
        }
        #endregion
    }
}
