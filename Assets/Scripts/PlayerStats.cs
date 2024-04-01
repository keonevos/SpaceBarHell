using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int lifePoint;

    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        Instance = this;
    }
    public void Death(int hitPoint)
    {
        lifePoint -= hitPoint;
        if (lifePoint <= 0)
        {
            SceneManager.LoadScene("Test_scene");
        }
    }
}
