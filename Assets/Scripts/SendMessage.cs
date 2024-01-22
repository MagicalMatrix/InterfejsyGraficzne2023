using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
    public GameObject messagesRoot;

    public AccountManager accountManager;
    public MailManager mailManager;
    public SelectiveActivation selectiveActivation;

    public TMP_Dropdown receiverStudent;
    public TMP_Dropdown receiverTeacher;
    public TMP_InputField title;
    public TMP_InputField content;

    // Start is called before the first frame update
    void Start()
    {
        mailManager = FindAnyObjectByType<MailManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // God save us. It's so hacky
    public void Send()
    {
        TMP_Dropdown receiver = receiverStudent;
        if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
        {
            receiver = receiverTeacher;
        }
        
        if (receiver.value == 0)
        {
            mailManager.SendMail(new MailData(receiver.options[0].text, accountManager.currentAccount.name, title.text, content.text));
        }
        selectiveActivation.SelectActive(messagesRoot);
        
        receiver.value = 0;
        title.text = "";
        content.text = "";
    }
}