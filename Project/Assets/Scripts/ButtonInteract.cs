using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public bool button1 = false;
    public bool button2 = false;

    public Sprite openSprite;

    public BoxCollider2D doorCollider;
    public SpriteRenderer doorRenderer;

    bool open = false;

    private void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button1 == true && button2 == true)
        {
            if (!open)
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        open = true;
        doorCollider.enabled = false;
        doorRenderer.sprite = openSprite;
    }
}
