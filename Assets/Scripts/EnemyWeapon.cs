using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyWeapon : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    [SerializeField] private EnemyBullet m_enemybullet;
    public float speed = 1f;
    private float timer = 0f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    [Header("Decay manager")]
    private float decay = 0f;
    private bool spinSwitch = false;


    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Debug.Log(decay);
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin && decay >= 0f && spinSwitch == false)
        {
            decay += Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z + 1f);
            if (decay >= 5f ) 
            {
                spinSwitch = true;
            }
        }

        if (spawnerType == SpawnerType.Spin && spinSwitch == true )
        {
            decay += Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z - 1f);
            if (decay >= 10f )
            {
                spinSwitch = false;
                decay = 0f;
            }
        }

        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }
    private void Fire()
    {
        if (m_enemybullet)
        {
            EnemyBullet newenemyBullet = Instantiate(m_enemybullet, transform.position, transform.rotation);
            newenemyBullet.GetComponent<EnemyBullet>().bulletSpeed = speed;
            newenemyBullet.transform.rotation = transform.rotation;
        }
    }
}
    
