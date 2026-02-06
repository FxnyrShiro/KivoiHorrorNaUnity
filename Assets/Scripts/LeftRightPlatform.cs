using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{
    public float min_x, max_x, speed, deflection;
    public bool is_going_left;
    Vector3 start_position;
    void Start()
    {
        start_position = transform.position;
        min_x = -2;
        max_x = 2;
        speed = 0.01f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deflection = transform.position.x - start_position.x;
        if (deflection >= max_x)
            is_going_left = true;
        if (deflection <= min_x)
            is_going_left = false;
        if (is_going_left) transform.Translate(new Vector3(-speed, 0, 0));
        if (!is_going_left) transform.Translate(new Vector3(speed, 0, 0));
    }
}
