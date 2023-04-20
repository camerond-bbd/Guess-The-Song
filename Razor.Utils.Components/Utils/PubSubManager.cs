namespace HowToBlazor.Utils
{
    public static class PubSubManager
    {
        public static Dictionary<System.Type,Object> dictPubSub;
        static PubSubManager() { 
           dictPubSub = new Dictionary<System.Type, Object>();
        }

        public static void Publish<T>(string Message, T Value)
        {
            if (dictPubSub.ContainsKey(typeof(T)))
            {
                PubSub<T> pubSub = (PubSub<T>)dictPubSub[typeof(T)];
                pubSub.Publish(Message, Value);
            }
        }

        public static void Subscribe<T>(string Message, PubSubEvent<T>.Event<T> methodToCall)
        {
            if (dictPubSub.ContainsKey(typeof(T)))
            {
                PubSub<T> pubSub = (PubSub<T>)dictPubSub[typeof(T)];
                pubSub.Subscribe(Message, new PubSubEvent<T>(methodToCall));
            }
            else
            {
                dictPubSub.Add(typeof(T), new PubSub<T>(Message, new PubSubEvent<T>(methodToCall)));
            }
        }
    }
}
