using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    [SerializeField] GameObject SettingUI;
    [SerializeField] GameObject PauseUI;

    private void Start() {
        SettingUI.SetActive(false);
        PauseUI.SetActive(false);
    }

    public void ExitSetting()
    {
        SettingUI.SetActive(false);
        PauseUI.SetActive(false);
         Time.timeScale = 1;
    }

    public void SettingGame()
    {
        SettingUI.SetActive(true);
    }

    public void PauseGame()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
