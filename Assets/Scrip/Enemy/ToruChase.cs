using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ToruChase : MonoBehaviour
{
    [SerializeField] private bool chasePlayer = false;
    [SerializeField] private bool spotPlayer = false;
    public PlayableDirector timeline;
    Transform player;
    [Range(0, 10f)]public float runSpeed = 3f;
    CharacterController controller;
    Transform view;
    public float minDistance;
    public string cutSceneName;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        view = transform.GetChild(0);
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
            if(targetPoint.magnitude < minDistance)
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
