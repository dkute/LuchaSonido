using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonB : MonoBehaviour
{
    public int id;
    public Animator anim;

    private void Start()
    {
        id = transform.GetSiblingIndex();
    }
    private void OnMouseDown()
    {
        if (!MinigameController.GameisWorking)
        {
            Action();
            MinigameController.Instance.PlayerAction(this);
        }
    }
    public void Action()
    {
        anim.enabled = true;
        anim.SetTrigger("pop");
    }
}
