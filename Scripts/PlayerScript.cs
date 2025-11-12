using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }

    public void ApplyMovement(float moveAmount, float deltaTime)
    {
        // deterministic movement used by tests (use rb if using Rigidbody2D in production)
        transform.Translate(Vector2.right * moveAmount * speed * deltaTime);
    }
}
