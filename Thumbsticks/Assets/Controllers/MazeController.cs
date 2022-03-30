using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    [SerializeField] GameObject mazeBoard;
    public Thumbstick thumbstick;
    float rotX, rotZ;
    // Start is called before the first frame update
    void Start()
    {
        rotX = rotZ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;
#if UNITY_ANDROID
        input.x = thumbstick.xAxis;
        input.y = thumbstick.yAxis;
#else
        input.y = Input.GetAxis("Horizontal")*-1;
        input.x = Input.GetAxis("Vertical");
#endif

        if(Mathf.Abs(input.x) > Mathf.Epsilon)
        {
            if (input.x > 0.0f)
            {
                if(Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x)+input.x > 20.0f)
                { rotX = 0.0f; }
                else
                { rotX = input.x; }
            }
            else if (input.x < 0.0f)
            {
                if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x) + input.x < 340.0f)
                { rotX = 0.0f; }
                else
                { rotX = input.x; }
            }
        }

        if (Mathf.Abs(input.y) > Mathf.Epsilon)
        {
            if (input.y > 0.0f)
            {
                if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) + input.y > 20.0f)
                { rotZ = 0.0f; }
                else
                { rotZ = input.y; }
            }
            else if (input.y < 0.0f)
            {
                if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) + input.y < 340.0f)
                { rotZ = 0.0f; }
                else
                { rotZ = input.y; }
            }
        }

        Vector3 rotationVec = new Vector3(rotX, 0.0f, rotZ);

        mazeBoard.transform.Rotate(rotationVec);
        //Vector3 rotation = new Vector3(input.x, 0.0f, input.y);

        //Vector3 rotationCache = mazeBoard.transform.rotation.eulerAngles;


        //if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x) > 20.0f && Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x) < 340.0f)
        //{
        //    if (input.x > 0.0f)
        //    {
        //        Vector3 rotationTemp = new Vector3(20.0f, 0.0f, mazeBoard.transform.rotation.eulerAngles.z);
        //        mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
        //    }
        //    else if (input.x < 0.0f)
        //    {
        //        Vector3 rotationTemp = new Vector3(340.0f, 0.0f, mazeBoard.transform.rotation.eulerAngles.z);
        //        mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
        //    }            
        //}
        //else
        //{
        //    rotX += input.x;            
        //}


        //if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) > 20.0f && Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) < 340.0f)
        //{
        //    if (input.y > 0.0f)
        //    {
        //        Vector3 rotationTemp = new Vector3(mazeBoard.transform.rotation.eulerAngles.x, 0.0f, 20.0f);
        //        mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
        //    }
        //    else if(input.y < 0.0f)
        //    {
        //        Vector3 rotationTemp = new Vector3(mazeBoard.transform.rotation.eulerAngles.x, 0.0f, 340.0f);
        //        mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
        //    }
        //}
        //else
        //{
        //    rotZ += input.y;

        //}


        //if (input.x > Mathf.Epsilon || input.y > Mathf.Epsilon)
        //{
        //    Vector3 newRotation = new Vector3(rotX, 0.0f, rotZ);
        //    mazeBoard.transform.Rotate(newRotation);
        //}


        //Vector3 camFwd = cam.transform.forward;
        //camFwd.y = 0;
        //camFwd.Normalize();

        //Vector3 delta = cam.transform.right * input.x + camFwd * input.y;

        //cc.Move(delta * Time.deltaTime * speed);
    }
}
