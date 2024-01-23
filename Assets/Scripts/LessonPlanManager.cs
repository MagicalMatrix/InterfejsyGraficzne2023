using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPlanManager : MonoBehaviour
{
    private AccountManager accountManager;
    public string[] lessonTimes;

    public GameObject PresenseObject;
    public GameObject PresenseSendPlace;
    public PresenseSender presenseSender;
    public List<PresenseObject> presenses;

    public LessonView[] lessonViews;
    public LessonData[] lessons;
    public LessonsInstances lessonsInstances;

    //list of status colors
    public Color[] statusColor;
    // Start is called before the first frame update
    void Start()
    {
        lessons = gameObject.GetComponentsInChildren<LessonData>();
        lessonViews = gameObject.GetComponentsInChildren<LessonView>();
        SetTimes();
        accountManager = GameObject.FindAnyObjectByType<AccountManager>();
    }

	private void OnEnable()
	{
        UpdateViews();
    }

    public void UpdatePresenses(LessonView lesson)
	{
        for (int i = 0; i < presenses.Count; i++)
		{
            Destroy(presenses[i].gameObject);
		}
        presenses.Clear();

        int id = lesson.id;

        Account[] lessonAccounts = accountManager.GetAccountsOfSubtype(lesson.lessonTeacher_Class.text);
        for (int i = 0; i < lessonsInstances.lessonId.Count; i++)
		{
            if (lessonsInstances.lessonId[i] == id)
			{
                for (int j = 0; j < lessonAccounts.Length; j++)
                {
                    if (lessonsInstances.accountName[i] == lessonAccounts[j].name)
                    {
                        //add per
                        PresenseObject newPresense = Instantiate(PresenseObject, PresenseSendPlace.transform).GetComponent<PresenseObject>();
                        newPresense.person.text = lessonAccounts[j].name;
                        newPresense.obecnosc.value = lessonsInstances.status[i] - 2;
                        newPresense.id = i;

                        presenses.Add(newPresense);
                        newPresense.gameObject.SetActive(true);
                    }
                }
            }
		}
	}

    public void SendPresense(PresenseSender sender)
	{
        PresenseObject[] presenses = sender.GetComponentsInChildren<PresenseObject>();

        for (int i = 0; i < presenses.Length; i++)
		{
            lessonsInstances.status[presenses[i].id] = presenses[i].obecnosc.value + 2;

		}
	}


	void SetTimes()
	{
        for (int i = 0; i < lessonViews.Length; i++)
		{
            lessonViews[i].timeStart.text = lessonTimes[i % 8 * 2];
            lessonViews[i].timeEnd.text = lessonTimes[i % 8 * 2 + 1];
        }
	}

    public void UpdateViews()
	{
        bool[] updated = new bool[40];
        for (int i = 0; i < lessons.Length; i++)
		{


            int id = lessons[i].id;
            //is lesson by the logged teacher 
            if (lessons[i].lessonTeacher == accountManager.currentAccount.name)
			{
                lessonViews[id].presenseButton.interactable = true;
                lessonViews[id].id = i;
                lessonViews[id].lessonName.text = lessons[i].name;
                lessonViews[id].lessonPlace.text = lessons[i].lessonPlace;
                lessonViews[id].lessonTeacher_Class.text = lessons[i].lessonClass;
                lessonViews[i].background.color = statusColor[(int)Enums.LessonStatus.Default];
                updated[lessons[i].id] = true;
                Debug.Log(lessons[i].id);
			}
            //is lesson meant for student class
            else if (lessons[i].lessonClass == accountManager.currentAccount.subtype)
			{
                lessonViews[id].presenseButton.interactable = false;
                lessonViews[id].id = i;
                lessonViews[id].lessonName.text = lessons[i].lessonName;
                lessonViews[id].lessonPlace.text = lessons[i].lessonPlace;
                lessonViews[id].lessonTeacher_Class.text = lessons[i].lessonTeacher;
                updated[lessons[i].id] = true;

                //status instance:
                for (int j = 0; j < lessonsInstances.status.Count; j++)
				{
                    if (accountManager.currentAccount.name == lessonsInstances.accountName[j])
					{
                        //change status
                        lessonViews[i].background.color = statusColor[lessonsInstances.status[j]];
					}
				}
            }
		}
        for (int i = 0; i < lessonViews.Length; i++)
		{
            //all discarded views schould be empty
            if (!updated[i])
			{
                lessonViews[i].presenseButton.interactable = false;
                lessonViews[i].lessonName.text = "";
                lessonViews[i].lessonPlace.text = "";
                lessonViews[i].lessonTeacher_Class.text = "";
                lessonViews[i].background.color = statusColor[(int)Enums.LessonStatus.Nan];
			}
        }
	}
}
