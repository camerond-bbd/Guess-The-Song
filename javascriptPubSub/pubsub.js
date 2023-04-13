export default class PubSub{
  MethodsList = {};

  publish(Message,Value){
    if (this.MethodsList[Message]){
      this.MethodsList[Message].forEach(method => {
        method(Value);
      });
    }
  }

  subscribe(Message,Method){
    if (this.MethodsList[Message]){
      this.MethodsList[Message].push(Method);
    } else {
      this.MethodsList[Message] = [Method];
    }
  }
}