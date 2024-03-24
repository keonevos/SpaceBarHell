using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{

    [Header("Bullet Setting")]
    public Transform bulletSpawnPoint;
    [SerializeField] private PlayerBulletScript m_bullet;
    [SerializeField] private PlayerBulletScript m_superBullet;
    [SerializeField] private float chargeSpeed = 1f;
    [SerializeField] private float chargeNeeded = 2f;
    [SerializeField] private float chargeTime;
    [SerializeField] private bool isCharging;
    public float spawnCoroutineSecondRate = 1f;

    [Header("Enemy")]
    public Transform m_enemy;

    [Header("TimerManagement")]
    public TimeManager TimeManager;
    public Camera m_camera;
    public float decay = 1f;
    private float Timedecay;

    private void Awake()
    {
        StartCoroutine(Spawner());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && chargeTime < chargeNeeded) 
        {
          
            isCharging = true;      
            
            if (isCharging && Timedecay > 0)
            {
                Debug.Log("temps");
                Timedecay -= Time.deltaTime;
            }

            if (isCharging && Timedecay < 0)
            {
               TimeManager.Slowmotion();
               chargeTime += chargeSpeed * Time.deltaTime;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (chargeTime > chargeNeeded)
            {
                SuperCharge();
            }
            else if (chargeTime < chargeNeeded) 
            {
                Timedecay = decay;
                isCharging = false;
                chargeTime = 0f;
            }
        }

    }

    private void SuperCharge()
    {
        PlayerBulletScript newSuperBullet = Instantiate(m_superBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newSuperBullet.Shoot(m_enemy.transform.position);
        isCharging = false;
        chargeTime = 0f;
        Timedecay = decay;
    }
    IEnumerator Spawner()
    {
        PlayerBulletScript newBullet = Instantiate(m_bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Spawn les balles par rapport au spawn point
        newBullet.Shoot(m_enemy.transform.position); // Target la position de l'ennemi
        yield return new WaitForSeconds(spawnCoroutineSecondRate);
        StartCoroutine(Spawner());
    }
}
