using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    public float health = 100;
    public float shotCounter;
    public float minTimeBetweenShots = 0.2f;
    public float maxTimeBetweenShots = 3f;

    [Header("Audio Source")]
    public AudioSource audioSource;
    public AudioClip shootSound;
    [Range(0, 1)]
    public float shootSoundVolume = 0.5f;

    public GameObject EnemyLaser;
    public GameObject HitFX;

    [Header("Shooting Angles")]
    public Vector2 leftShotDirection = new Vector2(-1, -1); // Hacia el costado izquierdo
    public Vector2 rightShotDirection = new Vector2(1, -1); // Hacia el costado derecho
    public Vector2 downShotDirection = new Vector2(0, -1);  // Hacia abajo (ya existente)

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CountDownToShoot();
    }

    private void CountDownToShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // Disparo hacia abajo
        DispararEnDireccion(downShotDirection);

        // Disparo hacia el costado izquierdo
        DispararEnDireccion(leftShotDirection);

        // Disparo hacia el costado derecho
        DispararEnDireccion(rightShotDirection);
    }

    private void DispararEnDireccion(Vector2 direccion)
    {
        GameObject laser = Instantiate(EnemyLaser);
        if (laser != null)
        {
            laser.transform.position = transform.position; // Inicia desde la posición del enemigo
            laser.transform.rotation = Quaternion.identity; // Sin rotación inicial
            laser.SetActive(true);

            // Asignar velocidad o dirección al proyectil
            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direccion.normalized * 5f; // Ajustar velocidad
            }

            // Reproducir sonido de disparo
            audioSource.PlayOneShot(shootSound, shootSoundVolume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (damageDealer)
        {
            TakeDamage(damageDealer.GetDamage());

            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject explosionFX = Instantiate(HitFX);
            if (explosionFX)
            {
                explosionFX.transform.position = transform.position;
                explosionFX.transform.rotation = Quaternion.identity;
                explosionFX.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
