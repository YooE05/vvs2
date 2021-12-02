using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] float damageByBullet =1;
    [SerializeField] Collider meshCollider;
    [SerializeField] ParticleSystem hitFXPrefab;
    [SerializeField] ParticleSystem dieFXPrefab;

    [SerializeField] AudioClip sfxHit;
    [SerializeField] AudioClip sfxDie;
    //public int baseDamage = 5;

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other) 
    {
        GetComponent<AudioSource>().PlayOneShot(sfxHit, 0.1f);
        enemyHealth-= damageByBullet;
        hitFXPrefab.Play();
        if (enemyHealth < 0)
        {
            AudioSource.PlayClipAtPoint(sfxDie, Camera.main.transform.position, 0.5f);
            var dieFX = Instantiate(dieFXPrefab, transform.position, Quaternion.identity);
            dieFX.Play();
            Destroy(gameObject);
            FindObjectOfType<GameController>().defeatEnemies++;
        }
    }
}
