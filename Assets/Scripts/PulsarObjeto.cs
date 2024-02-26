using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PulsarObjeto : MonoBehaviour
{
    public string sceneName;
    public string sceneName2;
    public Canvas canvasSuperposicion;
    public Canvas canvasSuperposicion2;
    public Canvas canvasSuperposicion3;

    public void cambiarScene()
    {
        SceneManager.LoadScene(sceneName);
        
    }
    public void cambiarScene2()
    {
        SceneManager.LoadScene(sceneName2);

    }

    public void canvasEnergia()
    {
        canvasSuperposicion.gameObject.SetActive(true);
    }
    public void canvasVolver()
    {
        canvasSuperposicion.gameObject.SetActive(false);
        canvasSuperposicion2.gameObject.SetActive(false);
        canvasSuperposicion3.gameObject.SetActive(false);
    }

    public void canvasInventario()
    {
        canvasSuperposicion2.gameObject.SetActive(true);
    }
    public void canvasAjustes()
    {
        canvasSuperposicion3.gameObject.SetActive(true);
    }
    private void OnMouseOver()
    {
        canvasSuperposicion.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        canvasSuperposicion.gameObject.SetActive(false);
    }
}




