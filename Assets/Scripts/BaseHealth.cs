using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int health = 5;
    [SerializeField] int damageByHit = 1;

    [SerializeField] Text healthText;

    [SerializeField] AudioClip sfxBaseAtack;


    void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        health -= damageByHit;
        FindObjectOfType<GameController>().defetEnemies++;
        GetComponent<AudioSource>().PlayOneShot(sfxBaseAtack, 0.5f);
        healthText.text = health.ToString();
    }

}
