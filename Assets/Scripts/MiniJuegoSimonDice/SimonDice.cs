using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimonDice : MonoBehaviour
{
    public AudioClip[] notas;
    private List<int> secuenciaNotas = new List<int>();
    private int indexSecuencia = 0;
    private bool jugadorTurno = false;
    private List<int> secuenciaJugador = new List<int>();
    public GameObject canvasInicio;
    public GameObject canvasSuperposicion;
    public GameObject canvasVictoria;
    public GameObject canvasDerrota;
    public TMP_Text puntuacionText;
    public TMP_Text aciertosText;
    public TMP_Text fallosText;
    public Button A;
    public Button B;
    public Button C;
    public Button D;
    public Button E;
    public Button F;
    public Button G;

    private int notasResponder = 1;
    private int notasRespondidas = 0;
    private int intentos = 0;
    private int fallos = 0;

    void Start()
    {
        canvasSuperposicion.SetActive(false);
        canvasVictoria.SetActive(false);
        canvasDerrota.SetActive(false);
        canvasInicio.SetActive(true);

        A.onClick.AddListener(() => NotaPresionada(0));
        B.onClick.AddListener(() => NotaPresionada(1));
        C.onClick.AddListener(() => NotaPresionada(2));
        D.onClick.AddListener(() => NotaPresionada(3));
        E.onClick.AddListener(() => NotaPresionada(4));
        F.onClick.AddListener(() => NotaPresionada(5));
        G.onClick.AddListener(() => NotaPresionada(6));
    }

    public void IniciarJuego()
    {
        canvasInicio.SetActive(false);
        StartCoroutine(RealizarJuego());
    }

    IEnumerator RealizarJuego()
    {
        // Reproducir la primera nota antes de entrar en el bucle de juego
        ReproducirNota(Random.Range(0, notas.Length));
        yield return new WaitForSeconds(1f); // Puedes ajustar el tiempo según sea necesario

        while (intentos < 3 && fallos < 3)
        {
            canvasSuperposicion.SetActive(false);
            secuenciaJugador.Clear();
            notasRespondidas = 0;
            notasResponder = secuenciaNotas.Count + 1;

            yield return ReproducirSecuencia();

            jugadorTurno = true;
            yield return new WaitUntil(() => notasRespondidas >= notasResponder);

            if (!ComprobarSecuencia())
            {
                fallos++;
                fallosText.text = "Fallos: " + fallos.ToString();
                MostrarMensajeSuperposicion("Vuelve a intentar");
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                indexSecuencia = 0;
                secuenciaNotas.Add(Random.Range(0, notas.Length));
                yield return new WaitForSeconds(1f);
            }

            jugadorTurno = false;
            canvasSuperposicion.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            canvasSuperposicion.SetActive(false);
        }

        if (intentos >= 3 || fallos >= 3)
        {
            canvasDerrota.SetActive(true);
            Debug.Log("Juego terminado. Has alcanzado el límite de intentos. ¡Intenta de nuevo!");
        }
        else
        {
            canvasVictoria.SetActive(true);
            puntuacionText.text = "Tu puntuación: " + secuenciaNotas.Count.ToString();
            Debug.Log("¡Has ganado! Completaste la secuencia.");
        }
    }

    IEnumerator ReproducirSecuencia()
    {
        foreach (int nota in secuenciaNotas)
        {
            yield return new WaitForSeconds(0.5f);
            ReproducirNota(nota);
        }
    }

    void ReproducirNota(int indice)
    {
        AudioSource.PlayClipAtPoint(notas[indice], transform.position);
    }

    bool ComprobarSecuencia()
    {
        for (int i = 0; i < secuenciaNotas.Count; i++)
        {
            if (secuenciaNotas[i] != secuenciaJugador[i])
            {
                fallosText.text = "Fallos: " + fallos.ToString();
                return false;
            }
        }

        aciertosText.text = "Aciertos: " + secuenciaNotas.Count.ToString();
        return true;
    }

    public void NotaPresionada(int indice)
    {
        if (jugadorTurno)
        {
            ReproducirNota(indice);
            secuenciaJugador.Add(indice);
            notasRespondidas++;

            if (notasRespondidas >= notasResponder)
            {
                if (!ComprobarSecuencia())
                {
                    fallos++;
                    fallosText.text = "Fallos: " + fallos.ToString();
                    secuenciaNotas.Clear();
                    StartCoroutine(ReproducirSecuencia());
                }
            }
        }
    }

    void MostrarMensajeSuperposicion(string mensaje)
    {
        // Implementa la lógica para mostrar el mensaje en tu canvas de superposición
        // Puedes acceder a los elementos de texto o imágenes de tu canvas y actualizarlos según sea necesario
    }
}