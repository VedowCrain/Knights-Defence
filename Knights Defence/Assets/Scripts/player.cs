using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private float playerHealth;
    private float maxHealth = 100;
    public float bossDamage = 5;
    public Image healthLiqued;

    private void Start()
    {
        playerHealth = maxHealth;
    }

    private void Update()
    {
        healthLiqued.fillAmount = playerHealth / maxHealth;
    }

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
