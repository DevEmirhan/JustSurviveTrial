using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level Profile", order = 1000)]

public class LevelProfiler : ScriptableObject
{
    public List<Level> AllsLevels;


    public Level this[int i]
    {
        get
        {
            return AllsLevels[i];
        }
    }
}
 