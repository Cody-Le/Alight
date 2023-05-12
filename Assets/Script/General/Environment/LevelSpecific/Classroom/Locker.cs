using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Playables;

public class Locker : MonoBehaviour
{
    bool isOpen;
    public PlayableDirector animator;

    private void Start()
    {
        isOpen = false;

    }


    private void Update()
    {
        if(!isOpen && Input.GetKeyDown(KeyCode.E))
        {
            animator.Play();
        }
    }
}
