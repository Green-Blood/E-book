using DG.Tweening;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] animatedObjects;
    void Start()
    {
        for (int i = 0; i < animatedObjects.Length; i++)
        {
            var currentScale = animatedObjects[i].transform.localScale;
            var randomScale = Random.Range(1.02f, 1.03f);
            animatedObjects[i].transform
                .DOScale(new Vector3(randomScale*currentScale.x, randomScale*currentScale.y, 0), 1f)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
