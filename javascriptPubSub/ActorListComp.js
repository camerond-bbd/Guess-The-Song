export default class ActorList{
  static _labelID = 'ActorListLabel'
  static _textAreaID = 'ActorListMemo'
  static _textArea = undefined
  static _compDisplay = `
  <label for="" id="${ActorList._labelID}">Count: {}</label>
  <textarea rows = "40" name="" id="${ActorList._textAreaID}" cols="30" rows="10"></textarea>
  `
  render(renderTarget){
    document.getElementById(renderTarget).innerHTML = ActorList._compDisplay;
    ActorList._textArea = document.querySelector(`#${ActorList._textAreaID}`);
  }

  updateOn = (Value) =>{
    console.log(Value.join('\n'))
    ActorList._textArea.innerText = Value.join('\n');
  }
}