using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskSender : MonoBehaviour
{
    public TMP_InputField topic;
    public TMP_InputField target;
    public TMP_InputField lesson;
    public TMP_InputField deadline;
    public TMP_InputField description;
    // Start is called before the first frame update
    void OnEnable()
    {
        topic.text = "";
        target.text = "";
        lesson.text = "";
        deadline.text = "";
        description.text = "";
    }
}
