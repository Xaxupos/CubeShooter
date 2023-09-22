using System.Collections;
using UnityEngine;

public class SquareProjectileShooter : MonoBehaviour
{
    [Header("References")]
    public Square owner;
    public Transform shootTransform;

    [Header("Settings")]
    public float shootingDelay = 1.0f;

    private void OnEnable()
    {
        StartCoroutine(StartShootingCoroutine());
    }

    public void ShootProjectile()
    {
        var projectile = PoolManager.Instance.GetFromPool(ObjectType.SQUARE_PROJECTILE);
        projectile.transform.position = shootTransform.position;
        projectile.transform.eulerAngles = owner.transform.eulerAngles;
    }

    private IEnumerator StartShootingCoroutine()
    {
        yield return new WaitUntil(() => GameManager.Instance.gameStarted);

        while(!owner.healthSystem.isDead)
        {
            yield return new WaitForSeconds(shootingDelay);
            ShootProjectile();
        }
    }
}