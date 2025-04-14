using UnityEngine;

public class SkillProjectileObj : SkillObj
{
    private TrajectoryManager _trajectoryManager;
    private BaseTrajectory _trajectory;
    protected bool _ispenetration = false;
    protected bool _canBeHit = false;
    
    private Vector3 dir;

    protected virtual void Awake()
    {
        _trajectoryManager = GetComponentInChildren<TrajectoryManager>();
    }

    public override void Initialize(Skill _skill)
    {
        base.Initialize(_skill);
        _ispenetration = (skill.GetSkillData(SkillFieldDataType.Projectile) as ProjectileSkillDataSO).ispenetration;
        SetTrajectory();
    }
    
    public void SetTrajectory()
    {
        if (skill.GetSkillData(SkillFieldDataType.Projectile) is ProjectileSkillDataSO projectileSkillDataSO)
        {
            _trajectory = _trajectoryManager.GetTrajectory(projectileSkillDataSO.currentTrajectoryList);
            _trajectory.Init(this);
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        Debug.Log("DestroyObject");
        Destroy(gameObject);
    }

    protected virtual void FixedUpdate()
    {
        dir = _trajectory.UpdateTrajectory();

        // transform.rotation = Quaternion.Euler(dir);
        transform.position += dir;
        Debug.Log($"Update: {dir}");
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DetectWall")
            || other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if ((skill.GetSkillData(SkillFieldDataType.Projectile) as ProjectileSkillDataSO).canReflection)
            {
                Debug.Log("Reflection");
                Vector3 closestPoint = other.ClosestPoint(transform.position);
                Vector3 normal = (transform.position - closestPoint).normalized;
                Vector3 reflection = Vector3.Reflect(dir, normal);

                dir += reflection.normalized;
                Debug.Log("Trigger: " + dir);
            }
            else
                CallDestroyEvent();
        }
    }
}
