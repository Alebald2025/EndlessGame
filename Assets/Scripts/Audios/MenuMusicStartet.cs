using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicStartet : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMenuMusic();
    }

}
