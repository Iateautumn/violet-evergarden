using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    
    public DashSkill dashSkill;
    public FireballSkill fireballSkill;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dashSkill = GetComponent<DashSkill>();
        fireballSkill = GetComponent<FireballSkill>();
    }
}
