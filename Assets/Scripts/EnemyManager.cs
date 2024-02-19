using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static int countDeadEnemies = 0;
    [SerializeField] private Text killsText;

    private void Start()
    {
        if (killsText != null)
        {
            killsText.text = "Enemies killed: " + countDeadEnemies;
        }
    }

    public static void AddDeadEnemies()
    {
        countDeadEnemies++;
    }

    public static void ResetCountDeadEnemies()
    {
        countDeadEnemies = 0;
    }
}
