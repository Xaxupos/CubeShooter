using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SquareRotator : MonoBehaviour
{
    [Header("References")]
    public Square owner;

    [Header("Settings")]
    public float rotationTime = 0.2f;
    [Range(0f, 1f)] public float randomMaxRotateDelay = 1.0f;
    [Range(0f, 360f)] public float randomMaxRotateDegree = 360.0f;
    public bool isRotating = false;

    private void OnEnable()
    {
        StartCoroutine(StartRandomRotations());
    }

    private IEnumerator StartRandomRotations()
    {
        while(!owner.healthSystem.isDead)
        {
            yield return new WaitUntil(() => !isRotating);

            float randomTime = Random.Range(0, randomMaxRotateDelay);
            yield return new WaitForSeconds(randomTime);

            DoRandomRotation();
        }
    }

    public void DoRandomRotation()
    {
        var randomRotation = Random.Range(0, randomMaxRotateDegree);
        isRotating = true;
        DOVirtual.Float(owner.transform.eulerAngles.z, randomRotation, rotationTime, r =>
        {
            owner.transform.eulerAngles = new Vector3(owner.transform.eulerAngles.x, owner.transform.eulerAngles.y, r);
        }).OnComplete(() => isRotating = false); ;
    }
}