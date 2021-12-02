using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int startHealth = 5;
    [HideInInspector] public int health;
    [SerializeField] int damageByHit = 1;

    [SerializeField] Text healthText;

    [SerializeField] AudioClip sfxBaseAtack;


    void Awake()
    {
        health = startHealth;
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (health>0)
        {
            health -= damageByHit;
            FindObjectOfType<GameController>().defeatEnemies++;
            GetComponent<AudioSource>().PlayOneShot(sfxBaseAtack, 0.5f);
            healthText.text = health.ToString();
        }
    }

}
