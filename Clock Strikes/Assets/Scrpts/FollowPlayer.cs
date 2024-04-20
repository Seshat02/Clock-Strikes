using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    public float speed;

    void Update()
    {
        
        Vector3 direction = player.position + offset;
        transform.position = Vector3.Lerp(transform.position,direction,speed * Time.deltaTime);
    }
}
