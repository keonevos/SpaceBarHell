using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public float bulletSpeed = 1f;
    private Vector2 spawnPoint;
    private float timer = 0f;

    public int hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * bulletSpeed * transform.right.x;
        float y = timer * bulletSpeed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer") || collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.Instance.Death(hitPoint);
            Destroy(gameObject);
        }
    }
}
