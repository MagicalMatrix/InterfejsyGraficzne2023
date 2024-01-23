using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonsInstances : MonoBehaviour
{
    //contains statuses for individual lessons
    //by the week date and id
    //id goes 1-8 each day, whenever actual lesson was
    //there or not
    public List<int> lessonId;
    public List<string> accountName;
    public List<int> status;
}
