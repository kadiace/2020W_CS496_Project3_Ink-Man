using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPolygon : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public PolygonCollider2D polyGonCollider;
    public Rigidbody2D polygonrigidbody2D;
    public List<Vector2> fingerPositions;
    public PlayerController player;




    public GameObject wholeLine;

    void Start()
    {
        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0.05f && player.inkCartridge.value > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
                {
                    UpdateLine(tempFingerPos);

                    if (player.inkCartridge.value > 0)
                    {
                        player.inkCartridge.value -= 0.1f;
                    }
                    else
                    {
                        player.inkCartridge.value = 0;
                    }
                    
                }
            }
        }
        



        //for (var i = 0; i < lineRenderer.positionCount; i++)
        // {
        //     lineRenderer.SetPosition(i, linerigidbody2D.position + edgeCollider.points[i]);
        // }

    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        polyGonCollider = currentLine.GetComponent<PolygonCollider2D>();
        polygonrigidbody2D = currentLine.GetComponent<Rigidbody2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);



        polyGonCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);

        if (lineRenderer != null)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
            polyGonCollider.points = fingerPositions.ToArray();

            polygonrigidbody2D.centerOfMass = calculateCOM(polyGonCollider);
        }
        



    }

    void applyGravity(List<Vector2> fingerPositions)
    {

    }

    Vector2 calculateCOM(PolygonCollider2D polyGonCollider)
    {
        var com = Vector2.zero;

        for (var i = 0; i < polyGonCollider.points.Length; i++)
        {
            com += polyGonCollider.points[i];
        };

        com /= polyGonCollider.points.Length;

        return com;
    }
}
