using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip splashSFX;
    [SerializeField] private AudioClip yellowCollectSFX;
    [SerializeField] private AudioClip blackCollectSFX;
    [SerializeField] private AudioClip gameOverSFX;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        musicSource = sources[0];
        sfxSource = sources[1];
    }

    public void PlayMenuMusic()
    {
        if (musicSource.clip == menuMusic) return;

        musicSource.clip = menuMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGameplayMusic()
    {
        if (musicSource.clip == gameplayMusic) return;

        musicSource.clip = gameplayMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayJumpSFX()
    {
        sfxSource.PlayOneShot(jumpSFX);
    }

    public void PlaySplashSFX()
    {
        sfxSource.PlayOneShot(splashSFX);
    }

    public void PlayYellowCollectSFX()
    {
        sfxSource.PlayOneShot(yellowCollectSFX);
    }

    public void PlayBlackCollectSFX()
    {
        sfxSource.PlayOneShot(blackCollectSFX);
    }

    public void PlayGameOverSFX()
    {
        sfxSource.PlayOneShot(gameOverSFX);
    }
}
