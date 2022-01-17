using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public float cooldown = 0f;
    public float overlapCircleRadius = 0.2f;

    private Vector2 movement;

    public Animator anim;
    public AudioSource source;

    void Start()
    {
        movePoint.parent = null;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetFloat("movementY", movement.x);
        anim.SetFloat("movementX", movement.y);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && cooldown == 0)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) // Moving Left or Right
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), overlapCircleRadius, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    cooldown = 0.1f;
                    if(Random.Range(0, 2) == 0)
                    {
                        source.Play();
                    }

                    anim.SetBool("moving", true);

                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) // Moving Up or Down
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), overlapCircleRadius, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    cooldown = 0.1f;
                    if (Random.Range(0, 2) == 0)
                    {
                        source.Play();
                    }

                    anim.SetBool("moving", true);
                }
            }

        }
        if(movement == Vector2.zero)
        {
            anim.SetBool("moving", false);

        }


    }

    void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
        }else 
        { 
            cooldown = 0; 
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(movePoint.position, overlapCircleRadius);
    }*/
}
