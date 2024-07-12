using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzPhyte.SystemEvent.Samples
{
    public class EventFPSample : FPEventComponent<FPEvent>
    {
        public override void ManagerEvent()
        {
            //throw new System.NotImplementedException();
            
        }

        protected override void ExecuteEvent()
        {
            //throw new System.NotImplementedException();
        }

        protected override object GetEventData()
        {
            //throw new System.NotImplementedException();
            return GameEvent;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
