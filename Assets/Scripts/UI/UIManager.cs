using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text coinText;
    public TMP_Text distanceText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateCoinText(int coins)
    {
        coinText.text = coins.ToString();
    }

    public void UpdateDistanceText(float distance)
    {
        distanceText.text = Mathf.FloorToInt(distance).ToString() + " m";
    }
}
