using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public Button play;
    public Button setting;
    public Button credit;
    public Button exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        play = root.Q<Button>("Odyssey");
        setting = root.Q<Button>("Setting");
        credit = root.Q<Button>("Credit");
        exit = root.Q<Button>("Exit");

        play.clicked += PlayPress;
    }

    void PlayPress(){
        SceneManager.LoadScene("Level1");
    }
}
