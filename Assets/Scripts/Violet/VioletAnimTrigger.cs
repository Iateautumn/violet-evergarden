using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VioletAnimTrigger : MonoBehaviour
{
    private Violet violet => PlayerManager.instance.violet;
    private MobsSEF mobsSEF => violet.GetComponentInChildren<MobsSEF>();

    private void AnimTrigger()
    {
        violet.AnimEndTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(violet.attackCheck.position, violet.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                EnemyStats target = hit.GetComponent<EnemyStats>();
                violet.violetStats.DoDamage(target,violet.facingDirection);
            }
        }
    }

    private void CreateFireball()
    {
        if (violet.violetStats.IsManaEnough(SkillManager.instance.fireballSkill.manaCost))
        {
            violet.violetStats.IncreaseMana(- SkillManager.instance.fireballSkill.manaCost);
            SkillManager.instance.fireballSkill.CreateFireball();
        }
    }

    private void RecoverTrigger()
    {
        if (violet.violetStats.IsManaEnough(SkillManager.instance.recoverSkill.manaCost))
        {
            violet.violetStats.IncreaseMana(- SkillManager.instance.recoverSkill.manaCost);
            violet.charStats.Recover(SkillManager.instance.recoverSkill.recoverHealth);
        }

    }

    private void AttackSETrigger()
    {
        mobsSEF.PlaySound(MobsSEF.SoundType.Attack);
    }

    private void RecoverSETrigger()
    {
        mobsSEF.PlaySound(MobsSEF.SoundType.Recover);
    }

    private void FireballSETrigger()
    {
        mobsSEF.PlaySound(MobsSEF.SoundType.Fireball);
    }

    private void DeadTrigger()
    {
        SpawnManager.instance.isFirstLoad = true;
        StartCoroutine(LoadSceneAfterDelay(2f));
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnManager.instance.loadedItems = Inventory.instance.inventoryItems;
        SceneManager.LoadScene(SpawnManager.instance.sceneID);
    }

    
}
