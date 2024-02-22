using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PulsarObjeto : MonoBehaviour
{
    public string sceneName;
    public Canvas canvasSuperposicion;
    public Canvas canvasSuperposicion2;
    public Canvas canvasSuperposicion3;
    public Canvas canvasSuperposicion4;
    public Canvas canvasSuperposicion5;


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

    public void MenuInventario() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion2.gameObject.SetActive(false);
    }

    public void MenuAjustes() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion.gameObject.SetActive(false);
    }

    public void Energia() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion.gameObject.SetActive(false);
    }

    public void Popular() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion4.gameObject.SetActive(true);
    }
    public void PopularSalida() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion5.gameObject.SetActive(false);
    }


}



