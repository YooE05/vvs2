using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyHealth;
    public float damageByBullet =1;
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
        GetComponent<AudioSource>().PlayOneShot(sfxHit, 0.05f*FindObjectOfType<DataController>().volume);
        enemyHealth-= damageByBullet;
        hitFXPrefab.Play();
        if (enemyHealth < 0)
        {
            AudioSource.PlayClipAtPoint(sfxDie, Camera.main.transform.position, 0.25f * FindObjectOfType<DataController>().volume);
            var dieFX = Instantiate(dieFXPrefab, transform.position, Quaternion.identity);
            dieFX.Play();
            Destroy(gameObject);
            FindObjectOfType<GameController>().defeatEnemies++;
        }
    }
}
