using UnityEngine;
using UnityEngine.InputSystem;

public class Script : MonoBehaviour
{
    public float speed_multiplayer, max_speed, jump_force;
    public bool is_grounded;
    InputAction move, jump;
    Vector3 camera_size;
    float current_object_size_x, current_object_size_y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed_multiplayer = 125f;
        max_speed = 10f;
        jump_force = 625f;
        is_grounded = false;
        camera_size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log("Danil_Kolbasenko");
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        if (move != null) Debug.Log("Move is set");
        else Debug.Log("Move is not set");
        current_object_size_x = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        current_object_size_y = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move_direction = move.ReadValue<Vector2>();
        if (jump.IsPressed()&& is_grounded) GetComponent<Rigidbody2D>().AddForceY(jump_force);
        if(GetComponent<Rigidbody2D>().linearVelocity.magnitude < max_speed)
        GetComponent<Rigidbody2D>().AddForceX(move_direction.x*speed_multiplayer);
        GetComponent<Rigidbody2D>().gravityScale = 5;
    }

    void LateUpdate()
    {
        Vector3 current_position = transform.position;
        current_position.x = Mathf.Clamp(transform.position.x, -camera_size.x + current_object_size_x, camera_size.x - current_object_size_x);
        current_position.y = Mathf.Clamp(transform.position.y, -camera_size.y + current_object_size_y, camera_size.y - current_object_size_y);
        transform.position = current_position;
    }
}
