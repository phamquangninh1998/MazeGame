using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.StartNextPhase();
            gameObject.SetActive(false);
        }
    }
}
