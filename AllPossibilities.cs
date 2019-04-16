using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPossibilities : MonoBehaviour {

    public int points;
    public Line Ln;
    [SerializeField]
    List<Vector3> Positions = new List<Vector3>();
    [SerializeField]
    List<int> allPoints = new List<int>();
    int largestI = -1;
    int largestJ = -1;
    bool runLoop;
    [SerializeField]
    int loopCounter;
    [SerializeField]
    int endLoop = 1;
    [SerializeField]
    float Percentage = 0f;
    [SerializeField]
    float couter;

    // Use this for initialization
    void Start () {

        Application.targetFrameRate = 300;

        loopCounter = 0;

        runLoop = true;
        Ln = this.gameObject.GetComponent<Line>();
        points = 10;

        for (int i = 1; i <= points; i++)
        {
            endLoop *= i;
        }

        for (int i = 0; i < points; i++)
        {
            Positions.Add(Ln.positions[i]);
            allPoints.Add(i);
        }
        

    }
	
	// Update is called once per frame
	void Update () {

        if (loopCounter < endLoop - 1) {
            for (int i = 0; i < allPoints.Count - 1; i++)
            {
                if (allPoints[i] < allPoints[i + 1])
                {
                    largestI = i;
                }
            }
            for (int j = 0; j < allPoints.Count; j++)
            {
                if (allPoints[largestI] < allPoints[j])
                {
                    largestJ = j; 
                }
            }

            Swap(largestI, largestJ);
;
            allPoints.Reverse(largestI + 1, allPoints.Count - largestI - 1);

            loopCounter += 1;
           
            float s = ((float)loopCounter + 1f) / endLoop * 100; 
            Percentage = s;
            couter += Time.deltaTime;
        }  
	}

    void Swap(int i, int j)
    {
        var temp = allPoints[i];
        allPoints[i] = allPoints[j];
        allPoints[j] = temp;
    }

}
