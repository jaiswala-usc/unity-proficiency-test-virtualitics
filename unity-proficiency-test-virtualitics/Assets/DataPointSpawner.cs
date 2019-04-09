using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static System.Convert;

public class DataPointSpawner : MonoBehaviour {

	public string testcsv;

	private List<Dictionary<string, object>> datapoints;

	public int xindex = 0;
	public int yindex = 1;
	public int zindex = 2;

	public string xindexname;
	public string yindexname;
	public string zindexname;

	public GameObject pointfordata;


	// Use this for initialization
	void Start () {

		datapoints = ParseCSVData.Read(testcsv);

		Debug.Log(datapoints);

		List<string> columns = new List<string> (datapoints[1].Keys);
		Debug.Log(datapoints.Count);

		foreach (string column in columns)
		{
			Debug.Log("Col" + column);
		}

		xindexname = columns[xindex];
		yindexname = columns[yindex];
		zindexname = columns[zindex];

		for (int i=0; i<datapoints.Count; i++) {
			float x_coordinate = System.Convert.ToSingle(datapoints[i][xindexname]);
			float y_coordinate = System.Convert.ToSingle(datapoints[i][yindexname]);
			float z_coordinate = System.Convert.ToSingle(datapoints[i][zindexname]);


			Instantiate(pointfordata, new Vector3(z_coordinate, y_coordinate, z_coordinate), Quaternion.identity);
		}

		// Instantiate(pointfordata, new Vector3(1,1,1), Quaternion.identity);
		
		
	}
	
	// Update is called once per frame
	// void Update () {
		
	// }
}
