using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PulsarObjeto2 : MonoBehaviour
{
    public string sceneName;
    public Canvas canvasSuperposicion4;
    
   

    public void OnMouseOver() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion4.gameObject.SetActive(true);
    }
    public void OnMouseExit()
    {
        canvasSuperposicion4.gameObject.SetActive(false);
    }

    public void Popular() //Permite Superponer dentro de la misma escena
    {
        canvasSuperposicion4.gameObject.SetActive(true);
    }

  


}