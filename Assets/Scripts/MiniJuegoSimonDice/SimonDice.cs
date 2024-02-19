using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonDice : MonoBehaviour
{
    public AudioClip[] notas; // Array que contiene los sonidos de las notas
    private List<int> secuenciaNotas = new List<int>(); // Lista para almacenar la secuencia de notas generada aleatoriamente
    private int indexSecuencia = 0; // Índice para rastrear la posición actual en la secuencia de notas
    private bool jugadorTurno = false; // Variable para rastrear si es el turno del jugador
    private List<int> secuenciaJugador = new List<int>();
    public GameObject canvasSuperposicion;

    public Button A;
    public Button B;
    public Button C;
    public Button D;
    public Button E;
    public Button F;
    public Button G;
    void Start()
    {
        canvasSuperposicion.SetActive(false);
        // Inicia el juego
        StartCoroutine(IniciarSecuencia());
        A.onClick.AddListener(() => NotaPresionada(0));
        A.onClick.AddListener(() => NotaPresionada(1));
        B.onClick.AddListener(() => NotaPresionada(2));
        C.onClick.AddListener(() => NotaPresionada(3));
        D.onClick.AddListener(() => NotaPresionada(4));
        E.onClick.AddListener(() => NotaPresionada(5));
        F.onClick.AddListener(() => NotaPresionada(6));
        G.onClick.AddListener(() => NotaPresionada(7));

    }

    IEnumerator IniciarSecuencia()
    {
        yield return new WaitForSeconds(1f); // Retardo inicial antes de iniciar la secuencia

        while (true)
        {
            // Agrega una nueva nota aleatoria a la secuencia
            int nuevaNota = Random.Range(0, notas.Length);
            secuenciaNotas.Add(nuevaNota);

            // Reproduce la secuencia actual de notas
            foreach (int nota in secuenciaNotas)
            {
                ReproducirNota(nota);
                yield return new WaitForSeconds(1.5f); // Retardo entre notas
            }

            jugadorTurno = true; // Es el turno del jugador
            yield return new WaitForSeconds(1f); // Retardo antes de que el jugador pueda comenzar a replicar la secuencia
            yield return new WaitUntil(() => indexSecuencia >= secuenciaNotas.Count); // Espera a que el jugador complete la secuencia
            //if (!ComprobarSecuencia())
            //{
               // Debug.Log("Has cometido un error Repitiendo secuencia!...");
               // secuenciaNotas.Clear();
                //indexSecuencia = 0;
               // yield return new WaitForSeconds(1f);
            //}

            // Reinicia el índice para la siguiente ronda
            //indexSecuencia = 0;

            //jugadorTurno = false; // La secuencia se está reproduciendo nuevamente
        }
    }

    void ReproducirNota(int indice)
    {
        // Reproduce el sonido de la nota en el índice especificado
        AudioSource.PlayClipAtPoint(notas[indice], transform.position);
    }

    //bool ComprobarSecuencia()
    //{
        //for (int i = 0; i < secuenciaNotas.Count; i++)
        //{
            //if (secuenciaNotas[i] != secuenciaJugador[i])
            //{
               // canvasSuperposicion.SetActive(true);
                //return false;
            //}
        //}
        //return true;
        
    //}

    public void NotaPresionada(int indice)
    {
        if (jugadorTurno)
        {
            // Comprueba si la nota presionada por el jugador coincide con la siguiente nota en la secuencia
            if (indice == secuenciaNotas[indexSecuencia])
            {
                indexSecuencia++; // Avanza al siguiente índice en la secuencia
                if(indexSecuencia >= secuenciaNotas.Count)
                {
                    StartCoroutine(IniciarSecuencia());
                }
            }
            
            else
            {
               
                canvasSuperposicion.SetActive(true);
                // El jugador cometió un error, puedes agregar aquí la lógica para manejarlo
                //Debug.Log("¡Has perdido! Intenta de nuevo.");
                secuenciaNotas.Clear(); // Reinicia la secuencia para comenzar de nuevo
                StartCoroutine(IniciarSecuencia()); // Reinicia el juego
            }
            
        }
    }
}

