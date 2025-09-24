using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int vidas = 3;
    public Text vidasText;
    public float alienBulletDelay = 2.0f;
    private float alienBulletTimer;
    public int totalAliens;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalAliens = Object.FindObjectsByType<AlienManager>(FindObjectsSortMode.None).Length;
        UpdateLivesDisplay();
        alienBulletTimer = alienBulletDelay;
    }

    // Update is called once per frame
    void Update()
    {
        alienBulletTimer -= Time.deltaTime;
        if (alienBulletTimer <= 0)
        {
            ShootAlienBullet();
            alienBulletTimer = alienBulletDelay;
        }
    }

    public void PerderVidas()
    {
        vidas--;
        UpdateLivesDisplay();

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesDisplay()
    {
        if (vidasText != null)
        {
        vidasText.text = "Vidas: " + vidas;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Carrega a cena de derrota que você acabou de criar
        sceneManager.LoadScene("Derrota");
    }

    public void ShootAlienBullet()
    {
        AlienManager[] alienManagers = Object.FindObjectsByType<AlienManager>(FindObjectsSortMode.None);
        if (alienManagers.Length > 0)
        {
            AlienManager randomManager = alienManagers[Random.Range(0, alienManagers.Length)];
            if (randomManager.aliens.Count > 0)
            {
                int randomIndex = Random.Range(0, randomManager.aliens.Count);
                alienControl randomAlien = randomManager.aliens[randomIndex];
                randomAlien.alienBullet();
            }
        }
    }
}
