using UnityEngine;
using UnityEngine.SceneManagement;

public class EWizardAnimTrigger : MonoBehaviour
{

    private EWizard eWizard => GetComponentInParent<EWizard>();
    private MobsSEF mobsSef => GetComponentInChildren<MobsSEF>();

    private void AnimTrigger()
    {
        eWizard.AnimEndTrigger();
    }
    private void HackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(eWizard.attackCheck.position, new Vector2(eWizard.attackCheckRadius,eWizard.hackWidth),0f);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Violet>() != null)
            {
                VioletStats target = hit.GetComponent<VioletStats>();
                eWizard.charStats.DoDamage(target, eWizard.facingDirection);
            }
        }
    }

    private void CreateFireball()
    {
        MobRangedAttackManager.instance.eWizardFireball.CreateFireball(eWizard);
    }

    private void TeleportTrigger()
    {
        Vector2 positionRight = PlayerManager.instance.violet.transform.position;
        positionRight.x = positionRight.x + eWizard.attackCheckRadius * 4f / 5f;
        bool isOnGroundRight = Physics2D.OverlapPoint(positionRight, LayerMask.GetMask("Ground")) != null;
        Vector2 positionLeft = PlayerManager.instance.violet.transform.position;
        positionLeft.x = positionLeft.x - eWizard.attackCheckRadius * 4f / 5f;
        bool isOnGroundLeft = Physics2D.OverlapPoint(positionLeft, LayerMask.GetMask("Ground")) != null;
        if (!isOnGroundRight && !isOnGroundLeft)
        {
            if (Random.Range(0, 2) == 1)
            {
                eWizard.transform.position = positionRight;
                if (eWizard.facingDirection == 1)
                {
                    eWizard.Flip();
                }
            }
            else
            {
                eWizard.transform.position = positionLeft;
                if (eWizard.facingDirection == -1)
                {
                    eWizard.Flip();
                }
            }
        }else if (!isOnGroundRight)
        {
            eWizard.transform.position = positionRight;
            if (eWizard.facingDirection == 1)
            {
                eWizard.Flip();
            }
        }else if (!isOnGroundLeft)
        {
            eWizard.transform.position = positionLeft;
            if (eWizard.facingDirection == -1)
            {
                eWizard.Flip();
            }
        }
    }

    private void TeleportAboveTrigger()
    {
        Vector2 position = PlayerManager.instance.violet.transform.position;
        position.y = position.y + eWizard.attackCheckRadius;
        Debug.Log("position" + position);
        bool isInGround = Physics2D.OverlapPoint(position, LayerMask.GetMask("Ground")) != null;
        if (!isInGround)
        {
            eWizard.transform.position = position;
        }
    }

    private void JumpAttackFireball()
    {
        MobRangedAttackManager.instance.eWizardFireball.Create2SideFireball(eWizard);
        FallDownSETrigger();
    }

    private void JumpAttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(eWizard.transform.position, new Vector2(eWizard.attackCheckRadius,eWizard.hackWidth),0f);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Violet>() != null)
            {
                VioletStats target = hit.GetComponent<VioletStats>();
               eWizard.charStats.DoDamage(target, eWizard.facingDirection);
                
            }
        }
    }

    private void HackSETrigger()
    {   
        mobsSef.PlaySound(MobsSEF.SoundType.Attack);
    }
    private void FireballSETrigger()
    {   
        mobsSef.PlaySound(MobsSEF.SoundType.Fireball);
    }
    private void FallDownSETrigger()
    {   
        mobsSef.PlaySound(MobsSEF.SoundType.FallDown);
    }
    private void TeleportSETrigger()
    {
        mobsSef.PlaySound(MobsSEF.SoundType.Teleport);
    }

    private void DeathSETrigger()
    {
        mobsSef.PlaySound(MobsSEF.SoundType.Death);
    }

    private void EndingTrigger()
    {
        SaveManager.instance.SaveGame();
        BGMManager.instance.PlayBGM("light");
        SceneManager.LoadScene("VioletEvergarden");
    }
}
