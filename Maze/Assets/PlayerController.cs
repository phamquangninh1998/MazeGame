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
    public GameObject resultTable;




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

        GameController.timeTravel += Time.deltaTime;
        GameController.distanceTravel += move.magnitude;


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

        int trial = GameController.trial;
        SaveTrialData(trial);

        if (trial == 5)
        {
            ShowResult();
        }
        else
        {
            GameController.trial++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }





    }

    private void ShowResult()
    {
        resultTable.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Replay()
    {
        Time.timeScale = 1;
        GameController.trial = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void SaveTrialData(int trial)
    {
        PlayerPrefs.SetInt("enterEmptyRoom" + trial, GameController.enterEmptyRoom);

        PlayerPrefs.SetInt("enterOldRoom" + trial, GameController.enterOldRoom);

        PlayerPrefs.SetInt("correct" + trial, GameController.correct);

        PlayerPrefs.SetInt("wrongColor" + trial, GameController.wrongColor);

        PlayerPrefs.SetInt("wrongAll" + trial, GameController.wrongAll);

        PlayerPrefs.SetFloat("distanceTravel" + trial, GameController.distanceTravel);

        PlayerPrefs.SetFloat("timeTravel" + trial, GameController.timeTravel);



        Debug.Log("enterEmptyRoom" + trial + "   " + GameController.enterEmptyRoom);

        Debug.Log("enterOldRoom" + trial + "   " + GameController.enterOldRoom);

        Debug.Log("correct" + trial + "   " + GameController.correct);

        Debug.Log("wrongColor" + trial + "   " + GameController.wrongColor);

        Debug.Log("wrongAll" + trial + "   " + GameController.wrongAll);

        Debug.Log("distanceTravel" + trial + "   " + GameController.distanceTravel);

        Debug.Log("timeTravel" + trial + "   " + GameController.timeTravel);
    }
}



