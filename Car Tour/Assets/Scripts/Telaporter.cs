using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telaporter : MonoBehaviour
{
    public string m_Trigger;
    private bool m_HeldTrigger;

    public Transform[] controlPoints;
    public LineRenderer lineRenderer;
    public RaycastHit m_hit;

    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 15;
    // Start is called before the first frame update
    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.sortingLayerID = layerOrder;
        curveCount = (int)controlPoints.Length / 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(m_Trigger) > 0.5f && !m_HeldTrigger)
        {
            m_HeldTrigger = true;
        }
        if (Input.GetAxis(m_Trigger) < 0.5f && m_HeldTrigger)
        {
            m_HeldTrigger = false;
            lineRenderer.enabled = false;
        }
        if(m_HeldTrigger == true)
        {
            if(Physics.Raycast(transform.position, transform.forward, out m_hit))
            {
                lineRenderer.enabled = true;
                controlPoints[0].position = transform.position;
                controlPoints[3].position = m_hit.point;
                Vector3 tempPos = Vector3.Lerp(transform.position, m_hit.point, 0.33f);
                tempPos.y += 0.5f;
                controlPoints[1].position = tempPos;
                tempPos = Vector3.Lerp(transform.position, m_hit.point, 0.66f);
                tempPos.y += 0.5f;
                controlPoints[2].position = tempPos;
                DrawCurve();
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    void DrawCurve()
    {
        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position, controlPoints[nodeIndex + 3].position);
                lineRenderer.SetVertexCount(((j * SEGMENT_COUNT) + i));
                lineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
            }

        }
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}
