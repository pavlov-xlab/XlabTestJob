using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameInstance : MonoBehaviour
    {
        public static int score = 0;

        public Transform states;

        private void Start()
        {
            foreach (Transform child in states)
            {
                child.gameObject.SetActive(false);
            }

            states.GetChild(0).gameObject.SetActive(true);
        }
    }
}
