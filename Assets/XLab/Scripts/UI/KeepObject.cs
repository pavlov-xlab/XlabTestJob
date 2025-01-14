using UnityEngine;

public class KeepObject : MonoBehaviour
{
    private static KeepObject instance;
    private void Start()
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
