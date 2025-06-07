using UnityEngine;

public class Violet_animator : MonoBehaviour
{
    private Violet violet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        violet = GetComponentInParent<Violet>(); 
    }

    // Update is called once per frame
    private void AnimationTrigger()
    {
        violet.AttackOver();
    }
}
