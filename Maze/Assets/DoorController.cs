using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : RayCastItem
{
    public bool open = false;
    public bool visited;
    public RoomController parentRoom;
    public void Open()
    {
        CheckVisited();
        CheckEmpty();

        transform.parent.eulerAngles += new Vector3(0, 90, 0);
        open = true;
    }

    private void CheckEmpty()
    {
        if (parentRoom.empty)
        {
            if (PlayerController.instance.phase == 1)
            {

                GameController.enterEmptyRoom++;
                Debug.Log("enter Empty Room:" + GameController.enterEmptyRoom);
            }
        }
    }

    public void CheckVisited()
    {
        if (visited)
        {
            if (PlayerController.instance.phase == 1)
            {
                GameController.enterOldRoom++;

                Debug.Log("Enter old room:" + GameController.enterOldRoom);
            }

        }
        else
        {
            visited = true;
        }
    }

    private void Start()
    {
        visited = false;
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
