using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    private static float soundVolume = 1f;
    private static float musicVolume = 1f;

    private const string SOUNDVOLUMEKEY = "SoundVolume";
    private const string MUSICVOLUMEKEY = "MusicVolume";

    private void OnDisable()
    {
        SaveVolume();
    }

    private void OnEnable()
    {
        LoadVolume();
        ApplyVolume();
    }

    private void Start()
    {
        if (soundSlider != null && musicSlider != null)
        {
            soundSlider.value = soundVolume;
            musicSlider.value = musicVolume;
        }

        ApplyVolume();
    }

    public void OnSoundVolumeChange(float value)
    {
        soundVolume = value;
        ApplyVolume();
    }

    public void OnMusicVolumeChange(float value)
    {
        musicVolume = value;
        ApplyVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(SOUNDVOLUMEKEY, soundVolume);
        PlayerPrefs.SetFloat(MUSICVOLUMEKEY, musicVolume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        soundVolume = PlayerPrefs.GetFloat(SOUNDVOLUMEKEY, 1f);
        musicVolume = PlayerPrefs.GetFloat(MUSICVOLUMEKEY, 1f);
    }

    private void ApplyVolume()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.CompareTag("SoundEffect"))
            {
                audioSource.volume = soundVolume;
            }
            else if (audioSource.CompareTag("Music"))
            {
                audioSource.volume = musicVolume;
            }
        }

        PlayerPrefs.SetFloat(SOUNDVOLUMEKEY, soundVolume);
        PlayerPrefs.SetFloat(MUSICVOLUMEKEY, musicVolume);
    }
}
