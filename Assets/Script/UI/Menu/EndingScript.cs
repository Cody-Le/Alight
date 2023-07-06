using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public GameObject support;
    public PlayableDirector timeline;
    public GameObject thanks;
    public float timeTransition = 4f;
   


    private void Update()
    {
        if (this.gameObject.active)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                timeline.enabled = false;
                support.SetActive(false);
                thanks.SetActive(true);
                StartCoroutine(timetoend(timeTransition));
            }
        }
    }


    IEnumerator timetoend(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
}
