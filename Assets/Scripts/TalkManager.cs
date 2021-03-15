using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    [SerializeField] GameObject talkObj;

    public GameObject NPCTalkImage;
    public GameObject PlayerTalkeImage;
    [Multiline] public string[] NPCScripts;
    [Multiline] public string[] PlayerScripts;

    public int currentIndex = 0;
    public bool isPlayerTurn = false;

    public void ActiveTalkPanel(bool value)
    {
        talkObj.SetActive(value);
        if (value)
        {
            ActiveTalkImage();
        }
        
    }

    public void ActiveTalkImage()
    {
        //if (!isPlayerTurn)
        //{
        //    NPCTalkImage.SetActive(true);
        //    PlayerTalkeImage.SetActive(false);
        //}
        //else
        //{
        //    NPCTalkImage.SetActive(false);
        //    PlayerTalkeImage.SetActive(true);
        //}

        // playerturn == true;
        //NPCTalkImage.SetActive(!isPlayerTurn);
        //PlayerTalkeImage.SetActive(isPlayerTurn);

        //삼항연산자
        NPCTalkImage.SetActive(isPlayerTurn ? false : true);
        NPCTalkImage.GetComponentInChildren<Text>().text = NPCScripts[currentIndex];
        PlayerTalkeImage.SetActive(isPlayerTurn ? true : false);
        PlayerTalkeImage.GetComponentInChildren<Text>().text = PlayerScripts[currentIndex];
    }

    public void OnTalkBoxClick()
    {
        if (isPlayerTurn)
        {
            currentIndex++;
        }

        isPlayerTurn = !isPlayerTurn;

        if (currentIndex >= NPCScripts.Length)
        {
            ActiveTalkPanel(false);
        }
        else
        {
            ActiveTalkImage();
        }
    }
}
