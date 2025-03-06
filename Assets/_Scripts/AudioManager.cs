using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("--------------------AudioSources--------------------------------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;
    [Header("--------------------AudioClips--------------------------------")]
    public AudioClip musicBGM;
    public AudioClip RunSFX;
    public AudioClip JumpSFX;
    public static AudioManager instance;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake() {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.clip = musicBGM;
        music.Play();

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Gán âm lượng ban đầu
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);

        // Lắng nghe sự kiện thay đổi giá trị slider
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void StopBMGMusic()
    {
        music.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        music.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFX.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
