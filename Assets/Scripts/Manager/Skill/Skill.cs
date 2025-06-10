using UnityEngine;

public class Skill : MonoBehaviour
{

    [SerializeField] protected float cooldownTime;
    protected float cooldownTimer;
    protected Violet violet;

    protected virtual void Start()
    {
        violet = PlayerManager.instance.violet;
    }
    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if (cooldownTimer <= 0)
        {
            return true;
        }
        return false;
    }

    public virtual void UseSkill()
    {
        cooldownTimer = cooldownTime;
    }
    
}
