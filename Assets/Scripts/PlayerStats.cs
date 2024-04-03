using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int lifePoint;
    private int listI = 0;

    public GameObject m_hitAudio;

    public Animator m_animatorVisual;
    private AudioSource hitAudio;
    public ParticleSystem HitPlayer;

    public List<GameObject> m_lifeBar;
    public GameObject m_barList;


    private void Start()
    {       
        m_animatorVisual = gameObject.GetComponent<Animator>();
        Instance = this;
        hitAudio = m_hitAudio.GetComponentInChildren<AudioSource>();        
    }


    public void Death(int hitPoint)
    {
        
        lifePoint -= hitPoint;
        HitPlayer.Play();
        hitAudio.Play();

        m_animatorVisual.SetTrigger("isHit");

        m_lifeBar[listI].GetComponent<SpriteRenderer>().color = new Color (1f, 0.4858491f, 0.4858491f);
        listI++;
       
        if (lifePoint <= 0)
        {
            HitPlayer.Play();
            m_animatorVisual.SetTrigger("isHit");
            SceneManager.LoadScene("Start_menu");
        }
    }
}
