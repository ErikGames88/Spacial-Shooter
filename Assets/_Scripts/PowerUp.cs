using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float duration; 
    GameObject player;

    private ParticleSystem powerUpEffect;

    public float Duration
    {
        get => duration;
        set => duration = value; 
    }

    public void StartPowerUp(GameObject other)
    {
        player = other;

        Transform particleTransform = player.transform.Find("Power Up Effect");
        if (particleTransform != null)
        {
            powerUpEffect = particleTransform.GetComponentInChildren<ParticleSystem>();
        }
        ApplyPowerUp(player, true);

        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(HandlePowerUpDuration());
        }
    }

    private void ApplyPowerUp(GameObject player, bool apply)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        Life playerLife = player.GetComponent<Life>();

        if (playerShooting != null && playerLife != null)
        {
            playerShooting.hasInfiniteAmmunition = apply;
            playerLife.isInvulnerable = apply;
        }
        
    }

    private IEnumerator HandlePowerUpDuration()
    {
        yield return new WaitForSeconds(duration);
        ApplyPowerUp(player, false);

        if (powerUpEffect != null)
        {
            powerUpEffect.Stop();
        }
        
    }
}
