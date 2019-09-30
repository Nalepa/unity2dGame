using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    MeshRenderer meshRenderer;
    TextMesh textMesh;
    Animator animator;
    Collider2D other;
    bool IsOpen;
    bool IsCollision;
    float timer = 0.5f;
    public int value = 1;
    public static int numerOfChests;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsOpen", IsOpen);
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        textMesh = GetComponentInChildren<TextMesh>();
        numerOfChests++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsCollision = true;
        other = collision;
        meshRenderer.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsCollision = false;
        other = null;
        meshRenderer.enabled = false;
    }
    private void Update()
    {
        if(IsCollision)
        {
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.O) && timer > 0.5)
            {
                timer = 0.0f;
                if (!IsOpen)
                {
                    IsOpen = true;
                    animator.SetBool("IsOpen", IsOpen);
                    if(value !=0) other.SendMessage("CollectTreasure", value);
                    value = 0;
                    Debug.Log("Open chest");
                    textMesh.text = "press o to close";
                }
                else
                {
                    IsOpen = false;
                    animator.SetBool("IsOpen", IsOpen);
                    Debug.Log("Close chest");
                    textMesh.text = "press o to open";
                }
            }
        }   
      }   
}
