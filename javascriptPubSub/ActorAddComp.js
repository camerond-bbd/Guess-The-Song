export class ActorAddComp{

  static buttonID = 'ActorAddButton'
  static _inputBox = undefined
  static _inputID = 'ActorAddInput'
  static _compDisplay = `
  <input type="text" id="${ActorAddComp._inputID}">
  <button id="${ActorAddComp.buttonID}">Submit</button>
  `
  render(renderTarget){
    document.getElementById(renderTarget).innerHTML = ActorAddComp._compDisplay;
    document.getElementById(ActorAddComp.buttonID).addEventListener("click",this.onClick);
    ActorAddComp._inputBox = document.getElementById(ActorAddComp._inputID);
  }
  
  setOnClickEvent(Event){
    document.getElementById(ActorAddComp.buttonID).removeEventListener("click",this.onClick);
    this.onClick = Event;
    document.getElementById(ActorAddComp.buttonID).addEventListener("click",this.onClick);
  }
  
  onClick = ()=>{
    alert('Gaming')
  }
}