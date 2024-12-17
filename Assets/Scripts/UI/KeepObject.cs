using UnityEngine;

public class KeepObject : MonoBehaviour
{
    private static KeepObject instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
