namespace FuzzPhyte.SystemEvent
{
    using System.Collections.Generic;
    using UnityEngine;
    using FuzzPhyte.Utility;
    public class FP_EventManager<T> : MonoBehaviour where T : FPEvent
    {
        public static FP_EventManager<T> Instance { get; private set; }
        protected bool UsePriorityQueue = false;

        protected PriorityQueue<FPEventComponent<T>> TheEventQueue = new PriorityQueue<FPEventComponent<T>>();
        //protected Dictionary<string,FPEventComponent<T>> eventQueueComponents = new Dictionary<string, FPEventComponent<T>>();
        
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
            
            if(UsePriorityQueue)
            {
                TheEventQueue.Enqueue(eventComponent);
            }else
            {
                recordedEvents.Add(eventComponent);
            }
            Debug.Log($"Event Recorded: {eventComponent.GetEventUniqueID()} - {eventComponent.GameEvent.name}");
        }

        /// <summary>
        /// function to process misc manager events if there are any on the items
        /// </summary>
        public void ProcessRecordedManagerEvents(bool clearList = true)
        {
            //what/how to utilize the priority queue if we need to or want to
            if(UsePriorityQueue)
            {
                while (TheEventQueue.Count > 0)
                {
                    var fpComponentEvent = TheEventQueue.Dequeue();
                    fpComponentEvent.ManagerEvent();
                }
            }
            else
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
}
