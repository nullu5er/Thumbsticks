using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    [SerializeField] GameObject mazeBoard;

    // Start is called before the first frame update
    void Start()
    {
        
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

        Vector3 rotation = new Vector3(input.x, 0.0f, input.y);

        Vector3 rotationCache = mazeBoard.transform.rotation.eulerAngles;

        mazeBoard.transform.Rotate(rotation);

        if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x) > 45.0f && Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.x) < 315.0f)
        {
            if (input.x > 0.0f)
            {
                Vector3 rotationTemp = new Vector3(45, 0.0f, mazeBoard.transform.rotation.eulerAngles.z);
                mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
            }
            else if (input.x < 0.0f)
            {
                Vector3 rotationTemp = new Vector3(315, 0.0f, mazeBoard.transform.rotation.eulerAngles.z);
                mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
            }
        }


        if (Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) > 45.0f && Mathf.Abs(mazeBoard.transform.rotation.eulerAngles.z) < 315.0f)
        {
            if (input.y > 0.0f)
            {
                Vector3 rotationTemp = new Vector3(mazeBoard.transform.rotation.eulerAngles.x, 0.0f, 45.0f);
                mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
            }
            else if(input.y < 0.0f)
            {
                Vector3 rotationTemp = new Vector3(mazeBoard.transform.rotation.eulerAngles.x, 0.0f, 315.0f);
                mazeBoard.transform.rotation = Quaternion.Euler(rotationTemp);
            }
        }

        //Vector3 camFwd = cam.transform.forward;
        //camFwd.y = 0;
        //camFwd.Normalize();

        //Vector3 delta = cam.transform.right * input.x + camFwd * input.y;

        //cc.Move(delta * Time.deltaTime * speed);
    }
}
