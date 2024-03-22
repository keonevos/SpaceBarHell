using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public PlayerBulletScript m_bullet;
    public Transform m_enemy;

    public float spawnCoroutineSecondRate = 1f;
    private void Awake()
    {
        StartCoroutine(Spawner());
    }
    void Update()
    {

    }
    IEnumerator Spawner()
    {
        PlayerBulletScript newBullet = Instantiate(m_bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Spawn les balles par rapport au spawn point
        newBullet.Shoot(m_enemy.transform.position); // Target la position de l'ennemi
        yield return new WaitForSeconds(spawnCoroutineSecondRate);
        StartCoroutine(Spawner());
    }
}
