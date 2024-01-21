using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskViewer : MonoBehaviour
{
    public TaskManager linkedTask;

    public TMP_InputField name;
    public TMP_InputField deadline;
    public TMP_InputField subject;
    public TMP_Dropdown status;
    // Start is called before the first frame update
    void Start()
    {
        name.text = linkedTask.name.text;
        deadline.text = linkedTask.deadline.text;
        subject.text = linkedTask.subject.text;
        status.value = linkedTask.status.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
