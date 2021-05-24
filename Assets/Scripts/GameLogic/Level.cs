using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int coinValue = 50;
    public float levelTimeLimit = 30f;
    public int keyRequirement = 3;
    public Transform playerStartPos;
    [SerializeField] private List<Trap> obstacles = new List<Trap>();
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    public void StartGame()
    {
        foreach (var obs in obstacles)
        {
            obs.ActivateTrap();
        }
        foreach(var enemy in enemies)
        {
            enemy.ActivateEnemy();
        }
    }

    public void EndGame()
    {
        foreach (var obs in obstacles)
        {
            obs.DeactivateTrap();
        }
        foreach (var enemy in enemies)
        {
            enemy.DeactivateEnemy();
        }
    }
}
