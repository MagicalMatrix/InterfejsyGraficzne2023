using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailData : MonoBehaviour
{
    public string receiver;
    public string sender;
    public string title;
    public string content;
    
    public MailData(string receiver, string sender, string title, string content)
    {
        this.receiver = receiver;
        this.sender = sender;
        this.title = title;
        this.content = content;
    }
    
    public MailData() {}
    
    public void SetData(MailData newData)
    {
        this.receiver = newData.receiver;
        this.sender = newData.sender;
        this.title = newData.title;
        this.content = newData.content;
    }
}
