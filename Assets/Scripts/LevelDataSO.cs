using UnityEngine;

[CreateAssetMenu(menuName = "Level Datas/New Level Data", fileName = "New Level Data")]
public class LevelDataSO : ScriptableObject
{
    [Header("Level Settings")]
    public string sceneToLoadName;
    public string levelName;
    public Color squareColor = Color.blue;
    public int squareCount = 50;
    public int squareInitLifes = 3;
}