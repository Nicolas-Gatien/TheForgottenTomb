using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            DeathByRock();
        } else if (collision.gameObject.CompareTag("Player Trap"))
        {
            DeathByTrap();
        }
    }

    public void DeathByRock()
    {
        gameManager.DeathRock();
    }
    public void DeathByTrap()
    {
        gameManager.DeathTrap();
    }
}
