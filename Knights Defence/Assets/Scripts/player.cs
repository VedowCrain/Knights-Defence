using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100;
    public float bossDamage = 5;

    private void OnTriggerEnter(Collider other)
    {
        print("Collision");

        if (other.gameObject.CompareTag("Boss"))
        {
            playerHealth -= bossDamage;
            print("Player Health " + playerHealth);
        }

        if (playerHealth <= 0)
        {
            print("You Died");
        }
    }
}
