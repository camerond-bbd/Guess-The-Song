using HowToBlazor.Utils;
using Microsoft.AspNetCore.Components;

namespace HowToBlazor.Components
{
    public partial class ActorAddComp: ComponentBase
    {
        public List<string> lstActors = new List<string>();
        public PubSubEvent<string> addActorDel;

        public void addActor(string Value)
        {
            this.lstActors.Add(Value);
        }

        public ActorAddComp()
        {
            addActorDel = new PubSubEvent<string>(this.addActor);
        }
    }
}
