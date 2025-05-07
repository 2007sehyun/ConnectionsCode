using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsTowerExist", story: "Is [Boss] [SpinksTower] Exist", category: "Conditions", id: "1b075a170265cc833a1f54fec798d042")]
public partial class IsTowerExistCondition : Condition
{
    [SerializeReference] public BlackboardVariable<SpinksTowerManager> SpinksTower;
    [SerializeReference] public BlackboardVariable<BTEnemy> Boss;

    public override bool IsTrue()
    {
        return SpinksTower.Value.CanGetAliveTower();
    }

    public override void OnStart()
    {
        SpinksTower.Value = Boss.Value.GetCompo<SpinksEnemyAttackCompo>()
            .GetEnemyBossLevel().GetComponentInChildren<SpinksTowerManager>();
    }

    public override void OnEnd()
    {
    }
}
