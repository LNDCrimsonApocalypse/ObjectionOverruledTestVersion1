using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] public Slider MusicSlider;
    [SerializeField] public Slider SFXSlider;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";
    const string MUSIC_PREF = "MusicVolumePref";
    const string SFX_PREF = "SFXVolumePref";

    private void Awake()
    {
        // Add listeners for slider changes with saving logic
        MusicSlider.onValueChanged.AddListener((value) =>
        {
            SetMusicVolume(value);
            SaveVolumeSettings(MUSIC_PREF, value);
        });

        SFXSlider.onValueChanged.AddListener((value) =>
        {
            SetSFXVolume(value);
            SaveVolumeSettings(SFX_PREF, value);
        });
    }

    private void OnEnable()
    {
        // Load saved volume values from PlayerPrefs when the settings menu is opened
        float savedMusicVolume = PlayerPrefs.GetFloat(MUSIC_PREF, 0.75f); // Default to 0.75 if no saved value
        float savedSFXVolume = PlayerPrefs.GetFloat(SFX_PREF, 0.75f); // Default to 0.75 if no saved value

        MusicSlider.value = savedMusicVolume;
        SFXSlider.value = savedSFXVolume;

        Debug.Log($"Loaded Music Volume: {savedMusicVolume}");
        Debug.Log($"Loaded SFX Volume: {savedSFXVolume}");

        // Apply the saved values to the mixer
        SetMusicVolume(MusicSlider.value);
        SetSFXVolume(SFXSlider.value);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        Debug.Log($"Music volume set to {value}");
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        Debug.Log($"SFX volume set to {value}");
    }

    private void SaveVolumeSettings(string key, float value)
    {
        // Save the provided value to PlayerPrefs
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save(); // Force save to disk
        Debug.Log($"Saved {key}: {value}");
    }
}
