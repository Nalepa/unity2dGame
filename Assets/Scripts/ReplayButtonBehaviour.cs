using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButtonBehaviour : MonoBehaviour
{

   public void ReplayLevel()
    {
        CoinBehaviour.numberOfCoins = 0;
        ChestBehaviour.numerOfChests = 0;
        SceneManager.LoadScene(PlayerEquipment.levelNumber);
    }
}
