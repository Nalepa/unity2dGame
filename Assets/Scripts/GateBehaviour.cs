using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GateBehaviour : MonoBehaviour
{
    TextMeshPro text;
    bool isObject;
    public GameObject levelMenu;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        text.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isObject = true;
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isObject = false;
            text.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isObject && Input.GetKey(KeyCode.O))
        {
            if(!PlayerPrefs.HasKey("lvl1BestCoins") || PlayerPrefs.GetInt("lvl1BestCoins") < PlayerEquipment.coins)
            PlayerPrefs.SetInt("lvl1BestCoins", PlayerEquipment.coins);
            if (!PlayerPrefs.HasKey("lvl1BestTreasures") || PlayerPrefs.GetInt("lvl1BestTreasures") < PlayerEquipment.treasures)
                PlayerPrefs.SetInt("lvl1BestTreasures", PlayerEquipment.treasures);
            PlayerPrefs.Save();
            CoinBehaviour.numberOfCoins = 0;
            ChestBehaviour.numerOfChests = 0;
            SceneManager.LoadScene("Menu");
        }
    }
}
