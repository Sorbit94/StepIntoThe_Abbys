using UnityEngine;
using UnityEngine.UI;

public class DaggerManager : MonoBehaviour
{
    public int maxDaggers = 5;
    public int currentDaggers;

    [SerializeField] private Text daggerCountText;

    private void Start()
    {
        currentDaggers = maxDaggers;
        UpdateDaggerCountText();
    }

    public void DecreaseDaggerCount()
    {
        if (currentDaggers <= 0)
        {
            return;
        }

        currentDaggers--;
        UpdateDaggerCountText();
    }

    public void IncreaseDaggerCount(int additionalDaggers)
    {
        currentDaggers += additionalDaggers;
        UpdateDaggerCountText();
    }

    private void UpdateDaggerCountText()
    {
        daggerCountText.text = currentDaggers + "/" + maxDaggers;
    }
}
