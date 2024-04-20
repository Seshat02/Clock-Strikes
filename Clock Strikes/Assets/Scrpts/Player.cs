using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 comand = Vector3.zero;

        bool isLeft = Input.GetKey(KeyCode.A);
        bool isRight = Input.GetKey(KeyCode.D);
        bool isUp = Input.GetKey(KeyCode.Space);

        if (isLeft)        
            comand.x -= speed;
        
        if (isRight)        
            comand.x += speed;

        if (isUp)
            comand.y += speed;
        
        transform.position += comand * Time.deltaTime;
    }
}
