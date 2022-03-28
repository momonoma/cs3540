using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitBehavior : MonoBehaviour
{
    private bool touchingDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingDoor = false;
        }
    }

    private void Update()
    {
        if (LevelManager.enemiesDead && touchingDoor)
        {
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }
    }
}
