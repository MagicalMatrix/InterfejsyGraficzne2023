using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TaskViewer LinkedTask;

    [SerializeField] private TMP_Text dataField;
    private string oldData;

    public TMP_InputField name;
    public TMP_InputField deadline;
    public TMP_InputField subject;
    public TMP_Dropdown status;
    // Start is called before the first frame update
    void Start()
    {
        RememberData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RememberData()
	{
        oldData = dataField.text;
    }

    public void RevertData()
	{
        dataField.text = oldData;
    }

    //sets status to done, only temporarly made for the sake of prototype
    public void MadeTask()
	{
        status.value = 1;
        LinkedTask.status.value = 1;
	}

	private void SynchTask()
	{
        LinkedTask.name = name;
        LinkedTask.deadline = deadline;
        LinkedTask.subject = subject;
        LinkedTask.status.value = status.value;
    }
}
