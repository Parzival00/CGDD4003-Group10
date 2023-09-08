using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] Vector3 destinationOffset;

    //Teleports the enemy and player to destination (used to make the map feel infinite)
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Ghost ghost = other.gameObject.GetComponent<Ghost>();

            if (ghost != null)
                ghost.SetPosition(destination.position + destinationOffset);
        }
        else if (other.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (player != null)
                player.SetPosition(destination.position + destinationOffset);
        }
    }
}
