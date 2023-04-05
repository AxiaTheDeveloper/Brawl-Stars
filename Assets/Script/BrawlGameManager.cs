using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlGameManager : MonoBehaviour
{
    public static BrawlGameManager Instance {get; private set;}
    public enum StateGame{
        WaitingToStart, GameStart, GameOver
    }
    
    private StateGame state;
}
