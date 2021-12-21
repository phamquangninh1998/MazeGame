using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController character;
    public int phase;
    public List<Item> collectedItem;
    public static PlayerController instance;
    public StartPlace startPlace;
    public GameObject backToBeginText;
    public GameObject collectText;
    public GameObject returnItemText;




    Vector3 startPos;



    private void Start()
    {
        startPos = transform.position;
    }
    private void Awake()
    {
        phase = 1;
        instance = this;
    }
    public float speed = 12;
    private void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");


        Vector3 move = transform.right * x + transform.forward * z;

        character.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ActivateStartPlace();
        }
    }

    public void AddItem(Item _item)
    {
        collectedItem.Add(_item);
        if (collectedItem.Count == 3)
        {
            ActivateStartPlace();
        }
    }

    private void ActivateStartPlace()
    {
        startPlace.gameObject.SetActive(true);
        backToBeginText.SetActive(true);
        collectText.SetActive(false);

    }
    internal void StartNextPhase()
    {
        phase = 2;
        backToBeginText.SetActive(false);
        returnItemText.SetActive(true);
        PlayCurrentItemAudio();
    }
    public void SetCurrentObjectToHand()
    {

    }
    public void PlayCurrentItemAudio()
    {
        if (collectedItem.Count == 0) return;
        Item currentItem = collectedItem[0];
        currentItem.PlayAudio();
    }
    public void ReturnItem(Item _item)
    {
        collectedItem.Remove(_item);

        PlayCurrentItemAudio();
        if (collectedItem.Count == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



