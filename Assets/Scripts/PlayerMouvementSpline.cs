using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class PlayerMouvementSpline : MonoBehaviour
{
    public SplineContainer spline;

    public float currentSpeed = 1f;
    public float speedAcceleration = 1f;
    public float maxSpeed = 50f;

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
        currentSpeed += speedAcceleration * Time.deltaTime;

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        if (currentSpeed < -maxSpeed)
        {
            currentSpeed = -maxSpeed;
        }

        distancePercentage += currentSpeed * Time.deltaTime / splineLength;

        Debug.Log(distancePercentage);
        Debug.Log(splineLength);

        if (Input.GetKeyDown("space")) 
        {

            isSwitched = !isSwitched;
            currentSpeed = -currentSpeed;
            speedAcceleration = -speedAcceleration;
            currentSpeed += speedAcceleration * Time.deltaTime;

            Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
            transform.position = currentPosition;
        }

        if (isSwitched == true && distancePercentage < -0.001f)
        {
            distancePercentage = 1f;

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
