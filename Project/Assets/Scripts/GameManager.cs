using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject rock;
    public GameObject player;
    public TilemapRenderer rockmap;

    bool death = false;
    bool end = false;

    SpriteRenderer rockRenderer;

    public GameObject deathAnimation;
    public GameObject deathAnimationSpike;

    public GameObject pausePrefab;
    public GameObject controlMenu;

    public bool paused = false;

    public GameObject[] pedestals;
    public Sprite filledPedestal;

    public GameObject finalDoor;
    public Sprite openedFinalDoor;

    public GameObject winAnimation;
    public GameObject doorBlocker;

    public GameObject bloodParticle;
    public GameObject winMusic;

    bool finishedGame;

    private void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("DeathMusic"));
    }

    // Update is called once per frame
    void Update()
    {
        if (death != true && end != true && paused != true)
        {
            if (Input.GetAxisRaw("View Switch") == 1)
            {
                rock.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                player.GetComponent<SpriteRenderer>().enabled = false;

                rockmap.enabled = true;
            }
            else if (Input.GetAxisRaw("View Switch") != 1)
            {
                rock.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f);
                player.GetComponent<SpriteRenderer>().enabled = true;

                rockmap.enabled = false;
            }
        }
        if (paused == false && end == false && death == false)
        {
            if (Input.GetAxisRaw("Pause") == 1)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                Instantiate(pausePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                paused = true;
            }
        }
    }

    public void DeathRock()
    {
        FindObjectOfType<AudioManager>().PlaySound("Rock");

        death = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        rock.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(doorBlocker, player.transform.position, Quaternion.identity);
        Instantiate(bloodParticle, player.transform.position, Quaternion.identity);


        FindObjectOfType<SceneTransition>().LoadScene(3);
    }
    public void DeathTrap()
    {
        FindObjectOfType<AudioManager>().PlaySound("Trap");

        death = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        rock.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(bloodParticle, player.transform.position, Quaternion.identity);

        FindObjectOfType<SceneTransition>().LoadScene(2);
    }

    //End game method
    public void End()
    {
        end = true;

        for (int i = 0; i < pedestals.Length; i++)
        {
            pedestals[i].GetComponent<SpriteRenderer>().sprite = filledPedestal;
        }

        finalDoor.GetComponent<SpriteRenderer>().sprite = openedFinalDoor;
        Destroy(rock);
        Instantiate(doorBlocker, new Vector2(16, -2), Quaternion.identity);

    }

    public void FinishGame()
    {
        if (!finishedGame)
        {
            finishedGame = true;
            Instantiate(winAnimation, player.transform.position, Quaternion.identity);
            Instantiate(winMusic, player.transform.position, Quaternion.identity);

            Destroy(player);

            FindObjectOfType<SceneTransition>().LoadScene(6);
        }
    }
}
