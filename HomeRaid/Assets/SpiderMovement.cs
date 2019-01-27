using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 20.0f;
    Vector3 direction = Vector3.zero;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            direction *= speed;

            direction.y = jumpSpeed;

        }
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }
}
