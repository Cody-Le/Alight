using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToruChase : MonoBehaviour
{


    [Header("Chase Parameter")]
    [SerializeField] private bool chasePlayer = false;
    [SerializeField] private bool spotPlayer = false;
    Transform player;
    [Range(0, 10f)]public float runSpeed = 3f;
    CharacterController controller;
    public float minDistance;

    [Header("Effects")]
    public PlayableDirector timeline;
    public string cutSceneName;
   
    public Material retroMaterial;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
   
        
    }


    private void Update()
    {
        if(player == null) { return; }
        Vector3 targetPoint = player.position - transform.position;

        if (spotPlayer)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }

        if (chasePlayer)
        {
            controller.Move(targetPoint.normalized * runSpeed * Time.deltaTime);
            float noiseAmount = 0.008f - targetPoint.magnitude / 100;
            Debug.Log(noiseAmount);
            retroMaterial.SetFloat("NoiseAmount", 0.008f + noiseAmount);
            if (targetPoint.magnitude < minDistance)
            {
                SceneManager.LoadScene(cutSceneName);
            }
            
        }

        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            spotPlayer = true;
            player = other.transform;
            StartCoroutine(startChase());
            
        }
    }

    

    IEnumerator startChase()
    {
        yield return new WaitForSeconds(1.5f);
        if (!chasePlayer) { timeline.Play(); }
        chasePlayer = true;
        
    }


}
