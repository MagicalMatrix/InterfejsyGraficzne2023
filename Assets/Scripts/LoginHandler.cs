using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    public Account teacherAccount;
    public Account studentAccount;

    public GameObject mainContent;
    public AccountManager manager;

    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorMessage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Signin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        passwordInput.text = "";
        errorMessage.text = "";
        
        if (username.ToLower() == "jankowal" && password == "123")
        {
            manager.SwitchAccount(studentAccount);
            mainContent.SetActive(true);
            usernameInput.text = "";
        }
        else if (username.ToLower() == "william" && password == "123")
        {
            manager.SwitchAccount(teacherAccount);
            mainContent.SetActive(true);
            usernameInput.text = "";
        }
        else
        {
            errorMessage.text = "Nieprawidłowy login lub hasło";
        }
    }
}