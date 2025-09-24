using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class alienBullet : MonoBehaviour
{

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wall")) {
            gameManager.instance.PerderVidas();
            Destroy(gameObject); // Destrói o disparo ao colidir com inimigo ou parede
        }

    }
}