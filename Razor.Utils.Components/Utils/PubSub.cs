using System.Collections.Generic;

namespace HowToBlazor.Utils
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
        
        public void Subscribe(string listenID, PubSubEvent<T> methodToCall){
            if (listenerList.ContainsKey(listenID))
            {
                List<PubSubEvent<T>> delegates = listenerList[listenID];
                delegates.Add(methodToCall);
            }
            else
                listenerList.Add(listenID,new List<PubSubEvent<T>>() { methodToCall});
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
