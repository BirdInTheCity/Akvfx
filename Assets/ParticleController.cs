using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleController : MonoBehaviour
{
    public GameObject m_Point;
    public GameObject m_Particle;
    public GameObject m_Lines;
    public GameObject m_Web;
    public GameObject m_Leaves;
    public GameObject m_Cords;

    private int currentScene = 0;
    private GameObject[] list;

    // Start is called before the first frame update
    void Start()
    {
        list = new GameObject[] { m_Point, m_Particle, m_Lines, m_Web, m_Leaves, m_Cords };
    }

    void LoadNext()
    {
        currentScene = currentScene > 4 ? 1 : currentScene + 1;

        switch (currentScene)
        {
            case 1:
                ActivateList(new GameObject[] { m_Cords, m_Point });
                break;
            case 2:
                ActivateList(new GameObject[] { m_Particle });
                break;
            case 3:
                ActivateList(new GameObject[] { m_Cords, m_Point });
                break;
            case 4:
                ActivateList(new GameObject[] { m_Leaves });
                break;
            case 5:
                ActivateList(new GameObject[] { m_Particle, m_Cords });

                break;
        }
    }

    void ActivateList(GameObject[] activeList)
    {
        foreach (GameObject obj in list)
        {
            int index = Array.IndexOf(activeList, obj);
            bool isActive = index != -1;
            Debug.Log(obj.name + " : " + isActive);
            obj.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            LoadNext();
        }

        if (Input.GetKeyUp("escape"))
        {
            Application.Quit();
        }
    }
}
