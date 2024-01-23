using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    public Account teacherAccount;
    public Account studentAccount;

    public GameObject loginPage;
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
        
        if (username.ToLower() == studentAccount.username && password == "123")
        {
            manager.SwitchAccount(studentAccount);
            loginPage.SetActive(false);
            usernameInput.text = "";
        }
        else if (username.ToLower() == teacherAccount.username && password == "123")
        {
            manager.SwitchAccount(teacherAccount);
            loginPage.SetActive(false);
            usernameInput.text = "";
        }
        else
        {
            errorMessage.text = "Nieprawidłowy login lub hasło";
        }
    }
}