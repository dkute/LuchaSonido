using UnityEngine;
using System;

public class NoteButton : MonoBehaviour
{
    public static event Action<string> NoteClicked = delegate { };

    private void OnMouseDown()
    {
        NoteClicked(name);
    }
}
