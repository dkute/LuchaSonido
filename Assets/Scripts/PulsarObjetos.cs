using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PulsarObjetos : MonoBehaviour
{
    public string sceneName;
    public Canvas canvasSuperposicion;
    public void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnMouseOver()
    {
        canvasSuperposicion.gameObject.SetActive(true);
    }
}