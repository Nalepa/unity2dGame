using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : MonoBehaviour
{

    public void ReturnToMenu()
    {
        CoinBehaviour.numberOfCoins = 0;
        ChestBehaviour.numerOfChests = 0;
        SceneManager.LoadScene("Menu");
    }
    
}
