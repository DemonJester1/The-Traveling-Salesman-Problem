using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleTheory : MonoBehaviour {

    public int points;
    public Line Ln;
    [SerializeField]
    private Vector3 center;
    float centerx;
    float centery;
    List<Vector3> Positions = new List<Vector3>();
    List<Vector3> Positions1 = new List<Vector3>();
    List<Vector3> EndPositions = new List<Vector3>();
    List<int> allPoints = new List<int>();
    List<int> finalConfig = new List<int>();
    float minD = 0;
    int j = 0;
    [SerializeField]
    float finalDistance;
    bool distanceCalculated;
    private LineRenderer LR;
    [SerializeField]
    float Percentage = 0f;
    [SerializeField]
    float couter;

    // Use this for initialization

    void Start() {

        Application.targetFrameRate = 100000;

        LR = this.gameObject.GetComponent<LineRenderer>();

        Ln = this.gameObject.GetComponent<Line>();
        points = Ln.points;

        for (int i = 0; i < points; i++) {
            Positions.Add(Ln.positions[i]);
            Positions1.Add(Ln.positions[i]);
            allPoints.Add(i);
        }
        
        allPoints.RemoveAt(0);
        finalConfig.Add(0);
        EndPositions.Add(Positions[0]);
        Positions.RemoveAt(0);

        distanceCalculated = false;

        for (int i = 0; i < allPoints.Count; i++)
        {
            centerx += Positions[i].x;
            centery += Positions[i].y;

            //Debug.Log(centerx);
            //Debug.Log(centery);
        }
        center = new Vector3(centerx / points, centery / points, 0);
        
    }

    // Update is called once per frame
    void Update() {

        

        if (allPoints.Count >= 1)
        {
            DefineNextPoint();
          //  CalculateCenter();
            float s = ((float)finalConfig.Count) / points * 100;
            Percentage = s;
            couter += Time.deltaTime;
        }
        if (allPoints.Count == 0 && distanceCalculated == false)
        {
            for (int i = 0;i < EndPositions.Count - 1; i ++)
            {
                finalDistance += Vector3.Distance(EndPositions[i],EndPositions[i + 1]);
                if (i == EndPositions.Count -2)
                {
                    distanceCalculated = true;
                    //finalDistance += Vector3.Distance(EndPositions[EndPositions.Count-1],EndPositions[0]);
                    for (int j = 0; j < EndPositions.Count - 1; j++)
                    {
                        LR.SetPosition(j,EndPositions[j]);
                    }
                }
            }
        }
    }

    void DefineNextPoint()
    {

        for (int i = 0; i < Positions.Count; i++)
        {
           // Debug.Log(i);
                float d;
            //d = Vector3.Distance(center, EndPositions[EndPositions.Count - 1]) + Vector3.Distance(EndPositions[EndPositions.Count - 1], Positions[i]) + Vector3.Distance(Positions[i], center);
            d = Vector3.Distance(Positions[i],EndPositions[EndPositions.Count - 1]);
            if (minD == 0 || minD > d)
                {
                    minD = d;
                    j = i;
                }
            if (i == allPoints.Count - 1)
            {
                finalConfig.Add(allPoints[j]);
                allPoints.RemoveAt(j);
                
                EndPositions.Add(Positions[j]);
                Positions.RemoveAt(j);
                minD = 0;
                j = 0;
            }
            //Debug.Log(minD);
            //Debug.Log(j);
        }
    }

    /*void CalculateCenter()
    {
        centerx = 0;
        centery = 0;

        for (int  i = 0; i < finalConfig.Count; i ++)
        {
            centerx += EndPositions[i].x;
            centery += EndPositions[i].y;
        }
        center = new Vector3(centerx / finalConfig.Count, centery / finalConfig.Count, 0);

    }*/
}
