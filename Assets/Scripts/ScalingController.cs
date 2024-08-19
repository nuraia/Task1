using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScalingController : MonoBehaviour
{
    public List<GameObject> Cubes = new List<GameObject>();
    public Vector3 originalScale = new();
    public Vector3 tragetedScale = new Vector3(2, 2, 2);
    public float scalingTime;
    public int index;
    public bool Clockwise;
    int totalloop= 2;
    int remainningloop = 0;
    private void Start()
    {
        if (Clockwise) index = 0;
        else index = Cubes.Count;
      
        originalScale = transform.localScale;
        ModifyScale(index);
        remainningloop++;
    }

    
    void ModifyScale(int index)
    {
        if (remainningloop / Cubes.Count >= totalloop)  return;
        GameObject currentCube = Cubes[index % Cubes.Count];
        currentCube.transform.DOScale(tragetedScale, scalingTime)
            .OnComplete(() =>
            {
                Debug.Log("Scaled Up");
                currentCube.transform.DOScale(originalScale, scalingTime).
                OnComplete(() =>
                {
                    Debug.Log("Scaled Down");
                    if (Clockwise) index = index + 1;
                    else index = index - 1;
                   
                    var nextIndex = (index % Cubes.Count + Cubes.Count) % Cubes.Count;
                    ModifyScale(nextIndex);
                    remainningloop++;
                });
            });
    }
}