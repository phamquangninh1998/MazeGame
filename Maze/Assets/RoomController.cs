using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int id;
    public Transform itemPosition;
    public Tray tray;

    public DoorController door;
    private void Awake()
    {
        id = transform.GetSiblingIndex();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Close();
        }
    }


    internal void SetItem(Item newItem)
    {
        newItem.transform.position = itemPosition.position;
        newItem.roomId = id;
        newItem.tray = this.tray;
        tray.empty = false;
    }
}
