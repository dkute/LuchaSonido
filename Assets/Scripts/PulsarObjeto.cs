using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PulsarObjeto : MonoBehaviour
{
    public string sceneName;
    public Canvas canvasSuperposicion;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
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



