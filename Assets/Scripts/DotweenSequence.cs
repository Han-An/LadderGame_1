using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;

public class DotweenSequence : MonoBehaviour
{
    public Transform target;
    public LineRenderer[] lineRenderers;
    public TextMeshPro[] textObjects;
    public float speed;
    
    void Start()
    {
        foreach (var line in lineRenderers)
        {
            line.gameObject.SetActive(false);
        }
        Init(0);
        
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < textObjects.Length-1; i++)
        {
            Draw(i);
        }
        
        sequence.Play();
        
        void Init (int index)
        {
            lineRenderers[index].gameObject.SetActive(true);
            lineRenderers[index].SetPosition(0, textObjects[index].transform.position);
            lineRenderers[index].SetPosition(1, textObjects[index].transform.position);
        }

        void Draw(int index)
        {
            float duration = Vector3.Distance(textObjects[index].transform.position, textObjects[index + 1].transform.position) / speed;
            sequence.Append(DOTween.To(
                () => lineRenderers[index].GetPosition(1), x => lineRenderers[index].SetPosition(1, x), textObjects[index + 1].transform.position, duration)
                .SetEase(Ease.Linear));
            sequence.AppendCallback(() =>
            {
                Init(index + 1);
            });
        }
    }
    
    void Update()
    {
        
    }
    
   
}
