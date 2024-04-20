using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public gameOver gameOver;

    private bool died;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D spike)
    {
        if (spike.gameObject.CompareTag("spike") && !died)
        {
            died = false;
            gameOver.GameOver();

            Destroy(gameObject);
        }      
         
    }
    private void OnCollisionEnter2D(Collision2D enemyCrash)
    {
        enemyCrash.gameObject.CompareTag("Enemy");

        //Debug.Log("dead");
    }
}
