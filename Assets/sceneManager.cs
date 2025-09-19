using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private bool sceneChanged = false;

    void Update()
    {
        if (sceneChanged) return;
        
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Quantidade de inimigos: " + gos.Length);
        
        if (gos.Length == 0)
        {
            Debug.Log("todos eliminados da cena");
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}