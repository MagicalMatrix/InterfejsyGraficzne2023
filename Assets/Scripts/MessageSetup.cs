using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSetup : MonoBehaviour
{
    public TMP_Text receiver;
    public TMP_Text title;
    public TMP_InputField content;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMessage(string receiverText, string titleText, string contentText)
    {
        receiver.text = receiverText;
        title.text = titleText;
        content.text = contentText;
    }
}
