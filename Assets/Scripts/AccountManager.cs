using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public Account[] accounts;
    public Account currentAccount;


	private void Start()
	{
		accounts = gameObject.GetComponentsInChildren<Account>();
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
}
