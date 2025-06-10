using UnityEngine;

public class EWizardFireball : MonoBehaviour
{
    [Header("Fireball")]
    [SerializeField] private GameObject fireballTemplate;
    [SerializeField] private Vector2 fireballVector;
    [SerializeField] public float fireballSpeed;
    [SerializeField] public float lifeTime = 2f;
    [SerializeField] public float attackRadius;
    [SerializeField] public float attackWidth;
    [SerializeField] public int damage;
    
    public void CreateFireball(EWizard eWizard)
    {
        GameObject fireball = Instantiate(fireballTemplate, eWizard.transform.position, transform.rotation);
        EWizardFireballController fireballController = fireball.GetComponent<EWizardFireballController>();
        fireballVector = new Vector2(fireballSpeed * eWizard.facingDirection, 0);

        fireballController.SetupFireball(fireballVector);
        Destroy(fireball, lifeTime);
    }

    public void Create2SideFireball(EWizard eWizard)
    {
        GameObject fireball = Instantiate(fireballTemplate, eWizard.transform.position, transform.rotation);
        GameObject fireball1 = Instantiate(fireballTemplate, eWizard.transform.position, transform.rotation);
        EWizardFireballController fireballController = fireball.GetComponent<EWizardFireballController>();
        EWizardFireballController fireballController1 = fireball1.GetComponent<EWizardFireballController>();
        fireballVector = new Vector2(fireballSpeed * eWizard.facingDirection, 0);
        fireballController.SetupFireball(fireballVector);
        fireballController1.SetupFireball(new Vector2(fireballSpeed * -1f * eWizard.facingDirection, 0));
        Destroy(fireball, lifeTime);
        Destroy(fireball1, lifeTime);
    }
    
}
