using UnityEngine;

public class FireballTrigger : MonoBehaviour
{


    private void FireBallTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.parent.position, new Vector3(SkillManager.instance.fireballSkill.attackRadius,SkillManager.instance.fireballSkill.attackWidth),0 );
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                EnemyStats target = hit.GetComponent<EnemyStats>();
                target.TakeDamage(SkillManager.instance.fireballSkill.damage, PlayerManager.instance.violet.facingDirection);
            }
        }
    }
}
