using System.Collections;
using UnityEngine;
public class MandoSet : MonoBehaviour
{
    [SerializeField]
    static public AudioClip[] notes;
    static public AudioSource audioSrc;

    private void Start()
    {
        NoteButton.NoteClicked += PlaySound;
        audioSrc = GetComponent<AudioSource>();
    }

    private static void PlaySound(string noteName)
    {
        switch (noteName)
        {
            case "A":
                A();
                break;
            case "B":
                B();
                break;
            case "C":
                C();
                break;
            case "D":
                D();
                break;
            case "E":
                E();
                break;
            case "F":
                F();
                break;
            case "G":
                G();
                break;
        }
    }

    private static void G()
    {
        audioSrc.PlayOneShot(notes[6]);
    }

    private static void F()
    {
        audioSrc.PlayOneShot(notes[5]);
    }

    private static void E()
    {
        audioSrc.PlayOneShot(notes[4]);
    }

    private static void D()
    {
        audioSrc.PlayOneShot(notes[3]);
    }

    private static void C()
    {
        audioSrc.PlayOneShot(notes[2]);
    }

    private static void B()
    {
        audioSrc.PlayOneShot(notes[1]);
    }

    static public void A()
    {
        audioSrc.PlayOneShot(notes[0]);
    }
}
