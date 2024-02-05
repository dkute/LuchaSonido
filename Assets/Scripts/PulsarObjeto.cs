using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PulsarObjeto : MonoBehaviour
{
    public string sceneName;
    public Canvas canvasSuperposicion;
    public Canvas canvasSuperposicion2;


    public void Anuncios ()
    {
        canvasSuperposicion.gameObject.SetActive(true);
        
    }
    public void BotonPlay()//Permite cambiar de escena
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnMouseOver() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion.gameObject.SetActive(true);
    }
    public void OnMouseExit()
    {
        canvasSuperposicion.gameObject.SetActive(false);
    }

    public void ajustes() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion.gameObject.SetActive(true);
    }
    public void Inventario() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion2.gameObject.SetActive(true);
    }
}



