using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController character;

    public float speed = 12;
    private void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");


        Vector3 move = transform.right * x + transform.forward * z;

        character.Move(move * speed * Time.deltaTime);
    }
}
