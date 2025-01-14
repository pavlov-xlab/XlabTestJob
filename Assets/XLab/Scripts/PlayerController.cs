using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    private InputAction m_aimAction;
    public Player target;

    public event Action testSA;

    public CamerasManager camerasManager;

    public void SetTarget(Player target)
    {
        this.target = target;
        camerasManager.SetTarget(target.transform);

        UnityEngine.Events.UnityEvent unityEvent = new UnityEngine.Events.UnityEvent();
        unityEvent.AddListener(Start);
        unityEvent.AddListener(Update);

        testSA += Start;
        testSA += Update;

        testSA.Invoke();

        unityEvent.Invoke();
    }
    
    void Start()
    {
        var map = inputActions.FindActionMap("Player");
        map.Enable();

        m_moveAction = map.FindAction("Move");
        m_aimAction = map.FindAction("Aim");

        m_aimAction.performed += OnAimPerformed;
        m_aimAction.canceled += OnAimCanceled;
    }

    private void OnAimCanceled(InputAction.CallbackContext context)
    {
        camerasManager.ChangeCamera(CameraType.TPC);
    }

    private void OnAimPerformed(InputAction.CallbackContext context)
    {
        camerasManager.ChangeCamera(CameraType.Aim);
    }

    private void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        target.Move(move);
    }
}
