using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    
    public DashSkill dashSkill;

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
    }
}
