using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicStartet : MonoBehaviour
{ 
    void Start()
    {
        AudioManager.Instance.PlayGameMusic();
    }

}
