using System;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class DotweenSequence : MonoBehaviour
{
    public Transform target;
    public Image logoImage;
    public Image cloudImage;
    public int resultNum;
    public Image[] resultImages;
    public Button backButton;
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
        buttons[0].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);
                    
                    LadderLinerenderer.SetActive(true);
                    
                    Generate(textObjects1);
                    resultNum = 1;
                });
           
        });
        
        buttons[1].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

                    Generate(textObjects2);
                    resultNum = 2;
                });
        });
        
        buttons[2].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

            Generate(textObjects3);
            resultNum = 3;
                });
            
            
        });
        
        buttons[3].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

                    Generate(textObjects4);
                    resultNum = 4;
                });
        });
        buttons[4].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

                    Generate(textObjects5);
                    resultNum = 5;
                });
        });
        buttons[5].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

                    Generate(textObjects6);
                    resultNum = 6;
                });
        });
        buttons[6].onClick.AddListener(() =>
        {
        
            foreach (var button in buttons)
            {
                button.enabled = false;
            }

            cloudImage.DOFade(0f, 1f)
                .OnComplete(() =>
                {
                    cloudImage.gameObject.SetActive(false);

                    LadderLinerenderer.SetActive(true);

                    Generate(textObjects7);
                    resultNum = 7;
                });
        });
    }

    private void Generate(TextMeshPro[] textObjects)
    {
        logoImage.enabled = true;
        
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
            lineRenderers[index].positionCount = 2;
            lineRenderers[index].SetPosition(0, textObjects[index].transform.position);
            lineRenderers[index].SetPosition(1, textObjects[index].transform.position);
            target.position = lineRenderers[index].GetPosition(1);
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
            
            sequence.OnComplete(() =>
            {
                Invoke("ResultImage", 1f);
            });
        }
    }
    
   void ResultImage()
    {
        logoImage.enabled = false;
        LadderLinerenderer.SetActive(false);
        DrawLinerenderer.SetActive(false);
        
        switch (resultNum)
        {
            case 1:
                resultImages[0].gameObject.SetActive(true);
                break;
            case 2:
                resultImages[1].gameObject.SetActive(true);
                break;
            case 3:
                resultImages[2].gameObject.SetActive(true);
                break;
            case 4:
                resultImages[3].gameObject.SetActive(true);
                break;
            case 5:
                resultImages[4].gameObject.SetActive(true);
                break;
            case 6:
                resultImages[5].gameObject.SetActive(true);
                break;
            case 7:
                resultImages[6].gameObject.SetActive(true);
                break;
        }
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
