using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

