using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerJump jump;

    public GameObject gameOverMenu;

    void Start()
    {
        jump = GetComponent<PlayerJump>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameOver();
        }
        if (other.CompareTag("FullLaneObstacle") && jump.isGrounded)
        {
            Debug.Log("Debías saltar → Game Over");
            GameOver();
        }
        if (other.CompareTag("FullLaneObstacle"))
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        gameOverMenu.SetActive(true); 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Menu"); }
    }
