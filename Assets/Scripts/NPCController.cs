using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] GameObject talkObj;
    [Multiline] public string talkScript;

    public void ActiveTalk(bool value)
    {
        talkObj.SetActive(value);
    }
}
