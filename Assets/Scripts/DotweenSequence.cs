using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class DotweenSequence : MonoBehaviour
{
    public Transform target;
    public Image logoImage;
    public int resultNum;
    public Image[] resultImages;
    public LineRenderer[] lineRenderers;
    public TextMeshPro[] textObjects1;
    public TextMeshPro[] textObjects2;
    public TextMeshPro[] textObjects3;
    public TextMeshPro[] textObjects4;
    public TextMeshPro[] textObjects5;
    public TextMeshPro[] textObjects6;
    public TextMeshPro[] textObjects7;
    public GameObject LadderLinerenderer;
    public GameObject DrawLinerenderer;


    
    public float speed;
    public Button[] buttons;
    
    void Start()
    {
        LadderLinerenderer.SetActive(true);
        
        buttons[0].onClick.AddListener(() =>
        {
            Generate(textObjects1);
            resultNum = 1;
        });
        
        buttons[1].onClick.AddListener(() =>
        {
            Generate(textObjects2);
            resultNum = 2;
        });
        
        buttons[2].onClick.AddListener(() =>
        {
            Generate(textObjects3);
            resultNum = 3;
        });
        
        buttons[3].onClick.AddListener(() =>
        {
            Generate(textObjects4);
            resultNum = 4;
        });
        buttons[4].onClick.AddListener(() =>
        {
            Generate(textObjects5);
            resultNum = 5;
        });
        buttons[5].onClick.AddListener(() =>
        {
            Generate(textObjects6);
            resultNum = 6;
        });
        buttons[6].onClick.AddListener(() =>
        {
            Generate(textObjects7);
            resultNum = 7;
        });
    }

    private void Generate(TextMeshPro[] textObjects)
    {
        foreach (var button in buttons)
        {
            logoImage.enabled = true;
            button.enabled = false;
        }
        
        
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
                .SetEase(Ease.Linear).OnUpdate(() => 
                    target.position = lineRenderers[index].GetPosition(1))
            );
            sequence.AppendCallback(() =>
            {
                Init(index + 1);
            });
            
            sequence.OnComplete(() => ResultImage());
        }
    }
    
   void ResultImage()
    {
        logoImage.enabled = false;
        LadderLinerenderer.SetActive(false);
        DrawLinerenderer.SetActive(false);
        Debug.Log("Result Image");
        
        
        switch (resultNum)
        {
            case 1:
                resultImages[0].enabled = true;
                Debug.Log("Result 1");
                break;
            case 2:
                resultImages[1].enabled = true;
                Debug.Log("Result 2");
                break;
            case 3:
                resultImages[2].enabled = true;
                Debug.Log("Result 3");
                break;
            case 4:
                resultImages[3].enabled = true;
                Debug.Log("Result 4");
                break;
            case 5:
                resultImages[4].enabled = true;
                Debug.Log("Result 5");
                break;
            case 6:
                resultImages[5].enabled = true;
                Debug.Log("Result 6");
                break;
            case 7:
                resultImages[6].enabled = true;
                Debug.Log("Result 7");
                break;
        }
    }
   
}
