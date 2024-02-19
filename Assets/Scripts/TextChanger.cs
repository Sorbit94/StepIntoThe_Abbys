using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private Text[] textElements;
    private int currentTextIndex = 0;
    private bool isLastText = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SkipText();
        }
    }

    public void SkipText()
    {
        if (!isLastText)
        {
            timeline.Stop();

            textElements[currentTextIndex].gameObject.SetActive(false);
            currentTextIndex++;

            if (currentTextIndex >= textElements.Length)
            {
                isLastText = true;
            }

            double nextTextStartTime = GetTextTime(currentTextIndex);
            timeline.time = nextTextStartTime;
            timeline.Play();
        }
    }

    private double GetTextTime(int index)
    {
        double time = 0;

        for (int i = 0; i < index; i++)
        {
            time += textElements[i].text.Length * 0.1f;
        }

        return time;
    }
}
