using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 1f;
    public Vector2 randomAccuracy;

    public int scorePoint;


    public void Shoot(Vector3 targetPos) // Merci Alexandrine Fabien pour le morceau en dessous
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos += (Vector3)(Random.insideUnitCircle * randomAccuracy) * Mathf.Sign(Random.value *2 -1); // Fais un random de positon entre plusieurs chiffres positif et le MathF le passe avec un entre deux negatifs
        Vector3 dir = targetPos - transform.position;
        rb.velocity = dir.normalized * bulletSpeed; // Normaliser la velocité

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.instance.AddScore(scorePoint);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
