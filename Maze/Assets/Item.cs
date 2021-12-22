using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : RayCastItem
{
    public int roomId;
    public Tray tray;
    public AudioClip audio;
    public AudioSource audioSource;


    private void Start()
    {
        audioSource = PlayerController.instance.GetComponent<AudioSource>();
    }
    public override void OnRayCast()
    {
        base.OnRayCast();

        if (PlayerController.instance.phase == 2) return;

        tray.empty = true;
        tray.parentRoom.empty = true;

        AddToCollectedList();
    }

    private void AddToCollectedList()
    {
        gameObject.SetActive(false);
        PlayerController.instance.AddItem(this);
    }




    public void PlayAudio()
    {
        Debug.Log(audio.name);
        audioSource.clip = audio;
        audioSource.Play();
    }
}
