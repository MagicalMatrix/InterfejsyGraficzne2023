using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public Account[] accounts;
    public Account currentAccount;
    
    public GameObject mainContent;
    public GameObject teacherReceiverDropdown;
    public GameObject studentReceiverDropdown;

    private MailManager _mailManager;
    
    private void Start()
	{
		accounts = gameObject.GetComponentsInChildren<Account>();
		_mailManager = FindAnyObjectByType<MailManager>();
	}

	public Account[] GetAccountsOfSubtype(string subtype)
	{
		List<Account> res = new List<Account>();
		for (int i = 0; i < accounts.Length; i++ )
		{
			if (subtype == accounts[i].subtype)
			{
				res.Add(accounts[i]);
			}
		}

		return res.ToArray();
	}


	public void SwitchAccount(Account acc)
	{
		// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
		// ...
		// ┬─┬ノ( º _ ºノ)
		currentAccount = acc;
		if (currentAccount.type == Enums.AccountType.Nauczyciel)
		{
			teacherReceiverDropdown.SetActive(true);
			studentReceiverDropdown.SetActive(false);
		}
		else
		{
			teacherReceiverDropdown.SetActive(false);
			studentReceiverDropdown.SetActive(true);
		}
		
		_mailManager.DisplayMails(false);
	}

	public void Logout()
	{
		mainContent.SetActive(false);
	}
}
