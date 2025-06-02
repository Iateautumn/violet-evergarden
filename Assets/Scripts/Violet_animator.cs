using UnityEngine;

public class Violet_animator : MonoBehaviour
{
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponentInParent<Player>(); 
    }

    // Update is called once per frame
    private void AnimationTrigger()
    {
        player.AttackOver();
    }
}
