using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
    public GameObject receivedMessagesPageStudent;
    public GameObject receivedMessagesPageTeacher;
    public GameObject messagesRoot;
    public GameObject message;

    public AccountManager accountManager;
    public SelectiveActivation selectiveActivation;

    public TMP_InputField receiver;
    public TMP_InputField title;
    public TMP_InputField content;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Send()
    {
        // TODO: Allow sending messages only to existing users (maybe use select box)
        
        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
        {
            GameObject newMessage = Instantiate(message, messagesRoot.transform);
            newMessage.GetComponent<MessageSetup>().SetMessage(receiver.text, title.text, content.text);
            selectiveActivation.SelectActive(receivedMessagesPageStudent);
        }
        else
        {
            // God save us. It's so hacky
            GameObject newMessage = Instantiate(message, receivedMessagesPageStudent.transform);
            newMessage.GetComponent<MessageSetup>().SetMessage(receiver.text, title.text, content.text);
            selectiveActivation.SelectActive(receivedMessagesPageTeacher);
        }

        receiver.text = "";
        title.text = "";
        content.text = "";
    }
}