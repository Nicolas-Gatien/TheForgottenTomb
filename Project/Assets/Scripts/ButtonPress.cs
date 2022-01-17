using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite buttonPressed;
    public ButtonInteract interactScript;
    public BoxCollider2D buttonCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Action();
            spriteRenderer.sprite = buttonPressed;
        }
    }

    void Action()
    {
        FindObjectOfType<AudioManager>().PlaySound("Door");

        if (interactScript.button1 == false && interactScript.button2 == true)
        {
            interactScript.button1 = true;
        }else if (interactScript.button1 == true && interactScript.button2 == false)
        {
            interactScript.button2 = true;
        }else
        {
            interactScript.button1 = true;
        }

        buttonCollider.enabled = false;
    }
}
