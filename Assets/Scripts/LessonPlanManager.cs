using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPlanManager : MonoBehaviour
{
    private AccountManager accountManager;
    public string[] lessonTimes;

    public LessonView[] lessonViews;
    public LessonData[] lessons;
    public LessonsInstances lessonsDatabase;

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

	void SetTimes()
	{
        for (int i = 0; i < lessonViews.Length; i++)
		{
            lessonViews[i].timeStart.text = lessonTimes[i % 8 * 2];
            lessonViews[i].timeEnd.text = lessonTimes[i % 8 * 2 + 1];
        }
	}

    //unused
    void UpdateStatus()
	{
        for (int i = 0; i < lessonViews.Length; i++)
        {

        }
    }

    void UpdateViews()
	{
        bool[] updated = new bool[40];
        for (int i = 0; i < lessons.Length; i++)
		{
            int id = lessons[i].id;
            //is lesson by the logged teacher 
            if (lessons[i].lessonTeacher == accountManager.currentAccount) 
			{
                lessonViews[id].lessonName.text = lessons[i].name;
                lessonViews[id].lessonPlace.text = lessons[i].lessonPlace;
                lessonViews[id].lessonTeacher_Class.text = lessons[i].lessonClass;
                updated[lessons[i].id] = true;
			}
            //is lesson meant for student class
            else if (lessons[i].lessonClass == accountManager.currentAccount.subtype)
			{
                lessonViews[id].lessonName.text = lessons[i].lessonName;
                lessonViews[id].lessonPlace.text = lessons[i].lessonPlace;
                if (!lessons[i].lessonTeacher)
                {
                    lessonViews[id].lessonTeacher_Class.text = "";
                }
				else
				{
                    lessonViews[id].lessonTeacher_Class.text = lessons[i].lessonTeacher.name;
                }
                updated[lessons[i].id] = true;
            }
		}
        for (int i = 0; i < lessonViews.Length; i++)
		{
            //all discarded views schould be empty
            if (!updated[i])
			{
                Debug.Log(lessonViews[i].name);
                lessonViews[i].lessonName.text = "";
                lessonViews[i].lessonPlace.text = "";
                lessonViews[i].lessonTeacher_Class.text = "";
                lessonViews[i].background.color = statusColor[(int)Enums.LessonStatus.Nan];
			}
        }
	}
}
