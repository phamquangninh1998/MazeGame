
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
    public List<AudioClip> audioClips;
    public static int[] roomIdList;
    private void Awake()
    {
        if (roomIdList == null)
        {
            Debug.Log("empty");
            roomIdList = new int[3];

        }

    }
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

            Color newColor = colorList[0];
            colorList.RemoveAt(0);

            newItem.audio = audioClips[i];
            newItem.GetComponent<Renderer>().material.color = newColor;

            int newRoomId = 0;

            if (GameController.trial == 1)
            {
                newRoomId = Random.Range(lastRoomId + 1, roomCount - (numberOfItemToSpawn - i));
                lastRoomId = newRoomId;

                roomIdList[i] = newRoomId;

            }
            else
            {
                newRoomId = roomIdList[i];
            }

            Debug.Log("roomId " + newRoomId);
            RoomController selectedRoom = rooms.GetChild(newRoomId).GetComponent<RoomController>();
            selectedRoom.SetItem(newItem, i + 1);


        }
    }
}
