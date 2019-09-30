using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    int money;
    int treasures;
    public GameObject blood, coinsText, treasuresText, gameOverText;
    private void Start()
    {
        coinsText.SendMessage("UpdateText", money);
        treasuresText.SendMessage("UpdateText", treasures);
    }
    void CollectCoin(int value)
    {
        money += value;
        Debug.Log("add " + value + " coins. player have " + money + " coins");
        coinsText.SendMessage("UpdateText", money);
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
