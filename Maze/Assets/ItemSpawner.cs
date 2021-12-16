
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public int numberOfItemToSpawn = 3;
    public int roomCount;
    public Item itemPrefab;
    public Transform rooms;
    public List<Color> colorList;

    private void Start()
    {
        roomCount = rooms.childCount;
        SpawnItemToRoom();
    }

    private void SpawnItemToRoom()
    {
        int lastRoomId = -1;
        for (int i = 0; i < numberOfItemToSpawn; i++)
        {
            Item newItem = Instantiate(itemPrefab);

            int newRandomColorIndex = Random.Range(0, colorList.Count);
            Color randomColor = colorList[newRandomColorIndex];
            colorList.RemoveAt(newRandomColorIndex);

            newItem.GetComponent<Renderer>().material.color = randomColor;


            int newRoomId = Random.Range(lastRoomId + 1, roomCount - (numberOfItemToSpawn - i));

            lastRoomId = newRoomId;

            RoomController selectedRoom = rooms.GetChild(newRoomId).GetComponent<RoomController>();

            selectedRoom.SetItem(newItem);
        }
    }
}
