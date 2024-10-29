using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{
    private void Awake()
    {
        Log("Awake");
    }

    private void OnEnable()
    {
        Log($"OnEnable");
    }

    private void Start()
    {
        Log("Start");
    }

    public void FixedUpdate(){}

    public void Update(){}

    public void LateUpdate(){}

    private void OnDisable()
    {
        Log($"OnDisable");
    }

    public void OnDestroy()
    {
        Log("OnDestroy");
    }



    private void Log(string msg)
    {
        Debug.Log($"{name}.{msg} - f: {Time.frameCount}");
    }
}
