using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    private AccountManager accountManager;

    [SerializeField]
    private GameObject TaskViewPlace;
    public GameObject TaskView; //prefab
    public GameObject TaskEditPlace;
    public TaskReviewer StudentReview;
    public TaskReviewer TeacherReview;

    public GameObject NewTaskButton;

    public TaskInstances taskInstances;
    public List<TaskViewer> taskViewers;

    // Start is called before the first frame update
    void Awake()
    {
        accountManager = GameObject.FindAnyObjectByType<AccountManager>();
    }

    void OnEnable()
	{
        UpdateViews();

        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
        {
            NewTaskButton.SetActive(false);
        }
        else if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
		{
            NewTaskButton.SetActive(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateReview(TaskViewer view)
	{
        int id = view.id;
        //uses selective update as well
        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
		{
            TaskEditPlace.GetComponent<SelectiveActivation>().SelectActive(StudentReview.gameObject);
            Debug.Log(id);
            StudentReview.topic.text = taskInstances.topic[id];
            StudentReview.creator.text = taskInstances.creator[id];
            StudentReview.lesson.text = taskInstances.lesson[id];
            StudentReview.deadline.text = taskInstances.deadline[id];
            StudentReview.status.value = taskInstances.status[id];
            StudentReview.description.text = taskInstances.description[id];
            StudentReview.answer.text = taskInstances.answer[id];
            StudentReview.comment.text = taskInstances.comment[id];
            StudentReview.id = id;
        }
        else if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
		{
            TaskEditPlace.GetComponent<SelectiveActivation>().SelectActive(TeacherReview.gameObject);
            TeacherReview.topic.text = taskInstances.topic[id];
            TeacherReview.creator.text = taskInstances.target[id];
            TeacherReview.lesson.text = taskInstances.lesson[id];
            TeacherReview.deadline.text = taskInstances.deadline[id];
            TeacherReview.status.value = taskInstances.status[id];
            TeacherReview.description.text = taskInstances.description[id];
            TeacherReview.answer.text = taskInstances.answer[id];
            TeacherReview.comment.text = taskInstances.comment[id];
            TeacherReview.id = id;
        }
	}

    public void SendAnswerStudent(TaskReviewer review)
	{
       taskInstances.answer[review.id] = review.answer.text;
       taskInstances.status[review.id] = 1;
	}

    public void SendAnswerTeacher(TaskReviewer review)
	{
        taskInstances.comment[review.id] = review.comment.text;
        taskInstances.status[review.id] = 2;
    }

    public void UpdateViews()
	{
        //delete old views
        for (int i = 0; i < taskViewers.Count; i++)
		{
            Destroy(taskViewers[i].gameObject);
		}
        taskViewers.Clear();

        //if student
        //search for tasks made for you
        if (accountManager.currentAccount.type == Enums.AccountType.Uczen)
		{
            for (int i = 0; i < taskInstances.topic.Count; i++)
			{
                if (taskInstances.target[i] == accountManager.currentAccount.name)
				{
                    //show task view
                    TaskViewer newTask = Instantiate(TaskView, TaskViewPlace.transform).GetComponent<TaskViewer>();
                    //here input data
                    newTask.topic.text = taskInstances.topic[i];
                    newTask.deadline.text = taskInstances.deadline[i];
                    newTask.lesson.text = taskInstances.lesson[i];
                    newTask.status.value = taskInstances.status[i];
                    newTask.id = i;
                    newTask.gameObject.SetActive(true);
                    taskViewers.Add(newTask);
                }
			}
		}
        else if (accountManager.currentAccount.type == Enums.AccountType.Nauczyciel)
		{
            for (int i = 0; i < taskInstances.topic.Count; i++)
            {
                Debug.Log(taskInstances.creator[i]);
                if (taskInstances.creator[i] == accountManager.currentAccount.name)
                {
                    //show task view
                    TaskViewer newTask = Instantiate(TaskView, TaskViewPlace.transform).GetComponent<TaskViewer>();
                    //here input data
                    newTask.topic.text = taskInstances.topic[i];
                    newTask.deadline.text = taskInstances.deadline[i];
                    newTask.lesson.text = taskInstances.lesson[i];
                    newTask.status.value = taskInstances.status[i];
                    newTask.id = i;
                    newTask.gameObject.SetActive(true);
                    taskViewers.Add(newTask);
                }
            }
        }

	}

    public void SendTask(TaskSender task)
	{
        //send to class if class is used
        Account[] classSend = accountManager.GetAccountsOfSubtype(task.target.text);
        for (int i = 0; i < classSend.Length; i++)
		{
            taskInstances.topic.Add(task.topic.text);
            taskInstances.creator.Add(accountManager.currentAccount.name);
            taskInstances.target.Add(classSend[i].name);
            taskInstances.lesson.Add(task.lesson.text);
            taskInstances.deadline.Add(task.deadline.text);
            taskInstances.status.Add(0);
            taskInstances.description.Add(task.description.text);
            taskInstances.answer.Add("");
            taskInstances.comment.Add("");
        }

        //send to individual student
        Account individualAccount = accountManager.GetAccountOfName(task.target.text);
        if (individualAccount)
		{
            taskInstances.topic.Add(task.topic.text);
            taskInstances.creator.Add(accountManager.currentAccount.name);
            taskInstances.target.Add(individualAccount.name);
            taskInstances.lesson.Add(task.lesson.text);
            taskInstances.deadline.Add(task.deadline.text);
            taskInstances.status.Add(0);
            taskInstances.description.Add(task.description.text);
            taskInstances.answer.Add("");
            taskInstances.comment.Add("");
        }
    }
}
