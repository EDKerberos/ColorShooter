using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private bool gameDone = false;
    [SerializeField] private GameObject gameOverScreen; 
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject player;

    public void EndGame()
    {
        if(gameDone == false)
        {
            gameDone = true;
            Freeze();
            gameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Freeze()
    {
        if(gameDone == true)
        {
            spawner.SetActive(false);
            player.SetActive(false);
        }
    }
}
