using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //  https://www.youtube.com/watch?v=0VGosgaoTsw

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    void Update()
    {
       
                Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f); //Le temps va être entre 0 et 1 maximum pour eviter de speed le jeu au dessus de 1
    }
    public void Slowmotion() // add delay / coroutine bcs we can spam it
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }
}
