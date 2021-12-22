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
            GameController.enterEmptyRoom++;
        }
    }

    public void CheckVisited()
    {
        if (visited)
        {
            GameController.enterOldRoom++;

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
