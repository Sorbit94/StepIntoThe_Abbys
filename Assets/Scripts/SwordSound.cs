using UnityEngine;

public class EffectSound : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;

    public void PlayEffectSound()
    {
        effectAudioSource.Play();
    }
}
