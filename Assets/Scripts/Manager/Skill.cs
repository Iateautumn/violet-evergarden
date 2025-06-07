using UnityEngine;

public class Skill : MonoBehaviour
{

    [SerializeField] protected float cooldownTime;
    protected float cooldownTimer;

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if (cooldownTimer <= 0)
        {
            UseSkill();
            cooldownTimer = cooldownTime;
            return true;
        }
        return false;
    }

    public virtual void UseSkill()
    {
        
    }
    
}
