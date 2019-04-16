using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Line : MonoBehaviour {

    private LineRenderer LR;
    public int points;
    private int totaldistances;
    public Vector3[] positions;
    private List<float> totaldistance = new List<float>();
    private List<Vector4> pointList = new List<Vector4>();
    string path;
    List<float> intValues = new List<float>();


    // Use this for initialization
    private void Awake()
    {
        points = 5000;

        path = @"c:\temp\pointsData.txt";



        using (StreamReader sr = File.OpenText(path)) {
            string text = sr.ReadToEnd();
            char[] separators = { ',', ';', '|', '[', ']' };
            string[] strValues = text.Split(separators);

            for (int i = 0; i < strValues.Length; i ++) {
                Debug.Log(strValues[i]);
            }
            foreach (string str in strValues)
            {
                float val = 0;
                if (float.TryParse(str, out val))
                {
                    intValues.Add(val);
                }
            }
        }
        positions = new Vector3[points];
        for (int i = 0; i < intValues.Count/2 ; i ++)
        {
            positions[i] = new Vector3(intValues[2*i],intValues[2*i + 1],0);
        }

       /* positions[0] = new Vector3(3f,3f,0);
        positions[1] = new Vector3(3f, -3f, 0);
        positions[2] = new Vector3(-3f, -3f, 0);
        positions[3] = new Vector3(-3f, 3f, 0);
        positions[4] = new Vector3(-3f, 6f, 0);*/

    }
    void Start () {

        LR = this.gameObject.GetComponent<LineRenderer>();

        LR.material = new Material(Shader.Find("Sprites/Default"));

        LR.SetWidth(0.01f,0.01f);
       
        LR.positionCount = positions.Length;
        LR.SetPositions(positions);

        for (int i = 1; i < 5; i ++)
        {
            for (int j = 1; j < 5; j++)
            {   if (i != j)
                {
                    for (int k = 1; k < 5; k++)
                    {
                        if (j != k && k != i)
                            for (int l = 1; l < 5; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    totaldistance.Add(Vector3.Distance(positions[0], positions[i]) + Vector3.Distance(positions[i], positions[j]) + Vector3.Distance(positions[j], positions[k]) + Vector3.Distance(positions[k], positions[l]));
                                    Vector4 point = new Vector4(i,j,k,l);
                                    pointList.Add(point);                                  
                                }

                            }
                    }
                }
            }
        }

        for (int i = 0; i < pointList.Count; i++)
        {
           // Debug.Log(pointList[i]);
        }
        totaldistance.Sort();
        for (int i = 0;i < totaldistance.Count;i ++)
        {
            //Debug.Log(totaldistance[i]);
        }

    
     

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
