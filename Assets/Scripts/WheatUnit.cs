using System.Collections;
using UnityEngine;
using DG.Tweening;

public class WheatUnit : MonoBehaviour
{
    [SerializeField] private WheatBlock wheatBlock;
    [SerializeField, Min(1f)] private float timeToGrow = 10;
    [SerializeField] private float cuttingHeight = -0.5f;

    private Transform transform;
    private Vector3 basePosition;
    private Vector3 collectPosition;
    public eWheatState WheatState { get; private set; }

    private void Awake()
    {
        transform = GetComponent<Transform>();
        WheatState = eWheatState.Ready;
        basePosition = transform.position;
        collectPosition = transform.position;
        collectPosition.y = cuttingHeight;
    }

    private IEnumerator Growing()
    {
        transform.position = collectPosition;
        WheatState = eWheatState.Growing;
        transform.DOMoveY(basePosition.y, timeToGrow);
        yield return new WaitForSeconds(timeToGrow);
        WheatState = eWheatState.Ready;
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
    //    {
    //        if (WheatState == eWheatState.Ready)
    //        {
    //            playerController.Animator.SetTrigger("Collect");
    //        }
    //    }
    //}

    public void StartCollect()
    {
        wheatBlock = Instantiate(wheatBlock);
        wheatBlock.Spawn();
        StartCoroutine(Growing());
    }
}

public enum eWheatState
{
    Ready,
    Growing,
}
