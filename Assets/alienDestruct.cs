using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) {
            Destroy(gameObject); // Destrói o alien ao ser atingido por um disparo
        }
    }

}
