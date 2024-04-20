using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    private Transform actualPoint;

    private bool isChangingAngle;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        actualPoint = point1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = actualPoint.position - transform.position;
        if (actualPoint == point1.transform)
        {
            rb.velocity = new Vector2(-speed, 0);

            anim.SetBool("isMoving", true);

        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

      
        if (Vector2.Distance(transform.position, actualPoint.position) < 0.5f && actualPoint == point1.transform)
        {
            actualPoint = point2.transform;
        }
        if (Vector2.Distance(transform.position, actualPoint.position) < 0.5f && actualPoint == point2.transform)
        {
            actualPoint = point1.transform;
        }

        //Flip
        if (!isChangingAngle && actualPoint == point1.transform)
        {
            EnemyChanging();
        }
        else if (isChangingAngle && actualPoint == point2.transform)
        {
            EnemyChanging();
        }
    }

    private void EnemyChanging()
    {
        isChangingAngle = !isChangingAngle;

        Vector3 flipInX = transform.localScale;
        flipInX.x *= -1;

        transform.localScale = flipInX;
    }
    
}
