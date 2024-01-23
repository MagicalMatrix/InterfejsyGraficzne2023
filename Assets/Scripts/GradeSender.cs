using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GradeSender : MonoBehaviour
{
    public TMP_InputField topic;
    public TMP_InputField value;
    public TMP_InputField weight;
    public TMP_InputField lesson;
    public TMP_InputField target; //also target
    public TMP_InputField description;

	private void OnEnable()
	{
        topic.text = "";
        value.text = "";
        weight.text = "";
        lesson.text = "";
        target.text = "";
        description.text = "";
    }
}
