using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEq : MonoBehaviour {

    public Vector3[] positions;
    public Line Ln;
    public int points;
    private List<float> totaldistance = new List<float>();
    private List<float> totaldistance2 = new List<float>();
    private List<float> totaldistance3 = new List<float>();
  //  private List<Vector2> pointList1 = new List<Vector2>();
  //  private List<Vector2> pointList2 = new List<Vector2>();
    private List<float> pointList3 = new List<float>();

    int width;
    int height;
    int[,] grid;
    private int h = 0;

    int width1;
    int height1;
    int[,] grid1;
    private int h1 = 0;

    // Use this for initialization
    private void Awake()
    {

        Ln = this.gameObject.GetComponent<Line>();
        height = 12;
        width = 2;
        grid = new int[width,height];

        height1 = 12;
        width1 = 2;
        grid1 = new int[width1, height1];

    }

    void Start () {

        points = Ln.points;
        positions = new Vector3[points];

        for (int i = 0; i < points; i++)
        {
            positions[i] = Ln.positions[i];
        }

        for (int i = 1; i < 5; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                if (i != j)
                {
                    totaldistance.Add(Vector3.Distance(positions[0], positions[i]) + Vector3.Distance(positions[i], positions[j]));
                    grid[0, h] = i;
                    grid[1, h] = j;

                    h += 1;

                   // Vector2 point = new Vector2(i, j);
                   // pointList1.Add(point);
                }
            }
        }

        for (int i = 1; i < 5; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                if (i != j)
                    for (int k = 1; k < 5; k++)
                    {
                    if (k != j && k != i)
                        {
                            totaldistance2.Add(Vector3.Distance(positions[i], positions[j]) + Vector3.Distance(positions[j], positions[k]));
                            grid1[0, h1] = i;
                            grid1[1, h1] = j;
                          //  Debug.Log(h1);
                            Debug.Log(i);
                            Debug.Log(j);
                           // h1 += 1;
                           
                        //Vector2 point = new Vector2(j, k);
                        // pointList2.Add(point);
                        }
                    }
            }
        }


       /* for (int i = 0; i < pointList1.Count; i++)
        {
            Debug.Log(pointList1[i]);
        }*/
        
        for (int i = 0; i < totaldistance.Count; i++)
        {
            Debug.Log(totaldistance[i]);
        }
        /*for (int i = 0; i < pointList2.Count; i++)
        {
            Debug.Log(pointList2[i]);
        }*/

        for (int i = 0; i < totaldistance2.Count; i++)
        {
            Debug.Log(totaldistance2[i]);
        }

        /*  for (int i = 0;i < pointList1.Count; i ++)
          {
              float sum = (pointList1[i].x + pointList1[i].y + pointList2[i].x + pointList2[i].y);
              Debug.Log(sum);
              if (sum == 10)
              {
                  pointList3.Add(sum);
                  //totaldistance2.Add(Vector3.Distance(positions[0], positions[pointList1[i].x]) + Vector3.Distance(positions[pointList1[i].x], positions[pointList1[i].y]) + Vector3.Distance(positions[pointList1[i].y], positions[pointList2[i].x]) + Vector3.Distance(positions[pointList2[i].x], positions[pointList2[i].y]));
                  Debug.Log(pointList1[i].x);
                  Debug.Log(pointList1[i].y);
                  Debug.Log(pointList2[i].x);
                  Debug.Log(pointList2[i].y);

              }
          }*/

        for (int x = 0; x < width; x ++)
        {
            for (int y = 0; y < height; y ++)
            {
                Debug.Log(grid[x,y]);
            }
        }

        for (int i = 0; i < pointList3.Count; i++)
        {
            Debug.Log(pointList3[i]);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
