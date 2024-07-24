using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.FinalIK;
public class Npc : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _musicSource;
    [SerializeField] private GameObject _microphone;
    private bool moveControl = false;
    private bool ballControl = false;
    private float reachTolerance = 1.2f;
    private NavMeshAgent agent;
    private Animator anim;
    private Vector3 movePosition;
    private MoveType moveType;
    [Tooltip("The object to interact to")]
    public InteractionObject interactionObject;
    private InteractionSystem interactionSystem;
    public FullBodyBipedEffector[] effectors;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        interactionSystem = GetComponent<InteractionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
    }


    public void GoPlayer()
    {
        moveType = MoveType.GOPLAYER;
        movePosition = player.transform.position;
        moveControl = true;
        GetComponent<Animator>().SetBool("Walk", true);
    }

    public void DanceAction()
    {
        anim.SetTrigger("Dance");
    }

    public void BendOverAction()
    {
        anim.SetBool("BendOver", true);
    }

    public void SetNormal()
    {
        anim.SetBool("BendOver", false);
    }

    public void SingSong()
    {
        anim.SetTrigger("Singing");
        _musicSource.GetComponent<AudioSource>().Play();
        _microphone.SetActive(true);
        StartCoroutine(DisableMicrophone());
    }

    private IEnumerator DisableMicrophone()
    {
        yield return new WaitForSeconds(14f);
        _microphone.SetActive(false);
    }

    public void TakeBall()
    {
        if (!ballControl)
        {
            moveType = MoveType.TAKEBALL;
            moveControl = true;
            movePosition = _ball.transform.position;
            anim.SetBool("Walk", true);
        }
        
    }

    private void PickUp()
    {
        if (!ballControl)
        {
            if (effectors.Length == 0) Debug.Log("Please select the effectors to interact with.");

            foreach (FullBodyBipedEffector e in effectors)
            {
                interactionSystem.StartInteraction(e, interactionObject, true);
            }
        }
        
        ballControl = true;
    }


    private void CheckPosition()
    {
        if (moveControl)
        {
            MoveNpc();
            Debug.Log(Vector3.Distance(movePosition, transform.position));
            if (Vector3.Distance(movePosition,transform.position) > reachTolerance)
            {
                return;
                //MoveNpc();
            }
            else
            {
                ResetMovement("Walk");
            }
        }
        
        
    }

    private void MoveNpc()
    {
        var position = movePosition;
        agent.SetDestination(position);
    }

    private void ResetMovement(string _animName)
    {
        agent.ResetPath();
        anim.SetBool(_animName, false);
        moveControl = false;
        if (moveType==MoveType.TAKEBALL)
        {
            PickUp();
        }
        moveType = MoveType.IDLE;
    }
}
public enum MoveType
{
    GOPLAYER,
    TAKEBALL,
    IDLE
}
