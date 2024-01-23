using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GradesManager : MonoBehaviour
{
    private AccountManager accountManager;

    public GameObject SearchStudent;
    public GameObject NewGradeButton;
    [SerializeField]
    private GameObject GradeViewPlace;
    public GameObject GradeView;
    public GameObject GradeObject;

    public GameObject ReviewPlace;
    public GradeReviewer StudentReview;
    public GradeReviewer TeacherReview;

    public GradeInstances gradeInstances;
    public List<GradesViewer> gradeViewers;
    // Start is called before the first frame update
    void Awake()
    {
        accountManager = GameObject.FindAnyObjectByType<AccountManager>();
    }

    void OnEnable()
    {
        UpdateViews();

    }

    public void UpdateReview(Grade grade)
	{
        GradeViewPlace.SetActive(false);

        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
		{
            ReviewPlace.GetComponent<SelectiveActivation>().SelectActive(StudentReview.gameObject);
            int id = grade.id;
            StudentReview.topic.text = gradeInstances.topic[id];
            StudentReview.value.text = gradeInstances.value[id];
            StudentReview.weight.text = gradeInstances.weight[id];
            StudentReview.lesson.text = gradeInstances.lesson[id];
            StudentReview.creator.text = gradeInstances.creator[id];
            StudentReview.date.text = gradeInstances.date[id];
            StudentReview.description.text = gradeInstances.description[id];
        }
        else if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
		{
            ReviewPlace.GetComponent<SelectiveActivation>().SelectActive(TeacherReview.gameObject);
            int id = grade.id;
            TeacherReview.topic.text = gradeInstances.topic[id];
            TeacherReview.value.text = gradeInstances.value[id];
            TeacherReview.weight.text = gradeInstances.weight[id];
            TeacherReview.lesson.text = gradeInstances.lesson[id];
            TeacherReview.creator.text = gradeInstances.target[id];
            TeacherReview.date.text = gradeInstances.date[id];
            TeacherReview.description.text = gradeInstances.description[id];
        }
    }

    public void SendGrade(GradeSender grade)
	{
        gradeInstances.topic.Add(grade.topic.text);
        gradeInstances.value.Add(grade.value.text);
        gradeInstances.weight.Add(grade.weight.text);
        gradeInstances.lesson.Add(grade.lesson.text);
        gradeInstances.target.Add(grade.target.text);
        gradeInstances.date.Add(DateTime.Now.ToString("dd-MM-yyyy")); //schould get current date
        gradeInstances.creator.Add(accountManager.currentAccount.name);
        gradeInstances.description.Add(grade.description.text);
    }

    
    public void SaveGrade(int id, GradeSender grade)
    {
        gradeInstances.topic[id] = grade.topic.text;
        gradeInstances.value[id] = grade.value.text;
        gradeInstances.description[id] = grade.description.text;
    }

    public void UpdateViews()
	{
        //delete old views
        for (int i = 0; i < gradeViewers.Count; i++)
        {
            Destroy(gradeViewers[i].gameObject);
        }
        gradeViewers.Clear();

        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
		{
            //SearchStudent.SetActive(false);
            NewGradeButton.SetActive(false);
            for (int i = 0; i < gradeInstances.topic.Count; i++)
			{
                bool existingLesson = false;
                for (int j = 0; j < gradeViewers.Count; j++)
				{
                    if (gradeViewers[j].lesson.text == gradeInstances.lesson[i] && gradeInstances.target[i] == accountManager.currentAccount.name)
					{
                        existingLesson = true;
                        //add grade to lesson
                        Grade newGrade = Instantiate(GradeObject, gradeViewers[j].gradesPlace.transform).GetComponent<Grade>();
                        newGrade.id = i;
                        newGrade.value.text = gradeInstances.value[i];
                        newGrade.gameObject.SetActive(true);
					}
				}
                if (!existingLesson && gradeInstances.target[i] == accountManager.currentAccount.name)
				{
                    Debug.Log("added lesson type");
                    //form new lesson
                    GradesViewer newViewer = Instantiate(GradeView, GradeViewPlace.transform).GetComponent<GradesViewer>();

                    newViewer.lesson.text = gradeInstances.lesson[i];

                    newViewer.gameObject.SetActive(true);
                    gradeViewers.Add(newViewer);

                    i--; //we have to check value again if it is new
				}
			}
		}
        else if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
		{
            //SearchStudent.SetActive(true);
            NewGradeButton.SetActive(true);

            //string searchStudent = SearchStudent.GetComponentInChildren<TMP_InputField>().text;
            //same as student, but takes him from search bar
            for (int i = 0; i < gradeInstances.topic.Count; i++)
            {
                bool existingLesson = false;
                for (int j = 0; j < gradeViewers.Count; j++)
                {
                    if (gradeViewers[j].lesson.text == gradeInstances.lesson[i] && gradeInstances.target[i] == accountManager.currentAccount.name)
                    {
                        existingLesson = true;
                        //add grade to lesson
                        Grade newGrade = Instantiate(GradeObject, gradeViewers[j].gradesPlace.transform).GetComponent<Grade>();
                        newGrade.id = i;
                        newGrade.value.text = gradeInstances.value[i];
                        newGrade.gameObject.SetActive(true);
                    }
                }
                if (!existingLesson && gradeInstances.target[i] == accountManager.currentAccount.name)
                {
                    Debug.Log("added lesson type");
                    //form new lesson
                    GradesViewer newViewer = Instantiate(GradeView, GradeViewPlace.transform).GetComponent<GradesViewer>();

                    newViewer.lesson.text = gradeInstances.lesson[i];

                    newViewer.gameObject.SetActive(true);
                    gradeViewers.Add(newViewer);

                    i--; //we have to check value again if it is new
                }
            }
        }

        GradeViewPlace.SetActive(true);
        foreach (var layoutGroup in GradeViewPlace.GetComponentsInChildren<LayoutGroup>())
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }
    }
}
