using UnityEngine;

public class PrallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int LayersCount;

    void Start()
    {
        LayersCount = layers.Length;
    }

    void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;

        for (int i = 0; i < LayersCount; i++)
        {
            float parallaxX = currentPosition.x * coeff[i];
            float parallaxY = currentPosition.y * coeff[i];

            Vector2 newPosition = new Vector2(parallaxX, parallaxY);

            layers[i].position = newPosition;
        }
    }
}
