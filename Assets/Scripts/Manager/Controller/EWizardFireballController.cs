using UnityEngine;

public class EWizardFireballController : Controller
{
    private Vector2 velocity;
    public void SetupFireball(Vector2 dir)
    {

        rb.linearVelocity = dir;
        velocity = dir;
        if (rb.linearVelocity.x < 0) 
            transform.Rotate(0, 180, 0);
    }

    protected override void Awake()
    {
        base.Awake();
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(SkillManager.instance.fireballSkill.attackRadius,SkillManager.instance.fireballSkill.attackWidth,0));
    }

    protected override void Update()
    {
        base.Update();
        rb.linearVelocity = velocity;
        // Debug.Log(velocity);
    }
}
