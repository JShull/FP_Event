namespace FuzzPhyte.SystemEvent
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FP_EventManager<T> : MonoBehaviour where T : FPEvent
    {
        public static FP_EventManager<T> Instance { get; private set; }

        private List<FPEventComponent<T>> recordedEvents = new List<FPEventComponent<T>>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void RecordEvent(FPEventComponent<T> eventComponent)
        {
            recordedEvents.Add(eventComponent);
            Debug.Log($"Event Recorded: {eventComponent.GetUniqueID()} - {eventComponent.gameEvent.name}");
        }

        /// <summary>
        /// function to process misc manager events if there are any on the items
        /// </summary>
        public void ProcessRecordedManagerEvents(bool clearList = true)
        {
            foreach (var eventComponent in recordedEvents)
            {
                eventComponent.ManagerEvent();
            }
            if(clearList)
            {
                recordedEvents.Clear();
            }
        }
    }
}
