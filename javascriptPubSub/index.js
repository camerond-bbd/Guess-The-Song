import { pubSubSingleton } from "./pubsubSingleTon.js";
import { ActorAddComp } from "./ActorAddComp.js";
import ActorList from "./ActorListComp.js";

let ActorListArr = [];

let mComp = new ActorAddComp();
mComp.render("ActorAdd");

let mActorList = new ActorList();
mActorList.render("ActorList")

mComp.setOnClickEvent(()=>{
  ActorListArr.push(ActorAddComp._inputBox.value)
  pubSubSingleton.publish("onActorPublish",ActorListArr)
})

pubSubSingleton.subscribe("onActorPublish",mActorList.updateOn);