using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public event Action onCollisionStone;
        public bool isDirty = false;

        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.GetComponent<Stone>())
            {
                onCollisionStone?.Invoke();
            }
        }
    }
}
