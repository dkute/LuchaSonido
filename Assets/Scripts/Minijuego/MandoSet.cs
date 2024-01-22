using System.Collections;
using UnityEngine;
public class MandoSet : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] notes;
    private AudioSource audioSrc;

    private void Start()
    {
        NoteButton.NoteClicked += PlaySound;
        audioSrc = GetComponent<AudioSource>();
    }

    private void PlaySound(string noteName)
    {
        switch (noteName)
        {
            case "A":
                audioSrc.PlayOneShot(notes[0]);
                break;
            case "B":
                audioSrc.PlayOneShot(notes[1]);
                break;
            case "C":
                audioSrc.PlayOneShot(notes[2]);
                break;
            case "D":
                audioSrc.PlayOneShot(notes[3]);
                break;
            case "E":
                audioSrc.PlayOneShot(notes[4]);
                break;
            case "F":
                audioSrc.PlayOneShot(notes[5]);
                break;
            case "G":
                audioSrc.PlayOneShot(notes[6]);
                break;
        }
    }
}
