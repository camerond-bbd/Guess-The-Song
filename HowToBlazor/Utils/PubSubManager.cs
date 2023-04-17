namespace HowToBlazor.Utils
{
    public static class PubSubManager
    {
        public static List<Object> lstPubSubs;
        static PubSubManager() { 
            lstPubSubs = new List<Object>();
            lstPubSubs.Add(new PubSub<string>());
        }

        void Publish<T>()
        {

        }
    }
}
