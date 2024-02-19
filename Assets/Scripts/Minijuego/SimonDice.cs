using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonDice : MonoBehaviour
{
    public AudioClip[] notes; // Array que contiene los sonidos de las notas
    private List<int> secuenciaNotas = new List<int>(); // Lista para almacenar la secuencia de notas generada aleatoriamente
    private int indexSecuencia = 0; // Índice para rastrear la posición actual en la secuencia de notas
    private bool jugadorTurno = false; // Variable para rastrear si es el turno del jugador

    void Start()
    {
        // Inicia el juego
        StartCoroutine(IniciarSecuencia());
    }
   
    IEnumerator IniciarSecuencia()
    {
        yield return new WaitForSeconds(1f); // Retardo inicial antes de iniciar la secuencia

        while (true)
        {
            // Agrega una nueva nota aleatoria a la secuencia
            int nuevaNota = Random.Range(0, notes.Length);
            secuenciaNotas.Add(nuevaNota);

            // Reproduce la secuencia actual de notas
            foreach (int nota in secuenciaNotas)
            {
                ReproducirNota(nota);
                yield return new WaitForSeconds(1.5f); // Retardo entre notas
            }

            jugadorTurno = true; // Es el turno del jugador
            yield return new WaitForSeconds(1f); // Retardo antes de que el jugador pueda comenzar a replicar la secuencia
            jugadorTurno = false; // La secuencia se está reproduciendo nuevamente

            yield return new WaitUntil(() => indexSecuencia >= secuenciaNotas.Count); // Espera a que el jugador complete la secuencia

            // Reinicia el índice para la siguiente ronda
            indexSecuencia = 0;
        }
    }

    void ReproducirNota(int indice)
    {
        // Reproduce el sonido de la nota en el índice especificado
        AudioSource.PlayClipAtPoint(notes[indice], transform.position);
    }

    public void NotaPresionada(int indice)
    {
        if (jugadorTurno)
        {
            // Comprueba si la nota presionada por el jugador coincide con la siguiente nota en la secuencia
            if (indice == secuenciaNotas[indexSecuencia])
            {
                indexSecuencia++; // Avanza al siguiente índice en la secuencia
            }
            else
            {
                // El jugador cometió un error, puedes agregar aquí la lógica para manejarlo
                Debug.Log("¡Has perdido! Intenta de nuevo.");
                secuenciaNotas.Clear(); // Reinicia la secuencia para comenzar de nuevo
                StartCoroutine(IniciarSecuencia()); // Reinicia el juego
            }
        }
    }
}


