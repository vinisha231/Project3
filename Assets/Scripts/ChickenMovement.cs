using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public GameManager gm;

    void Start()
{
    gm = FindAnyObjectByType<GameManager>(); // or FindFirstObjectByType
}

    void Update()
{
    if (Time.timeScale == 0f) return;

    Vector3 move = Vector3.zero;

    if (Input.GetKeyDown(KeyCode.UpArrow))
        move = Vector3.up * moveDistance;
    else if (Input.GetKeyDown(KeyCode.DownArrow))
        move = Vector3.down * moveDistance;
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        move = Vector3.left * moveDistance;
    else if (Input.GetKeyDown(KeyCode.RightArrow))
        move = Vector3.right * moveDistance;

    // Move chicken
    transform.position += move;

    // Clamp position to screen using Viewport coordinates
    Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
    viewPos.x = Mathf.Clamp01(viewPos.x);
    viewPos.y = Mathf.Clamp01(viewPos.y);
    transform.position = Camera.main.ViewportToWorldPoint(viewPos);

    // Win condition (optional — you can use world or viewport for this)
    if (viewPos.y >= 0.95f)  // close to top edge
    {
        gm.Win();
    }
}

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Car"))
    {
        Debug.Log("Chicken got hit!");
        gm.GameOver();
    }
}

}