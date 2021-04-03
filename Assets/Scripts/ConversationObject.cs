using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ConversationObject", order = 1)]
public class ConversationObject : ScriptableObject
{
    public ConversationData[] data;
}

[System.Serializable]
public class ConversationData
{
    public GameObject Character;
    public string Script;
}