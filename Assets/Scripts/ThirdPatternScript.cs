using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPatternScript : MonoBehaviour
{
    public int hitPoint;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("cc");
            PlayerStats.Instance.Death(hitPoint);
        }
    }
}
