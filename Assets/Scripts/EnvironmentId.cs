using UnityEngine;

[System.Serializable]
public class EnvironmentId
{
    public string id;

    public string ToJson() => JsonUtility.ToJson(this, true);
}
