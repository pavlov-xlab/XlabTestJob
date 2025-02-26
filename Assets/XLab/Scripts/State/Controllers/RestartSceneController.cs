using UnityEngine;
using UnityEngine.SceneManagement;

namespace Xlab
{
    public class RestartSceneController : MonoBehaviour
    {
        public void RestartScene()
        {
            if (!enabled)
            {
                return;
            }

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Empty");
            SceneManager.LoadScene(scene.name);
        }
    }
}