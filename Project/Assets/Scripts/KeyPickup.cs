using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] keys;
    public Sprite key;
    public Sprite ghostKey;

    public int numberOfKeys = 0;
    bool reachedEnd = false;
    bool reachedDoor = false;

    private void Start()
    {
        numberOfKeys = 0;
        keys = GameObject.FindGameObjectsWithTag("KeyHolder");
    }
    void Update()
    {
        if (numberOfKeys == 5 && reachedEnd == true)
        {
            gameManager.End();
        }
        if (numberOfKeys == 5 && reachedDoor)
        {
            gameManager.FinishGame();
        }

        if (numberOfKeys == 5)
        {
            keys[4].GetComponent<Image>().sprite = key;
        }else if (numberOfKeys == 4)
        {
            keys[3].GetComponent<Image>().sprite = key;
        }
        else if (numberOfKeys == 3)
        {
            keys[2].GetComponent<Image>().sprite = key;
        }
        else if (numberOfKeys == 2)
        {
            keys[1].GetComponent<Image>().sprite = key;
        }
        else if (numberOfKeys == 1)
        {
            keys[0].GetComponent<Image>().sprite = key;
        }
        else if (numberOfKeys == 0)
        {
            keys[0].GetComponent<Image>().sprite = ghostKey;
        }

        if (numberOfKeys == 5 && reachedEnd == true)
        {
            Destroy(keys[0]);
            Destroy(keys[1]);
            Destroy(keys[2]);
            Destroy(keys[3]);
            Destroy(keys[4]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            reachedEnd = true;
            Debug.Log("Reached End");
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Key");
            numberOfKeys += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Final Door"))
        {
            reachedDoor = true;
        }
        else
        {
            reachedEnd = false;
            reachedDoor = false;
        }
    }
}
