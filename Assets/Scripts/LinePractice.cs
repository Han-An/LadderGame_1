using UnityEngine;

public class LinePractice : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        // Line Renderer 컴포넌트 가져오기 (없으면 자동 추가)
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null) lineRenderer = gameObject.AddComponent<LineRenderer>();
        
            // lineRenderer.sortingOrder = 10;
            // lineRenderer.sortingLayerName = "UI";
        
        // 점 개수 설정 (2개의 점으로 선을 그림)
        lineRenderer.positionCount = 2;

        // 선의 시작과 끝 점 설정
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));  // 첫 번째 점
        lineRenderer.SetPosition(1, new Vector3(1, 1, 0));  // 두 번째 점

        // 선의 두께 설정
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;

        // 색상 설정
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.yellow;
    }
}
