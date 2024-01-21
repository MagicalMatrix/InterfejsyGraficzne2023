using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonData : MonoBehaviour
{
    public string lessonName;
    public string lessonPlace;
    public int id; //id sets weekly date of lesson 1-8 per day, so 9 means first lesson on tuesday
    public Account lessonTeacher;
    public string lessonClass;
}
