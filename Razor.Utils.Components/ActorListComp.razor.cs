using HowToBlazor.Utils;
using Microsoft.Extensions.Logging;

namespace Razor.Utils.Components
{
    public partial class ActorListComp
    {
        public List<string> lstActors = new List<string>();

        public string inValue = "Invalue is ";
        public string displayData = "";
        public string temp = "my Temp";
        public void addActor(string Value)
        {
            //this.lstActors.Add(Value);
            inValue = Value;
            genPage();
            this.StateHasChanged();
        }

        public string genPage()
        {
            return this.inValue;
        }

        public ActorListComp()
        {
            PubSubManager.Subscribe<string>("addedActor", this.addActor);
        }

        public void clickUpdate()
        {
            displayData = $"Current Data is: {this.inValue}" ;
        }
    }
}
