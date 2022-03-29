using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceUp = 1;
    public float distanceBack = 4;
    public float speed = 5;
    public float currentDist;
    public Thumbstick thumbstick;

    // Start is called before the first frame update
    void Start()
    {
        currentDist = distanceBack;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;
#if UNITY_ANDROID
        input.x = thumbstick.xAxis;
        input.y = thumbstick.yAxis;
#else
        if (Input.GetMouseButton(1))
        {
            input.x = Input.GetAxis("Mouse X");
            input.y = Input.GetAxis("Mouse Y");
        }
#endif
        // right drag rotates the camera
        if (input.x !=0 || input.y != 0)
        {
            Vector3 angles = transform.eulerAngles;
            // look up and down by rotating around X-axis, clamping between 0 (looking forwards) and 70 degrees (looking down before gimbal lok at 90)
            angles.x = Mathf.Clamp(angles.x + input.y * speed, 0, 70);
            // spin the camera round 
            angles.y += input.x * speed;
            transform.eulerAngles = angles;
        }

        // zoom in/out with mouse wheel
        distanceBack = Mathf.Clamp(distanceBack - Input.GetAxis("Mouse ScrollWheel") * speed, 2, 10);

        // look at the target point
        transform.position = target.position
            + distanceUp * Vector3.up
            - currentDist * transform.forward;
    }
}
