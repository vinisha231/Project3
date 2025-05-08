using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {   if (Time.timeScale == 0f) return;
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Reset car when off-screen
        if (transform.position.x > 10)
            transform.position = new Vector3(-10, transform.position.y, 0);
    }
}