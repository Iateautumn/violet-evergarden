using UnityEngine;
// this dir is the skill system of player, can be extended easily if there are more skills in the future
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
        dashSkill = GetComponent<DashSkill>();
        fireballSkill = GetComponent<FireballSkill>();
        getDamagedSkill = GetComponent<GetDamagedSkill>();
        recoverSkill = GetComponent<RecoverSkill>();
    }

    private void Start()
    {
        // dashSkill = GetComponent<DashSkill>();
        // fireballSkill = GetComponent<FireballSkill>();
        // getDamagedSkill = GetComponent<GetDamagedSkill>();
        // recoverSkill = GetComponent<RecoverSkill>();
    }
}
