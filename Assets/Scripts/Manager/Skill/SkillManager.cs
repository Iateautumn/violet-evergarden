using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    
    public DashSkill dashSkill;
    public FireballSkill fireballSkill;
    public GetDamagedSkill getDamagedSkill;
    public RecoverSkill recoverSkill;


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
        getDamagedSkill = GetComponent<GetDamagedSkill>();
        recoverSkill = GetComponent<RecoverSkill>();
    }
}
