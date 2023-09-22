using MoreMountains.Feedbacks;
using UnityEngine;

public class Square : MonoBehaviour
{
    [Header("References")]
    public HealthSystem healthSystem;
    public SpriteRenderer squareSpriteRenderer;
    public MMF_Player spawnFeedback;

    [Header("Square Settings")]
    public float squareSize = 1;

    public void RespawnSquare(float delay)
    {
        StartCoroutine(SquareSpawnManager.Instance.RespawnCoroutine(this,delay));
        gameObject.SetActive(false);
    }

    public bool SetSquareRandomFreePosition()
    {
        //Dangerous loop, yet I don't have other idea for now
        while (true) 
        {
            var randomPos = GetRandomVisiblePosition();

            Collider2D[] squaresNear = Physics2D.OverlapCircleAll(randomPos, squareSize);

            if (squaresNear.Length == 0)
            {
                transform.position = randomPos;
                return true;
            }
        }
    }

    private Vector3 GetRandomVisiblePosition()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        //Take only 90% of camera size so half square doesn't spawn outside
        float xOffset = cameraWidth * (1 - 0.9f) / 2f;
        float yOffset = cameraHeight * (1 - 0.9f) / 2f;

        float randomX = Random.Range(-cameraWidth / 2f + xOffset, cameraWidth / 2f - xOffset);
        float randomY = Random.Range(-cameraHeight / 2f + yOffset, cameraHeight / 2f - yOffset);

        return new Vector3(randomX, randomY, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, squareSize);
    }
}