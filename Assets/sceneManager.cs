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

        // Verificações de transição de cena (compatível com chamadas antigas)
        if (scene.name == "Level1")
        {
            // Se quiser manter a chamada estática antiga:
            sceneManager.LoadScene("Level2");
        }
        if (scene.name == "Level2" || gos.Length == 0)
        {
            sceneManager.LoadScene("Vitoria");
        }

        // Não use variável 'vidas' local — acesse via gameManager.instance
        if (gameManager.instance != null && gameManager.instance.vidas == 0)
        {
            sceneManager.LoadScene("Derrota");
        }
    }

    // Método estático para compatibilidade com chamadas antigas do seu código:
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Se quiser, métodos de instância adicionais:
    public void LoadDerrota()
    {
        LoadScene("Derrota");
    }

    public void LoadVitoria()
    {
        LoadScene("Vitoria");
    }

    public void LoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            SceneManager.LoadScene(0);
    }
}
