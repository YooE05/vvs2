using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHealth;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] Collider meshCollider;

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other) //чё за other
    {
        enemyHealth--;
        hitFX.Play();
        if (enemyHealth < 0)
        { Destroy(gameObject); }
    }
}
