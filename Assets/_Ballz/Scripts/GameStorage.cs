using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Storage")]
public class GameStorage : ScriptableObject
{
    public uint Score;
    public uint BestScore;   
}