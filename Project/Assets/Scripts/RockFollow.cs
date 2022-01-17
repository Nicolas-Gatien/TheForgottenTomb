using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFollow : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    Vector3 followPoint;

    // Update is called once per frame
    void Update()
    {
        followPoint = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0f);

        transform.position = Vector3.MoveTowards(transform.position, followPoint, moveSpeed * Time.deltaTime);
    }
}
