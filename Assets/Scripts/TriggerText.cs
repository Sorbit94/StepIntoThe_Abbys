using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    [SerializeField] private Text triggerText;
    private bool textShown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !textShown)
        {
            triggerText.gameObject.SetActive(true);
            textShown = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerText.gameObject.SetActive(false);
        }
    }
}
