using UnityEngine;

public class StationaryAi : EnemyAi
{
    public override void Initialize()
    {
        base.Initialize();
        agent.isStopped = true;
    }
}
