using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : RayCastItem
{
    public bool open = false;
    public void Open()
    {
        transform.parent.eulerAngles += new Vector3(0, 90, 0);
        open = true;
    }

    public void Close()
    {
        transform.parent.localEulerAngles = new Vector3(0, -180, 0);

        open = false;
    }

    public override void OnRayCast()
    {
        base.OnRayCast();

        if (open)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
