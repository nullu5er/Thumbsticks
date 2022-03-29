using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    CharacterController cc;
    Camera cam;
    public Thumbstick thumbstick;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        // assume this doesn't change, so grab it here instead of calling it every frame
        // (which does a FindObjectWithTag on every call)
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;
#if UNITY_ANDROID
        input.x = thumbstick.xAxis;
        input.y = thumbstick.yAxis;
#else
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
#endif

        Vector3 camFwd = cam.transform.forward;
        camFwd.y = 0;
        camFwd.Normalize();

        Vector3 delta = cam.transform.right * input.x + camFwd * input.y;

        cc.Move(delta * Time.deltaTime * speed);
    }
}
