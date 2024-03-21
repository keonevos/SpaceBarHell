using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMouvementSpline : MonoBehaviour
{
    public SplineContainer spline;
    public float speed = 1f;
    float distancePercentage = 0f;

    float splineLength;

    private bool isSwitched = false;
    private void Start()
    {
        splineLength = spline.CalculateLength();
        isSwitched = false;
    }

    // Update is called once per frame
    void Update()
    {
        distancePercentage += speed * Time.deltaTime / splineLength;

        Debug.Log(distancePercentage);
        Debug.Log(splineLength);
        if (isSwitched == false && Input.GetKeyDown("space")) 
        {
            isSwitched = true;
            speed = -speed;
            Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
            transform.position = currentPosition;
        }

        if (isSwitched == true && distancePercentage < 0.05f)
            {
                distancePercentage = 1f;

            }
        if (isSwitched == true && Input.GetKeyDown("space"))
        {
            isSwitched= false;
        }
        else
        {

            Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
            transform.position = currentPosition;

            if (distancePercentage > 1f)
            {
                distancePercentage = 0f;
            }
        }
    }


}
