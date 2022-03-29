using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TouchTarget: MonoBehaviour {

    public abstract void OnDown(Vector3 pt);
    public abstract void OnDrag(Vector3 pt);
    public abstract void OnUp();

    public int fingerID;

}
