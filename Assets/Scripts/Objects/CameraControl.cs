using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject target;
    public float dead_inside,speed;
    private void Awake()
    {
        dead_inside = 2;
        speed = 10;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > dead_inside)
        {
            //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position + new Vector3(0,0,-10), speed*Time.deltaTime);
        }
    }
}
