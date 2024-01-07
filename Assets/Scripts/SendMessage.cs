using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
    public GameObject receivedMessagesPage;
    public GameObject messagesRoot;
    public GameObject message;

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
        GameObject newMessage = Instantiate(message, messagesRoot.transform);
        newMessage.GetComponent<MessageSetup>().SetMessage(receiver.text, title.text, content.text);
        
        selectiveActivation.SelectActive(receivedMessagesPage);
        receiver.text = "";
        title.text = "";
        content.text = "";
    }
}
