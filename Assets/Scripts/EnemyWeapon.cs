using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyWeapon : MonoBehaviour
{

    [Header("Pattern Manager")]
    private int randPattern;
    public int secondPattern;

    [Header("Bullet Attributes")]
    [SerializeField] private EnemyBullet m_enemybullet;
    public float speed = 1f;
    private float timer = 0f;


    [Header("Hell Manager")]
    public int spinSpeed;
    public float firingHellRate = 1f;
    public bool isSpinHellActive = false;

    private float decaySpin = 0f;
    private bool spinSwitch = false;

    [Header("Heaven Manager")]
    public int spinSpeedHeaven;
    public float firingRate = 1f;
    public bool isSpinHeavenActive = false;

    private float decaySpinHeaven = 0f;
    private bool spinSwitchHeaven = false;



    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(RandomCheck());
    }
    void Update()
    {
        

        if (randPattern == 0)
        {
            
            SpinHellPatern();
        }
        else { }

        if (randPattern == 1)
        {
            
            SpinHeavenPatern();
        }
        else { }
        
    }

    private IEnumerator RandomCheck()
    {
        print(randPattern);
        randPattern = Random.Range(0, 2);
        yield return new WaitForSeconds(secondPattern);
        StartCoroutine(RandomCheck());
    }
    private void SpinHellPatern()
    {
        timer += Time.deltaTime;
        if (decaySpin >= 0f && spinSwitch == false)
        {
            decaySpin += Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z + spinSpeed);
            if (decaySpin >= 5f)
            {
                spinSwitch = true;
            }
        }

        if (spinSwitch == true)
        {
            decaySpin += Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z - spinSpeed);
            if (decaySpin >= 10f)
            {
                spinSwitch = false;
                decaySpin = 0f;
            }
        }

        if (timer >= firingHellRate)
        {
            Fire();
            timer = 0;
        }
    }
    private void SpinHeavenPatern()
    {
            timer += Time.deltaTime;
            if (decaySpinHeaven >= 0f && spinSwitchHeaven == false)
            {
            decaySpinHeaven += Time.deltaTime;
                transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z + spinSpeed);
                if (decaySpinHeaven >= 5f)
                {
                spinSwitchHeaven = true;
                }
            }

            if (spinSwitchHeaven == true)
            {
            decaySpinHeaven += Time.deltaTime;
                transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z - spinSpeed);
                if (decaySpinHeaven >= 10f)
                {
                spinSwitchHeaven = false;
                decaySpinHeaven = 0f;
                }
            }

            if (timer >= firingRate)
            {
                Fire2();
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
    private void Fire2()
    {
        if (m_enemybullet)
        {
            EnemyBullet newenemyBullet = Instantiate(m_enemybullet, transform.position, transform.rotation);
            newenemyBullet.GetComponent<EnemyBullet>().bulletSpeed = speed;
            newenemyBullet.transform.rotation = transform.rotation;
        }
    }
}
    
