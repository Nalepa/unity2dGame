using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    public bool IsMovingX;
    bool DirectionX;
    public float DistanceX;
    public float MoveSpeedX;

    public bool IsMovingY;
    bool DirectionY;
    public float DistanceY;
    public float MoveSpeedY;

    Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
       StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovingY)
        {
            if (transform.position.y >= StartPosition.y + DistanceY) DirectionY = false;
            else if (transform.position.y <= StartPosition.y) DirectionY = true;

            if (DirectionY)
                transform.Translate(Vector2.up * MoveSpeedY * Time.deltaTime);
            else
                transform.Translate(Vector2.down * MoveSpeedY * Time.deltaTime);
        }
        if(IsMovingX)
        {
            if (transform.position.x >= StartPosition.x + DistanceX) DirectionX = false;
            else if (transform.position.x <= StartPosition.x) DirectionX = true;

            if (DirectionX)
                transform.Translate(Vector2.right * MoveSpeedX * Time.deltaTime);
            else
                transform.Translate(Vector2.left * MoveSpeedX * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.SendMessage("Death");
    }
}
