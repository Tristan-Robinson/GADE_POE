using UnityEngine;

public class PatrolEnemy : EnemyAi
{
    public PatrolPath patrolScript;

    public override void Initialize()
    {
        base.Initialize();
        patrolScript.enabled = true;
    }
}
