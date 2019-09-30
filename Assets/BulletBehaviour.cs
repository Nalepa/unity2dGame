using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Vector2 direction;
    public float speed;
    public float lifeTime;
    float time = 0.0f;

    private void SetDirection(bool dir) => direction = dir ? Vector2.right : Vector2.left;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime) Destroy(gameObject);
        else transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("Death");
            Destroy(gameObject);
        }
        else if (collision.tag == "CollidableEnvironment")
        {
            Destroy(gameObject);
        }
    }

}
