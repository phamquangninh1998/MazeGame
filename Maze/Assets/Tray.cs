using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : RayCastItem
{
    public bool empty = true;

    public RoomController parentRoom;
    public Transform itemPos;
    public override void OnRayCast()
    {
        base.OnRayCast();

        ReceiveItem();

    }

    public void ReceiveItem()
    {
        if (!empty) return;
        if (PlayerController.instance.phase == 1) return;
        if (PlayerController.instance.collectedItem.Count == 0) return;

        Item firstItem = PlayerController.instance.collectedItem[0];

        firstItem.transform.position = itemPos.position;
        firstItem.gameObject.SetActive(true);

        firstItem.tray = this;

        if (firstItem.roomId == parentRoom.id)
        {
            GameController.correct++;
        }
        else
        {
            if (parentRoom.id == 0)
            {
                GameController.wrongAll++;
            }
            else
            {
                GameController.wrongColor++;
            }
        }
        PlayerController.instance.ReturnItem(firstItem);


        empty = false;
    }
}
