using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Audio_player : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject Player;
    Movement movementController;
    AudioSource source;

    [Header("AudioSources")]
    public AudioClip woodStep;
    public AudioClip concreteStep;
    public int audioMaterial;

    [Header("Walk Parameters")]
    public float w_offset;
    public float w_delay;

    [Header("Walk Parameters")]
    public float r_offset;
    public float r_delay;

    IEnumerator soundRoutine;
    bool isWalking;
    bool isRunning;
    bool isActive = true;

    

    void Start()
    {
        Player = this.gameObject;
        movementController = this.GetComponent<Movement>();
        source = this.GetComponent<AudioSource>();
        isWalking = false;
        isRunning = false;
        if(Player.tag != "Player")
        {
            Debug.LogError("Component Audio_player is not attached to a player gameObject");
        }

        if(audioMaterial == 0)
        {
            source.clip = woodStep;
        }
        else
        {
            source.clip = concreteStep;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            isRunning = false;
            isWalking = false;
            if (soundRoutine != null)
            {
                StopCoroutine(soundRoutine);
            }
            
        }


        if (movementController.isWalking && !isWalking)
        {
            isWalking = true;
            soundRoutine = walkRoutine();
            
            StartCoroutine(soundRoutine);
        }
        else if(!movementController.isWalking)
        {
            if (soundRoutine != null) { StopCoroutine(soundRoutine); }
            isWalking =false;
            
        }

        if (movementController.isRunning && !isRunning)
        {
            if (isWalking)
            {
                if (soundRoutine != null) { StopCoroutine(soundRoutine); }
            }

            soundRoutine = runRoutine();
            StartCoroutine(soundRoutine);

            isRunning = true;
        }else if(isRunning && !movementController.isRunning)
        {
            if (isWalking)
            {
                if(soundRoutine != null) { StopCoroutine(soundRoutine); }
                
                soundRoutine = walkRoutine();
                StartCoroutine(soundRoutine);
            }
            else
            {
                if (soundRoutine != null) { StopCoroutine(soundRoutine); }
            }

            isRunning = false;
        }

        


    }

    IEnumerator walkRoutine()
    {
      
        yield return new WaitForSeconds(w_offset);
        while (true)
        {
            source.Play();
            yield return new WaitForSeconds(source.clip.length + w_delay);

        }
    }

    IEnumerator runRoutine()
    {
        
        yield return new WaitForSeconds(r_offset);
        while (true)
        {
            source.Play();
            yield return new WaitForSeconds(source.clip.length + r_delay);

        }
    }

    public void setPlayerSoundState(Component sender, object data)
    {
        if(data is bool)
        {
            isActive = false;
        }
    }


}
