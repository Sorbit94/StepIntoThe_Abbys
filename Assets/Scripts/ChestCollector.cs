using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCollector : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private List<Chest> collectedChests = new List<Chest>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Chest chest = collision.gameObject.GetComponent<Chest>();
        if (chest != null && !collectedChests.Contains(chest))
        {
            collectedChests.Add(chest);
            score++;
            scoreText.text = "" + score;
        }
    }
}
