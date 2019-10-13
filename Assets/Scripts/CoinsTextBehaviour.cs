using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsTextBehaviour : MonoBehaviour
{
    Text text;

    void Start() => text = GetComponent<Text>();
    
    void UpdateText(int value) => text.text = "Coins: " + value + "/" + CoinBehaviour.numberOfCoins;
    
}
