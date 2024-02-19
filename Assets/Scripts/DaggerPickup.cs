using UnityEngine;

public class DaggerPickup : MonoBehaviour
{
    [SerializeField] private GameObject audioObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DaggerManager daggerManager = collision.GetComponent<DaggerManager>();
            if (daggerManager != null)
            {
                int additionalDaggers = 5 - daggerManager.currentDaggers;
                if (additionalDaggers > 0)
                {
                    daggerManager.IncreaseDaggerCount(additionalDaggers);
                    AudioSource audioSource = audioObject.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
