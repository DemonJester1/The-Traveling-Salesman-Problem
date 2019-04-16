using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vt : MonoBehaviour {

    public Vector3[] positions;
    public Line Ln;
    private Vector3 center;
    private int points;
    float centerx;
    float centery;
    private List<float> centerDistance = new List<float>();
    private List<float> centerAngle = new List<float>();



    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {

        points = Ln.points;
        positions = new Vector3[points];

        for (int i = 0; i < points; i++)
        {
            positions[i] = Ln.positions[i];
        }

        for (int i = 0; i < Ln.points; i++)
        {
            centerx += positions[i].x;
            centery += positions[i].y;

            //Debug.Log(centerx);
            //Debug.Log(centery);
        }

        center = new Vector3(centerx / points, centery / points, 0);

        transform.position = center;

        Debug.Log(center);


        for (int i = 0; i < positions.Length; i++)
        {
            float d = Vector3.Distance(center, positions[i]);
            centerDistance.Add(d);
            Debug.Log(d);

            float a = Vector3.Angle(center, positions[i]);
            centerAngle.Add(a);
            Debug.Log(a);

            Debug.Log(i);

        }

        for (int i = 0;i < centerAngle.Count; i ++)
        {
            Debug.Log(centerAngle[i]);
        }

       
    }
	
	// Update is called once per frame
	void Update () {

        

	}
}
