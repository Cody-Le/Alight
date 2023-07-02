using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Focused_Locker : MonoBehaviour
{
    public GameEvent onSubtitle;
    public PlayableDirector door;


    private void Start()
    {
        onSubtitle.Raise(this, "[E] to open locker");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.Play();
        }
    }





}
