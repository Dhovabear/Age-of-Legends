using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager _PlayerManager;

    public static GameManager current; //pour y acceder de n'importe ou
    // Start is called before the first frame update
    void Start()
    {
        //A voir quand y'aura le online
        _PlayerManager.InitPlayers();
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerManager GetPlayerManager()
    {
        return _PlayerManager;
    }
}
