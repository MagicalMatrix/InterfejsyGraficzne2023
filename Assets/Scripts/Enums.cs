using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum LessonStatus
    {
        Default = 0,
        Nan = 1,
        Obecny = 2,
        Nieobecny = 3,
        Usprawiedliwiony = 4,
        Odwolane = 5
	}

	public enum AccountType
	{
        Uczen = 0,
        Nauczyciel = 1,
        Admin = 2
    }

}
