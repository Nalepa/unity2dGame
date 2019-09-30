using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    Animator animator;
    void Start()
    {
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
        animator.SetBool("death", false);
        text.enabled = false;
    }

    void Display()
    {
        text.enabled = true;
        animator.SetBool("death", true);
    }
}
