using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CoinBehaviour : MonoBehaviour
    {
        public static int numberOfCoins;
        int value = 1;

        private void Awake()
        {
        Debug.Log("create coin");
        numberOfCoins++;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.SendMessage("CollectCoin", value);
                Destroy(gameObject);
            }
        }

    private void OnDestroy()
    {
        Debug.Log("destry coin");
    }

}
