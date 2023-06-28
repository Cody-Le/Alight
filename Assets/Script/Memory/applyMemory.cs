using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class applyMemory : MonoBehaviour
{
    //The monobehaviour script with the functionality of applying the memory save in scene to the player

    GameObject Player;
    public bool loadMemory = false;

    void Start()
    {
        Player = this.gameObject;

       
        if (loadMemory)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            Debug.LogWarning(index);
            if (!saveSystem.CheckPlayerState(index)) { Debug.LogError("No Memory found"); return; }
            Debug.Log("ApplyingMemory");
            playerState state = saveSystem.LoadPlayer(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(state.isBagged);
            applyPlayerState(Player, state);
        }


       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void applyPlayerState(GameObject player, playerState state)
    {
        Debug.Log(player.name);
        Debug.Log(state.position);
        player.transform.position = new Vector3(state.position[0], state.position[1], state.position[2]);

    }

}
