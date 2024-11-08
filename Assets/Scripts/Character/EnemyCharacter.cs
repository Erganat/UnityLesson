using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{

    [SerializeField] private AIState currentState;
    
    private float timeBetweenAttackCounter = 0;

    public override Character CharacterTarget => 
        GameManager.Instance.CharacterFactory.Player;



    public override void Initialize()
    {
        base.Initialize();

        LiveComponent = new ImmortalLiveComponent();
        DamageComponent = new CharacterDamageComponent();

    }
    public override void Update()
    {
        if (Vector3.Distance(CharacterTarget.transform.position, transform.position) < 2 && timeBetweenAttackCounter <= 0)
            currentState = AIState.Attack;
        else
            currentState = AIState.MoveToTarget;

        switch (currentState)
        {
            case AIState.None:

                break;

            case AIState.MoveToTarget:
                Vector3 direction = CharacterTarget.transform.position - transform.position;
                direction.Normalize();

                MovableComponent.Move(direction);
                MovableComponent.Rotation(direction);
                                
                break;


            case AIState.Attack:
                                    
                    DamageComponent.MakeDamage(CharacterTarget);
                    timeBetweenAttackCounter = characterData.TimeBetweenAttacks;
                if (timeBetweenAttackCounter > 0)
                    timeBetweenAttackCounter -= Time.deltaTime;

                break;
                                   
                

        }
    }
}
