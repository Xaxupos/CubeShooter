using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [Header("References")]
    public Square owner;

    [Header("Properties")]
    public int maxHealth = 3;
    public bool isDead = false;

    private int currentHealth = 3;

    private void Awake()
    {
        SetMaxHealth();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            return;
        }

        owner.RespawnSquare(LevelDataStorageManager.Instance.currentLevelData.respawnDelay);
    }

    public void SetMaxHealth()
    {
        maxHealth = LevelDataStorageManager.Instance.currentLevelData.squareInitLifes;
    }
}