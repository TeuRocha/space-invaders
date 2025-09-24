using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienControl : MonoBehaviour
{

    public float speed = 2.0f;
    public LayerMask obstacleMask; // Máscara para detectar obstáculos
    private Rigidbody2D rb2d; // Rigidbody2D do alien
    private AlienManager manager;
    private Rigidbody2D rb;

    public GameObject bulletPrefab; // Prefab do disparo do alien
    public Transform firePoint; // Ponto de disparo do alien
    public float bulletSpeed = 5.0f; // Velocidade do disparo do alien
    public float fireDelay = 2.0f; // Delay entre disparos
    private float fireTimer = 0.0f; // Timer para controlar o delay entre disparos
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o Rigidbody2D
        
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed); // Faz o tiro se mover para baixo

        manager = Object.FindAnyObjectByType<AlienManager>();
        manager.aliens.Add(this);

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {

        // Verifica colisão à frente
        Vector2 origin = transform.position + new Vector3(rb2d.velocity.x > 0 ? 0.5f : -0.5f, 0, 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right * Mathf.Sign(rb2d.velocity.x), 0.1f, obstacleMask);

        if (hit.collider != null) {
            manager.ChangeDirectionForAll();
        }

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireDelay) {
            Shoot();
            fireTimer = 0.0f;
        }
    }

    void OnDestroy()
    {
        if (manager != null && manager.aliens.Contains(this)) {
            manager.aliens.Remove(this);
        }
    }


    public void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void Shoot()
    {
        GameObject alienBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Cria o disparo
        Rigidbody2D rb2d = alienBullet.GetComponent<Rigidbody2D>(); // Pega o Rigidbody do disparo
        rb2d.velocity = -firePoint.up * bulletSpeed; // Define a velocidade do disparo para baixo
    }
}
