using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy6 : Entity
{
    public E6_IdleState idleState { get; private set; } 
    public E6_MoveState moveState { get; private set; }
    public E6_PlayerDetectedState playerDetectedState { get; private set; }

    public E6_ChargeState chargeState { get; private set; }

    public E6_LookForPlayerState lookForPlayerState { get; private set; }
    public E6_MeleeAttackState meleeAttackState { get; private set; }
    public E6_StunState stunState { get; private set; }
    public E6_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;


    [SerializeField]
    private Transform meleeAttackPosition;

    public static bool gamepause = false;

    public GameObject ui;


    public override void Start()
    {
        base.Start();

        moveState = new E6_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E6_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E6_PlayerDetectedState(this, stateMachine, "playerDetected",playerDetectedData, this);


        chargeState = new E6_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E6_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E6_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E6_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E6_DeadState(this, stateMachine, "dead", deadStateData, this);
        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
            Pause();
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }

    }
    public void Pause()
    {
        ui.SetActive(true);
        gamepause = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
