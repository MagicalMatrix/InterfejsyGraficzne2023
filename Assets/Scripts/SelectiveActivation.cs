using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveActivation : MonoBehaviour
{
    public List<GameObject> Content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectActive(int index)
	{
        for (int i = 0; i < Content.Count; i++)
        {
            if (i == index)
			{
                Content[i].SetActive(true);
            }
            else
			{
                Content[i].SetActive(false);
            }
        }
    }

    public void SelectActive(GameObject toActive)
	{
        for (int i = 0; i < Content.Count; i++)
		{
            if (Content[i] == toActive)
			{
                Content[i].SetActive(true);
			}
			else
			{
                Content[i].SetActive(false);
            }
		}
	}
}
