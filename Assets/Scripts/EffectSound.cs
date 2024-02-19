using UnityEngine;

public class SwordSound : MonoBehaviour
{
    [SerializeField] private AudioSource swordAudioSource;

    public void PlaySwordSound()
    {
        swordAudioSource.Play();
    }
}
