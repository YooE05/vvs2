using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHealth;
    [SerializeField] Collider meshCollider;
    [SerializeField] ParticleSystem hitFXPrefab;
    [SerializeField] ParticleSystem dieFXPrefab;

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other) //чё за other
    {
        enemyHealth--;
        hitFXPrefab.Play();
        if (enemyHealth < 0)
        {
            var dieFX = Instantiate(dieFXPrefab, transform.position, Quaternion.identity);
            dieFX.Play();
            Destroy(gameObject);
        }
    }
}
