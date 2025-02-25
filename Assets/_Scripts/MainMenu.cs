using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
