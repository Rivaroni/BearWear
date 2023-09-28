using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    [SerializeField]
    private AudioSource soundEffectSource;
    [SerializeField]
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(AudioClip clip, float volume = 1.0f)
    {
        // Generate a random pitch between 0.8 and 2.0 (adjust these values as needed)
        float randomPitch = Random.Range(0.8f, 2.0f);

        // Set the pitch for this sound effect
        soundEffectSource.pitch = randomPitch;

        // Set the volume for this sound effect
        soundEffectSource.volume = volume;

        // Play the sound effect
        soundEffectSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
