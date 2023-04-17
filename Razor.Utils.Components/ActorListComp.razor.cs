using HowToBlazor.Utils;
using Microsoft.Extensions.Logging;

namespace Razor.Utils.Components
{
    public partial class ActorListComp
    {
        public List<string> lstActors = new List<string>();

        public string inValue = "Invalue is ";
        public void addActor(string Value)
        {
            //this.lstActors.Add(Value);
            inValue = Value;
            genPage();
        }

        public string genPage()
        {
            return this.inValue;
        }

        public ActorListComp()
        {
            PubSubManager.Subscribe<string>("addedActor", this.addActor);
        }
    }
}
