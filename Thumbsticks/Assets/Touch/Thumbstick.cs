using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Thumbstick : TouchTarget
{

    public Vector3 mouseDownPos;

    Vector3 pos;
    public float extents = 32;
    public float xAxis;
    public float yAxis;


#if UNITY_ANDROID

  // handled in TouchManager class

#else
    // mouse based input
    public void OnMouseDown()
    {
        OnDown(Input.mousePosition);
    }

    public void OnMouseDrag()
    {
        OnDrag(Input.mousePosition);
    }

    public void OnEndDrag()
    {
        OnUp();
    }
#endif

    public override void OnDown(Vector3 pt)
    {
        mouseDownPos = pt;
    }

    public override void OnDrag(Vector3 pt)
    {
        pos = pt - mouseDownPos;
        pos.x = Mathf.Clamp(pos.x, -extents, extents);
        pos.y = Mathf.Clamp(pos.y, -extents, extents);
        transform.localPosition = pos;
        xAxis = pos.x / extents;
        yAxis = pos.y / extents;
    }

    public override void OnUp()
    {
        pos = transform.localPosition = Vector3.zero;
        xAxis = yAxis = 0;
    }
}
