using UnityEngine;

public class DeosgraciasActivator : MonoBehaviour
{
    [SerializeField] private GameObject npcObject;

    void OnDestroy()
    {
        if (npcObject != null && !npcObject.activeSelf && GameObject.FindGameObjectWithTag("Boss") == null)
        {
            npcObject.SetActive(true);
        }
    }
}

