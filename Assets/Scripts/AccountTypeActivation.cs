using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountTypeActivation : MonoBehaviour
{
    private AccountManager accountManager;
    // Start is called before the first frame update
    void Awake()
    {
        accountManager = GameObject.FindAnyObjectByType<AccountManager>();
    }

	private void Start()
	{
		if (!(accountManager.currentAccount.type == Enums.AccountType.Nauczyciel))
		{
            gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
