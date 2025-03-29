using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource audioSource; 

    [Header("Sound Effects")]
    public AudioClip mashSound;
    public AudioClip pickupSeedSound;
    public AudioClip puddleSound;
    public AudioClip deliverySound;
    public AudioClip taskCompleteSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
