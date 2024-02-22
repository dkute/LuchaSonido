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
    public  GameObject  canvasSuperposicion;

    public Button A;
    public Button B;
    public Button C;
    public Button D;
    public Button E;
    public Button F;
    public Button G;

    private int notasResponder = 1; //numero de notas que el jugador debe responder
    private int notasRespondidas = 0; //notas que el jugador ha respondido
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
        secuenciaNotas.Add(Random.Range(0, notas.Length));
        while (true)
        {
            canvasSuperposicion.SetActive(false);
            secuenciaJugador.Clear();
            notasRespondidas = 0;
            notasResponder = secuenciaNotas.Count + 1;

            // Agrega una nueva nota aleatoria a la secuencia
            //int nuevaNota = Random.Range(0, notas.Length);
            //secuenciaNotas.Add(nuevaNota);

            //condicional para que sepa cuantas notas etc

            // Reproduce la secuencia actual de notas
            yield return ReproducirSecuencia();

            jugadorTurno = true; // Es el turno del jugador
            //yield return new WaitUntil(1f); // Retardo antes de que el jugador pueda comenzar a replicar la secuencia
            //yield return new WaitUntil(() => indexSecuencia >= secuenciaNotas.Count); // Espera a que el jugador complete la secuencia
            jugadorTurno = true;
            yield return new WaitUntil(() => notasRespondidas >= notasResponder);

            

            if (!ComprobarSecuencia())
            {
                Debug.Log("Has cometido un error Repitiendo secuencia!...");
                secuenciaNotas.Clear();
                indexSecuencia = 0;
                canvasSuperposicion.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                // Avanza al siguiente nivel si el jugador ha respondido correctamente todas las notas
                indexSecuencia = 0;
                secuenciaNotas.Add(Random.Range(0, notas.Length));
            }

             //Reinicia el índice para la siguiente ronda
            //indexSecuencia = 0;

            jugadorTurno = false; // La secuencia se está reproduciendo nuevamente
        }
    }

    IEnumerator ReproducirSecuencia()
    {
        foreach (int nota in secuenciaNotas)
        {
            
            ReproducirNota(nota); //repr
            yield return new WaitForSeconds(1.5f); // Retardo entre notas
        }
    }
  

    void ReproducirNota(int indice)
    {
        // Reproduce el sonido de la nota en el índice especificado
        AudioSource.PlayClipAtPoint(notas[indice], transform.position);
    }

   
    bool ComprobarSecuencia()
    {
        for (int i = 0; i < secuenciaNotas.Count; i++)
        {
            if (secuenciaNotas[i] != secuenciaJugador[i])
            {
                //canvasSuperposicion.SetActive(true);
               return false;
            }
        }
       return true;
        
    }

    public void NotaPresionada(int indice)
    {
        if (jugadorTurno)
        {
            secuenciaJugador.Add(indice);
            notasRespondidas++;
            // Comprueba si la nota presionada por el jugador coincide con la siguiente nota en la secuencia
            //if (indice == secuenciaNotas[indexSecuencia])
            if (notasRespondidas >= notasResponder)
            {
                //indexSecuencia++; // Avanza al siguiente índice en la secuencia
                //if(indexSecuencia >= secuenciaNotas.Count)
                if (!ComprobarSecuencia())
                {
                    canvasSuperposicion.SetActive(true);
                    Debug.Log("¡Has perdido! Intenta de nuevo.");
                    secuenciaNotas.Clear();
                    StartCoroutine(ReproducirSecuencia());
                }
                
                    //StartCoroutine(IniciarSecuencia());
                
            }
            
            //else
            {
               
                //canvasSuperposicion.SetActive(true);
                // El jugador cometió un error, puedes agregar aquí la lógica para manejarlo
               // Debug.Log("¡Has perdido! Intenta de nuevo.");
                //secuenciaNotas.Clear(); // Reinicia la secuencia para comenzar de nuevo
                //StartCoroutine(ReproducirSecuencia()); // Reinicia el juego //mirarlo
            }
            
        }
    }
}

