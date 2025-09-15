using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienControl : MonoBehaviour
{

    public float speed = 2.0f;
    public LayerMask obstacleMask; // Máscara para detectar obstáculos
    private Rigidbody2D rb2d; // Rigidbody2D do alien
    private AlienManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o Rigidbody2D
        
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
}
