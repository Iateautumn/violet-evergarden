using UnityEngine;

public class Skeleton1AnimaTrigger : MonoBehaviour
{
    private EnemySkeleton1 skeleton1 => GetComponentInParent<EnemySkeleton1>();

    private void AnimTrigger()
    {
        skeleton1.AnimEndTrigger();
    }

    private void Attack1Trigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(skeleton1.attackCheck.position, new Vector2(skeleton1.attackLength,skeleton1.attackWidth),0f);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Violet>() != null)
            {
                hit.GetComponent<Violet>().Damage(skeleton1.facingDirection);
            }
        }
    }
}
