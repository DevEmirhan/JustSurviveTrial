using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float levelTimeLimit = 30f;
    public int keyRequirement = 3;
    public Transform playerStartPos;
    [SerializeField] private List<Trap> obstacles = new List<Trap>();

    public void StartGame()
    {
        foreach (var obs in obstacles)
        {
            obs.ActivateTrap();
        }
    }

    public void EndGame()
    {
        foreach (var obs in obstacles)
        {
            obs.DeactivateTrap();
        }
    }
}
