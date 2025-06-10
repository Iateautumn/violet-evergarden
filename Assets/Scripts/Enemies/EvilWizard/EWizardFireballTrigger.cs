using UnityEngine;

public class EWizardFireballTrigger : MonoBehaviour
{
    private void FireBallTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.parent.position, new Vector3(SkillManager.instance.fireballSkill.attackRadius,SkillManager.instance.fireballSkill.attackWidth),0 );
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Violet>() != null)
            {
                VioletStats target = hit.GetComponent<VioletStats>();
                int facingDirection = GetComponentInParent<Rigidbody2D>().linearVelocity.x > 0? 1 : -1;
                target.TakeDamage(MobRangedAttackManager.instance.eWizardFireball.damage, facingDirection);
                
            }
        }
    }
}
