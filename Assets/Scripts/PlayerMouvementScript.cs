using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMouvementScript : MonoBehaviour
{

    [SerializeField] Transform[] Pattern;
    private int pointsIndex;

    public float speed;

    private bool isSwitched = false;

    private void Start()
    {
        transform.position = Pattern[pointsIndex].transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Pattern[pointsIndex].transform.position, speed * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            isSwitched = !isSwitched;
        }

        if (transform.position == Pattern[pointsIndex].transform.position && isSwitched == false)
        {
            pointsIndex++;
        }
        else if (transform.position == Pattern[pointsIndex].transform.position)
        {
            pointsIndex--;
            if (pointsIndex == -1)
            {
                pointsIndex = 3;
            }
        }
        if (pointsIndex == Pattern.Length)
        {
            pointsIndex = 0;
        }
    }

}

