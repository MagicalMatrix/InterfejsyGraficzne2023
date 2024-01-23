using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//made per stack, not neccesarry per grade
public class GradesViewer : MonoBehaviour
{
    public int id;
    public TMP_Text lesson;
    public TMP_Text mean; //let's calculate this as last thing to do
    public GameObject gradesPlace;
}
