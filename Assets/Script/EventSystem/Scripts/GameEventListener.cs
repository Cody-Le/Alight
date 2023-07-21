using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> {}

public class GameEventListener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent gameEvent;
    public CustomGameEvent response;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None; 
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}
