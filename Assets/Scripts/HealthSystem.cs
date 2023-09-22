using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [Header("References")]
    public TMP_Text healthText;
    public Square owner;

    [Header("Properties")]
    public int maxHealth = 3;
    public bool isDead = false;

    private int currentHealth = 3;

    private void Awake()
    {
        SetMaxHealth();
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        healthText.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            isDead = true;
            GameManager.Instance.remainingSquares.Remove(owner);
            GameManager.Instance.OnSquareRemovedCompletely?.Invoke();
            Destroy(owner.gameObject);
            return;
        }

        owner.RespawnSquare(LevelDataStorageManager.Instance.currentLevelData.respawnDelay);
    }

    public void SetMaxHealth()
    {
        maxHealth = LevelDataStorageManager.Instance.currentLevelData.squareInitLifes;
    }
}