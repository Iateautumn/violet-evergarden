using System;
using UnityEngine;

public class MobRangedAttackManager : MonoBehaviour
{
    public static MobRangedAttackManager instance;
    public EWizardFireball eWizardFireball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eWizardFireball = GetComponent<EWizardFireball>();
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
