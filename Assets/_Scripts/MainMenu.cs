using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class MainMenu : MonoBehaviour
    {
        void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
