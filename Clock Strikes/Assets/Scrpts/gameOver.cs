using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public GameObject gameOverScreen;  

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
