using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public GameObject mailsRoot;
    public GameObject messageTemplate;

    private AccountManager _accountManger;
    
    void Start()
    {
        _accountManger = FindAnyObjectByType<AccountManager>();
        DisplayMails(false);
    }

    void Update()
    {
        
    }

    public void DisplayMails(bool showSent)
    {
        string currentUserName = _accountManger.currentAccount.name;
        foreach (Transform mail in mailsRoot.transform)
        {
            MailData data = mail.gameObject.GetComponent<MailData>();
            mail.gameObject.SetActive(showSent && data.sender.StartsWith(currentUserName) || !showSent && data.receiver.StartsWith(currentUserName));
        }
    }

    public void SendMail(MailData data)
    {
        GameObject newMessage = Instantiate(messageTemplate, mailsRoot.transform);
        newMessage.GetComponent<MessageSetup>().SetMessage(data);
        DisplayMails(false);
    }
}
