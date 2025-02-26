using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speedMove = 5;
    public float speedRotation = 30;    

    private CharacterController m_characterController;
    private Transform m_cameraTransform;
    
    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_cameraTransform = Camera.main.transform;
    }

    public void Move(Vector2 moveInput)
    {
        if (m_characterController)
        {
            var cameraY = m_cameraTransform.eulerAngles.y;

            Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
            dir = Quaternion.Euler(0, cameraY, 0) * dir;
            m_characterController.SimpleMove(dir * speedMove);
            
            if (moveInput.sqrMagnitude > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), speedRotation * Time.deltaTime);
                // transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
}
