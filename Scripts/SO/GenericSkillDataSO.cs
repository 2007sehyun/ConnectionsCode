using UnityEngine;

[CreateAssetMenu(fileName = "GenericSkillDataSO", menuName = "SO/SkillData/GenericSkillDataSO")]
public class GenericSkillDataSO : SkillFieldDataSO
{
    public float damage;
    private float _damage;
    
    public int attackCount;
    private int _attackCount;
    
    public float coolTime;
    private float _coolTime;
    
    public float skillDamageDelay;
    private float _skillDamageDelay;
    
    public float skillActiveDelay;     //this is for applying damage with an animation or particle delay on time.
    private float _skillActiveDelay;
    
    public float skillActiveDuration;   // this is for duratino buff or somthing like that
    private float _skillActiveDuration;
    
    public float reShootTime;       // this is for re shoot coroutine delay
    private float _reShootTime;
    
    public float criticalHitChance; 
    private float _criticalHitChance;

    public override void SetDefaultValues()
    {
        _damage = damage;
        _attackCount = attackCount;
        _coolTime = coolTime;
        _skillDamageDelay = skillDamageDelay;
        _skillActiveDelay = skillActiveDelay;
        _skillActiveDuration = skillActiveDuration;
        _reShootTime = reShootTime;
        _criticalHitChance = criticalHitChance;
    }

    public override void Init()
    {
        damage = _damage;
        attackCount = _attackCount;
        coolTime = _coolTime;
        skillDamageDelay = _skillDamageDelay;
        skillActiveDelay = _skillActiveDelay;
        skillActiveDuration = _skillActiveDuration;
        reShootTime = _reShootTime;
        criticalHitChance = _criticalHitChance;
    }
}
