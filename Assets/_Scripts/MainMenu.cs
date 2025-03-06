using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject SettingUI;

    private void Start() {
        SettingUI.SetActive(false);
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

     public void ExitSetting()
    {
        SettingUI.SetActive(false);
    }
    public void SettingGame()
    {
        SettingUI.SetActive(true);
    }
}
