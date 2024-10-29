using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChangerController : MonoBehaviour
{
    public VilagerToolChange[] vllagers;

    public void Change()
    {
        foreach (var vllager in vllagers)
        {
            vllager.Change();
        }
    }
}
