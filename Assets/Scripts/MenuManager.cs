using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() {
        AudioManager.Instance.PauseMusic();
        SceneManager.LoadScene("Game"); 
    }

    public void ExitGame()
    {
        Application.Quit(); 
        Debug.Log("Saliendo del juego..."); 
    }

}
