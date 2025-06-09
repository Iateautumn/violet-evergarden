using UnityEngine;

public class VioletAnimTrigger : MonoBehaviour
{
    private Violet violet => PlayerManager.instance.violet;
        //GetComponentInParent<Violet>();

    private void AnimTrigger()
    {
        violet.AnimEndTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(violet.attackCheck.position, violet.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage(violet.facingDirection);
            }
        }
    }

    private void CreateFireball()
    {
        SkillManager.instance.fireballSkill.CreateFireball();
    }

    private void RecoverTrigger()
    {
        Debug.Log("healing");
    }

    
}
