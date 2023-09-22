using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer spriteRenderer;

    [Header("Settings")]
    public float moveSpeed = 2.5f;
    public int damage = 1;

    private void Start()
    {
        spriteRenderer.color = LevelDataStorageManager.Instance.currentLevelData.squareColor;

    }

    private void Update()
    {
        //Translate operates on local space by default
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if(IsOutsideCamera())
            PoolManager.Instance.ReleaseToPool(ObjectType.SQUARE_PROJECTILE, this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Could also use TryGetComponent
        IDamageable damageable = collider.GetComponentInChildren<IDamageable>();

        if(damageable != null)
        {
            damageable.TakeDamage(damage);
            PoolManager.Instance.ReleaseToPool(ObjectType.SQUARE_PROJECTILE, this.gameObject);
        }    
    }

    private bool IsOutsideCamera()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        float leftThreshold = -0.1f;
        float rightThreshold = 1.1f;
        float topThreshold = 1.1f;
        float bottomThreshold = -0.1f;

        return (viewPos.y < bottomThreshold || viewPos.y > topThreshold || viewPos.x < leftThreshold || viewPos.x > rightThreshold);
    }
}