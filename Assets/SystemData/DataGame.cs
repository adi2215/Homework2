using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class DataGame
{
    public string Name;
    public int sceneID;
    public Vector2 PositionPlayer;
    public bool checkDie;

    public DataGame(string name, int sceneID, Vector2 position, bool checkingDie)
    {
        Name = name;
        this.sceneID = sceneID;
        PositionPlayer = position;
        checkDie = checkingDie;
    }
}
