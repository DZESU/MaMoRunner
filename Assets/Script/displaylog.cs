using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class displaylog : MonoBehaviour {

    public GameObject playerObj;
    Player player;
    private void Start()
    {
        player = playerObj.GetComponent<Player>();
    }
    public void onButtonClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            GameControllerScript.isPause = false;
            if(player !=null)
            player.ResetPlayer();
            else
            Debug.Log("click on is pause: " + GameControllerScript.isPause);
        }
        
    }

}
