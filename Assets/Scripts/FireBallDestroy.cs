using UnityEngine;

public class FireBallDestroy : MonoBehaviour
{
    private PlayerInput playerInput;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            playerInput = other.GetComponent<PlayerInput>();

            if (playerInput != null)
            {
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, 10f);
    }
}
