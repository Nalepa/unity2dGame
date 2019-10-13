using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverTextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    Animator animator;
    float time;
    public float liveTime;
    void Start()
    {
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
        animator.SetBool("death", false);
        text.enabled = false;
    }

    private void Update()
    {
        if(text.enabled)
        {
            time += Time.deltaTime;
            if (time > liveTime)
            {
                CoinBehaviour.numberOfCoins = 0;
                ChestBehaviour.numerOfChests = 0;
                SceneManager.LoadScene("Menu");
            }
        }
    }


    void Display()
    {
        text.enabled = true;
        animator.SetBool("death", true);
    }
}
