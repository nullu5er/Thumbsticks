using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour {

#if UNITY_ANDROID

    // store a list of which object is associated with each finger
    Dictionary<int, TouchTarget> targets = new Dictionary<int, TouchTarget>();

    // Update is called once per frame
    void Update () {

        // get all touches. Each touch has a consistent fingerId to retain continuity
        Touch[] touches = Input.touches;
        foreach (Touch t in touches)
        {
            switch (t.phase)
            {
                case TouchPhase.Began:
                    // touched down - see if we've hit a target
                    GameObject obj = GetObjectUnderPos(t.position);
                    TouchTarget target = obj.GetComponent<TouchTarget>();
                    if (target)
                    {
                        target.OnDown(t.position);
                        targets[t.fingerId] = target;
                    }
                    break;
                case TouchPhase.Ended:
                    // touch up, call the function on the target for that finger
                    if (targets.ContainsKey(t.fingerId) && targets[t.fingerId]!= null)
                    {
                        targets[t.fingerId].OnUp();
                        targets.Remove(t.fingerId);
                    }
                    break;
                case TouchPhase.Moved:
                    // moving, drag the item associated with this finger
                    if (targets.ContainsKey(t.fingerId) && targets[t.fingerId] != null)
                    {
                        targets[t.fingerId].OnDrag(t.position);
                    }
                    break;
            }
        }
    }

    // helper function for getting the UI pbject at a point
    List<RaycastResult> hitObjects = new List<RaycastResult>();
    GameObject GetObjectUnderPos(Vector3 position)
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = position;
        EventSystem.current.RaycastAll(pointer, hitObjects);
        return (hitObjects.Count <= 0) ? null : hitObjects[0].gameObject;
    }

#endif
}
