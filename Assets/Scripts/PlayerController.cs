using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Stick stick;

        private void FixedUpdate()
        {
            // if (Input.GetMouseButton(0))
            // {   
            //     PointerDown();
            // }
            // else
            // {
            //     PointerUp();
            // }
        }

        private void OnEnable()
        {
            if (stick != null)
            {
                stick.Reset();
            }
        }

        public void PointerDown()
        {
            stick.Down();
        }

        public void PointerUp()
        {
            stick.Up();
        }
    }
}