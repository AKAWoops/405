using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mark.Ballinger.GAM405
{
    
    /// Press the Spacebar to restart the scene.
    
    public class RestartSceneController : MonoBehaviour
    {
        protected void Update()
        {
            // Restart Scene		press space
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}