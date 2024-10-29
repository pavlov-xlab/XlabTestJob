using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilagerToolChange : MonoBehaviour
{
    public GameObject[] tools;

    private void Start()
    {
        Change();
    }

    public void Change()
    {
        var index = Random.Range(0, tools.Length);
        for (int i = 0; i < tools.Length; ++i)
        {
            tools[i].SetActive(i == index);
        }
    }
}
