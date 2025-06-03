using UnityEngine;

public class VioletAnimTrigger : MonoBehaviour
{
    private Violet violet => GetComponentInParent<Violet>();

    private void AnimTrigger()
    {
        violet.AnimEndTrigger();
    }
    
}
