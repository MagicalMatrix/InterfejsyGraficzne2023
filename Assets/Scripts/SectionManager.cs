using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public List<GameObject> Sections;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSection(int id)
	{
        for (int i = 0; i < Sections.Count; ++i)
        {
            Sections[i].SetActive(false);
            if (i == id)
            {
                Sections[i].SetActive(true);
            }
        }
    }

    public void ChangeSection(string name)
	{
        for (int i = 0; i < Sections.Count; ++i)
		{
            Sections[i].SetActive(false);
            if (Sections[i].name == name)
			{
                Sections[i].SetActive(true);
            }
		}
	}
}
