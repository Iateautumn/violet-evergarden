using System;
using UnityEngine;

public class FireballSkill : Skill
{
    [Header("Fireball")]
    [SerializeField] private GameObject fireballTemplate;
    [SerializeField] private Vector2 fireballVector;
    [SerializeField] public float fireballSpeed;
    [SerializeField] public float lifeTime = 2f;
    [SerializeField] public float attackRadius;
    [SerializeField] public float attackWidth;
    [SerializeField] public int damage;
    [SerializeField] public int manaCost;
    protected override void Start()
    {
        base.Start();

    }
    
    public override void UseSkill()
    {
        base.UseSkill();
    }



    public void CreateFireball()
    {
        GameObject fireball = Instantiate(fireballTemplate, violet.transform.position, transform.rotation);
        FireballController fireballController = fireball.GetComponent<FireballController>();
        fireballVector = new Vector2(fireballSpeed * violet.facingDirection, 0);

        fireballController.SetupFireball(fireballVector);
        Destroy(fireball, lifeTime);
        
        
    }
}
