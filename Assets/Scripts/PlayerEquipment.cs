using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public static int coins, treasures, levelNumber;
    public GameObject blood, coinsText, treasuresText, gameOverText;

    private void Start()
    {
        levelNumber = 1;
        coins = treasures = 0;
        coinsText.SendMessage("UpdateText", coins);
        treasuresText.SendMessage("UpdateText", treasures);
    }
    void CollectCoin(int value)
    {
        coins += value;
        Debug.Log("add " + value + " coins. player have " + coins + " coins");
        coinsText.SendMessage("UpdateText", coins);
    }
    void CollectTreasure(int value)
    {
        treasures += value;
        Debug.Log("add " + value + " treasures. player have " + treasures + " treasures");
        treasuresText.SendMessage("UpdateText", treasures);
    }
    void Death()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameOverText.SendMessage("Display");
    }
    void Sink()
    {
        Destroy(gameObject, 0.1f);
        gameOverText.SendMessage("Display");
    }

}
