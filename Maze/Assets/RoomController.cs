using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int id=0;
    public bool empty = true;
    public Transform itemPosition;
    public Tray tray;
    public DoorController door;
   
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.Close();
        }
    }


    internal void SetItem(Item newItem,int newId)
    {
        empty = false;
        newItem.transform.position = itemPosition.position;

        newItem.roomId = newId;
        this.id = newId;

        newItem.tray = this.tray;
        tray.empty = false;
    }
}
