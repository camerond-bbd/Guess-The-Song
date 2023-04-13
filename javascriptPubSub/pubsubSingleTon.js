import PubSub from "./pubsub.js"

export class pubSubSingleton{
  static pubSub = new PubSub();
  
  static publish(Message,Value){
    pubSubSingleton.pubSub.publish(Message,Value)
  }

  static subscribe(Message,Method){
    pubSubSingleton.pubSub.subscribe(Message,Method)
  }
}