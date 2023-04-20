using System.Collections.Generic;
using System.Reflection;

namespace GuessTheSong.Utils
{
    public class PubSubEvent<T>
    {
        public delegate void Event<T>(T Values);

        public Event<T> StoredEvent { get; set; }

        public PubSubEvent( Event<T> givenEvent)
        {
            this.StoredEvent = givenEvent;
        }
    }

    public class PubSub<T>
    {
        Dictionary<string, List<PubSubEvent<T>>> listenerList = new Dictionary<string, List<PubSubEvent<T>>>();
        
        public bool containsEvent(PubSubEvent<T> Event,string message)
        {
            foreach (PubSubEvent<T> eventIndex in this.listenerList[message])
            {
                if (eventIndex.StoredEvent.GetMethodInfo() == Event.StoredEvent.GetMethodInfo())
                    return true;
            }
            return false;
        }

        public bool removeOldEvent(PubSubEvent<T> Event, string message)
        {
            bool removed = false;
            List<PubSubEvent<T>> list = this.listenerList[message];
            for (int i = list.Count-1; i >= 0;i--)
            {
                PubSubEvent < T > eventIndex = list[i];
                if (eventIndex.StoredEvent.GetMethodInfo() == Event.StoredEvent.GetMethodInfo())
                {
                    removed = true;
                    this.listenerList[message].Remove(eventIndex);
                }
            }
            return removed;
        }

        public void Subscribe(string listenID, PubSubEvent<T> methodToCall){
            if (listenerList.ContainsKey(listenID))
            {
                List<PubSubEvent<T>> delegates = listenerList[listenID];
                this.removeOldEvent(methodToCall, listenID);
                delegates.Add(methodToCall);
            }
            else
                listenerList.Add(listenID,new List<PubSubEvent<T>>() { methodToCall});
        }

        public void UnSubscribe(string listenID, PubSubEvent<T> methodToCall)
        {
            if (listenerList.ContainsKey(listenID))
            {
                List<PubSubEvent<T>> delegates = listenerList[listenID];
                delegates.Remove(methodToCall);
            }
            else
                listenerList.Add(listenID, new List<PubSubEvent<T>>() { methodToCall });
        }

        public void Publish(string listenID, T Value)
        {
            /*if (!listenerList.ContainsKey(listenID))
                return;*/

            List<PubSubEvent<T>> delegates = listenerList[listenID];
            foreach (PubSubEvent<T> delegated in delegates)
            {
                delegated.StoredEvent(Value);
            }
        }

        public PubSub(string listenID, PubSubEvent<T> methodToCall)
        {
            this.Subscribe(listenID, methodToCall);
        }
    }
}
