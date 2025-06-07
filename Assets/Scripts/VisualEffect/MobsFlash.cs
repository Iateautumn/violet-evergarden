using System.Collections;
using UnityEngine;

public class MobsFlash : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [Header("Visual Effect")]
    [SerializeField] private Material hitMaterial;

    private float flashDuration = 0.2f;
    private Material originalMaterial;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator HitFlash()
    {
        spriteRenderer.material = hitMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = originalMaterial;
    }
    
}
