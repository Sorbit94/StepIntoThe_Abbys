using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private GameObject pauseMenuUI;
    public bool isTimelinePlaying = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        attackCollider.SetActive(false);
    }

    private void Update()
    {
        if (isTimelinePlaying || pauseMenuUI.activeSelf) return;
        {
            float horizontalDirection = Input.GetAxis(GlobalStringVars.Horizontal_Axis);
            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

            if (Input.GetButtonDown(GlobalStringVars.Fire_1))
            {
                animator.SetTrigger("Attack");
                attackCollider.SetActive(true);
            }

            bool isRunning = Mathf.Abs(horizontalDirection) > 0;
            animator.SetBool("IsRunning", isRunning);

            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }
    }

    public void OnAttackAnimationEnd()
    {
        attackCollider.SetActive(false);
    }

    public void OnTimelineEnd()
    {
        isTimelinePlaying = false;
    }
}
