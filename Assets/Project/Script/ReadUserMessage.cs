using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ReadUserMessage : MonoBehaviour
{
    public string readMessage;
    private MessageType messageType;
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlMessage()
    {
        //Debug.Log(readMessage);
        if (readMessage=="PP")
        {
            messageType = MessageType.PP;
        }
        else if (readMessage=="QQ")
        {
            messageType = MessageType.QQ;
        }
        else if (readMessage=="DD")
        {
            messageType = MessageType.DD;
        }
        else if (readMessage == "GG")
        {
            messageType = MessageType.GG;
        }
        else if (readMessage == "NN")
        {
            messageType = MessageType.NN;
        }
        else if (readMessage == "TT")
        {
            messageType = MessageType.TT;
        }
        else if (readMessage == "SS")
        {
            messageType = MessageType.SS;
        }
        else
        {
            messageType = MessageType.NONE;
        }
        TriggerNPC();
    }

    public void TriggerNPC()
    {
        switch (messageType)
        {
            case MessageType.PP:
                npc.GetComponent<Npc>().GoPlayer();
                break;
            case MessageType.QQ:
                npc.GetComponent<Animator>().SetTrigger("Greeting");
                break;
            case MessageType.NONE:
                Debug.Log("Hiç bir şey yapma");
                break;
            case MessageType.DD:
                npc.GetComponent<Npc>().DanceAction();
                break;
            case MessageType.GG:
                npc.GetComponent<Npc>().BendOverAction();
                break;
            case MessageType.NN:
                npc.GetComponent<Npc>().SetNormal();
                break;
            case MessageType.TT:
                npc.GetComponent<Npc>().TakeBall();
                break;
            case MessageType.SS:
                npc.GetComponent<Npc>().SingSong();
                break;
            default:
                break;
        }
    }

}

public enum MessageType
{
    PP,
    QQ,
    DD,
    GG,
    NN,
    TT,
    SS,
    NONE
}
