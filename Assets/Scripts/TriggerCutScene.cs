using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    private PlayerInput playerInput;
    private Shooting shooting;
    private bool isInTrigger = false;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        shooting = FindObjectOfType<Shooting>();
    }

    private void Start()
    {
        timeline.stopped += OnCutSceneStopped;
    }

    private void OnCutSceneStopped(PlayableDirector aDirector)
    {
        playerInput.OnTimelineEnd();
        shooting.OnTimelineEnd();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            timeline.Play();
            playerInput.isTimelinePlaying = true;
            shooting.isTimelinePlaying = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
