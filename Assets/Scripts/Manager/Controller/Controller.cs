using UnityEngine;
// control the ranged attack entity of enemy
public class Controller : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Violet violet;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        violet = PlayerManager.instance.violet;
    }

    protected virtual void Update()
    {
        
    }
}
