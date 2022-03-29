using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationDisplay : MonoBehaviour
{
    public bool showGyroscope;

    Slider slider;
    Text text;
    Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        text = GetComponent<Text>();
        gyro = Input.gyro;
        if (gyro != null && SystemInfo.supportsGyroscope)
        {
            gyro.enabled = true;
        }
        else
        {
            // turn off gyroscope controls if we don't have one on the device
            if (text != null && showGyroscope)
                gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider)
        {
            // for sliders, show the x or y component of the accelerometer based on slider orientation
            bool vertical = slider.direction == Slider.Direction.BottomToTop || slider.direction == Slider.Direction.TopToBottom;
            slider.value = vertical ? Input.acceleration.y : Input.acceleration.x;
        }
        if (text)
        {
            // show either the acceleration or gyroscope as Euler angles for text fields
            Vector3 v = (showGyroscope && gyro!=null) ? gyro.attitude.eulerAngles : Input.acceleration;
            text.text = string.Format("[{0:F1},{1:F1},{2:F1}]", v.x, v.y, v.z);
        }
    }
}
