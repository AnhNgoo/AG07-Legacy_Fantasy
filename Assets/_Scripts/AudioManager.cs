using UnityEngine;

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

    private void Awake() {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.clip = musicBGM;
        music.Play();
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
}
