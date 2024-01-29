using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Cambio de escena
    }
    public void Salida()
    {
        Application.Quit(); // Salimos de la aplicacion
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Salimos de la aplicacion
        }
    }
}
