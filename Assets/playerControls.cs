using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;     // Move tank para esquerda
    public KeyCode moveRight = KeyCode.D;    // Move tank para direita
    public float speed = 10.0f;             // Define a velocidade do tank
    public Rigidbody2D rb2d;                // Define Rigidbody2D que representa o tank
    public int limiteLeft = -6;        // Limite esquerdo do tank
    public int limiteRight = 5;        // Limite direito do tank
    
    public GameObject bulletPrefab;         // Prefab do disparo
    public Transform firePoint;             // Ponto de disparo
    public float bulletSpeed = 10.0f;       // Velocidade do disparo
    public KeyCode fireKey = KeyCode.Space; // Dispara no espaço

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa o tank
    }

    // Update is called once per frame
    void Update()
    {
        
        var vel = rb2d.velocity;   // Pega a velocidade atual do tank
        if (Input.GetKey(moveLeft)) {
            vel.x = -speed;       // Move o tank para esquerda
        }
        else if (Input.GetKey(moveRight)) {
            vel.x = speed;        // Move o tank para direita
        }
        else {
            vel.x = 0;            // Para o tank
        }
        rb2d.velocity = vel;    // Att a velocidade do tank

        if (Input.GetKeyDown(fireKey)) {
            Shoot();            // Dispara
        }

        var pos = transform.position; // Acessa a posicao do tank
        if (pos.x < limiteLeft) {
            pos.x = limiteLeft;         // Limite esquerdo
        }
        else if (pos.x > limiteRight) {
            pos.x = limiteRight;          // Limite direito
        }
        transform.position = pos;    // Att a posicao do tank
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Cria o disparo
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Pega o Rigidbody do disparo
        rb.velocity = firePoint.up * bulletSpeed; // Define a velocidade do disparo
    }
}
