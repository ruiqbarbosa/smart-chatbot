import React from "react";
import { StyleSheet, Text, View } from "react-native";
import { GiftedChat } from "react-native-gifted-chat";
import { DirectLine } from "botframework-directlinejs";

const directLine = new DirectLine({
  secret: "##secret### - you should get the key from a secure place to connect to your bot"
});

const botMessageToGiftedMessage = botMessage => ({
  ...botMessage,
  _id: botMessage.id,
  createdAt: botMessage.timestamp,
  user: {
    _id: 2,
    name: "React Native",
    avatar:
      "https://cdn6.f-cdn.com/contestentries/1476201/32214673/5c7f869653351_thumb900.jpg"
  }
});

function giftedMessageToBotMessage(message) {
  return {
    from: { id: 1, name: "John Doe" },
    type: "message",
    text: message.text
  };
}

export default class App extends React.Component {
  constructor(props) {
    super(props);

    directLine.activity$.subscribe(botMessage => {
      const newMessage = botMessageToGiftedMessage(botMessage);
      const isSentMessage = String(JSON.stringify(newMessage)).includes("John Doe");

      if (!isSentMessage)
        this.setState({ messages: [newMessage, ...this.state.messages] });
    });
  }

  state = {
    messages: [
      {
        _id: 1,
        text: "Olá. Eu sou o Assistente Pessoal, em que posso ajudar?",
        createdAt: new Date(),
        user: {
          _id: 2,
          name: "React Native",
          avatar: "https://cdn6.f-cdn.com/contestentries/1476201/32214673/5c7f869653351_thumb900.jpg"
        }
      }
    ]
  };

  onSend = messages => {
    this.setState({ messages: [...messages, ...this.state.messages] });
    messages.forEach(message => {
      directLine
        .postActivity(giftedMessageToBotMessage(message))
        .subscribe(() => console.log("success"), () => console.log("failed"));
    });
  };

  render() {
    return (
      <View style={styles.container}>
        <GiftedChat
          user={{
            _id: 1
          }}
          messages={this.state.messages}
          onSend={this.onSend}
        />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1
  }
});