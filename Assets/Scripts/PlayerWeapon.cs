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
    private float targetOtrhographicSize;
    private float cameraSizeSmoothness;

    [Header("Audio")]
    public GameObject m_bulletAudio;
    public GameObject m_superBulletAudio;
    private AudioSource supershootAudio;
    private AudioSource shootAudio;
    private bool isShooting = false;

    private void Awake()
    {
        StartCoroutine(Spawner());
        targetOtrhographicSize = 5;
        cameraSizeSmoothness = 1;
    }

    private void Start()
    {
        shootAudio = m_bulletAudio.GetComponentInChildren<AudioSource>();
        supershootAudio = m_superBulletAudio.GetComponentInChildren<AudioSource>();
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
               targetOtrhographicSize = 3;
               TimeManager.Slowmotion();
               chargeTime += chargeSpeed * Time.deltaTime;
               m_camera.orthographicSize = Mathf.Lerp(m_camera.orthographicSize, targetOtrhographicSize, cameraSizeSmoothness * Time.deltaTime);
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
                m_camera.orthographicSize = 5;
            }
        }

        if (isShooting == true) 
        {
            shootAudio.Play();
            isShooting = !isShooting;
        }

    }

    private void SuperCharge()
    {
        PlayerBulletScript newSuperBullet = Instantiate(m_superBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newSuperBullet.Shoot(m_enemy.transform.position);
        supershootAudio.Play();
        isCharging = false;
        chargeTime = 0f;
        Timedecay = decay;
        m_camera.orthographicSize = 5;
    }
    IEnumerator Spawner()
    {
        isShooting = true;
        PlayerBulletScript newBullet = Instantiate(m_bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Spawn les balles par rapport au spawn point
        newBullet.Shoot(m_enemy.transform.position); // Target la position de l'ennemi
        yield return new WaitForSeconds(spawnCoroutineSecondRate);
        StartCoroutine(Spawner());
    }
}
