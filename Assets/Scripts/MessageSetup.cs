using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSetup : MonoBehaviour
{
    public TMP_Text date;
    public TMP_Text sender;
    public TMP_Text receiver;
    public TMP_Text title;
    public TMP_InputField content;
    public MailData data;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetMessage(MailData newData)
    {
        date.text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        receiver.text = newData.receiver;
        sender.text = newData.sender;
        title.text = newData.title;
        content.text = newData.content;
        data.SetData(newData);
    }
}
