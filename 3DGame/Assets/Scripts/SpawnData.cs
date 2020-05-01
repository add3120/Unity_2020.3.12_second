using UnityEngine;

[CreateAssetMenu(fileName = "關卡資料", menuName = "HAO/關卡資料")]
public class SpawnData : ScriptableObject
{
    public SpawnTime[] spawn;
}

// 序列化 : 顯示在Unity 屬性面板 (class 專用)
[System.Serializable]
public class SpawnTime
{
    public  string name = "時間";
    public float time;
    public SpawnMonster[] monsters;
}

[System.Serializable]
public class SpawnMonster
{
    public GameObject monster;
    public float x;
}
