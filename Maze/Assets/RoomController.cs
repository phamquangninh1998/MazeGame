using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int id;
    public GameObject door;
    public Transform itemPosition;

    private void Awake()
    {
        id = transform.GetSiblingIndex();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        door.SetActive(true);
    }

    private void OpenDoor()
    {
        door.SetActive(false);
    }

    internal void SetItem(Item newItem)
    {
        newItem.transform.position = itemPosition.position;
        newItem.roomId = id;
    }
}
