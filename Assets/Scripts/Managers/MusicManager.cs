using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource audioSource;
    private float volume = .3f;
    private const string PPLAYERPREFS_MUSIC_VOLUME_KEY = "MusicVolume";

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    
        volume = PlayerPrefs.GetFloat(PPLAYERPREFS_MUSIC_VOLUME_KEY, .3f);
        audioSource.volume = volume;
    }

    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        audioSource.volume = volume;    
        PlayerPrefs.SetFloat(PPLAYERPREFS_MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
