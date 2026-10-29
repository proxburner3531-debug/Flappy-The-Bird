using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float pipeLeftVelocity = 6f;

    private void Update()
    {
        float leftBoundary = -10f;
        transform.position += Vector3.left * pipeLeftVelocity * Time.deltaTime;

        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddScore();
    }
}
