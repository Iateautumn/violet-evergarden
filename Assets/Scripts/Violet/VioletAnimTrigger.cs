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
                EnemyStats target = hit.GetComponent<EnemyStats>();
                violet.violetStats.DoDamage(target,violet.facingDirection);
            }
        }
    }

    private void CreateFireball()
    {
        if (violet.violetStats.IsManaEnough(SkillManager.instance.fireballSkill.manaCost))
        {
            violet.violetStats.IncreaseMana(- SkillManager.instance.fireballSkill.manaCost);
            SkillManager.instance.fireballSkill.CreateFireball();
        }
    }

    private void RecoverTrigger()
    {
        if (violet.violetStats.IsManaEnough(SkillManager.instance.recoverSkill.manaCost))
        {
            violet.violetStats.IncreaseMana(- SkillManager.instance.recoverSkill.manaCost);
            violet.charStats.Recover(SkillManager.instance.recoverSkill.recoverHealth);
        }

    }

    
}
