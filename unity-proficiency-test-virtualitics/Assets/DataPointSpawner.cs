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
	public int sizeindex = 3;
	public int colorindex = 4;

	public string xindexname;
	public string yindexname;
	public string zindexname;
	public string sizeindexname;
	public string colorindexname;

	public GameObject pointfordata;

	public GameObject parentSpawner;


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
		sizeindexname = columns[sizeindex];
		colorindexname = columns[colorindex];

		for (int i=0; i<datapoints.Count; i++) {
			float x_coordinate = System.Convert.ToSingle(datapoints[i][xindexname]);
			float y_coordinate = System.Convert.ToSingle(datapoints[i][yindexname]);
			float z_coordinate = System.Convert.ToSingle(datapoints[i][zindexname]);
			float dataPointSize = System.Convert.ToSingle(datapoints[i][sizeindexname])/10;
			float dataPointColorCode = System.Convert.ToSingle(datapoints[i][colorindexname]);

			// Debug.Log(color);

			//Debug.Log(x_coordinate + y_coordinate + z_coordinate + color);


			GameObject spawnedChild = Instantiate(pointfordata, new Vector3(z_coordinate, y_coordinate, z_coordinate), Quaternion.identity);

			spawnedChild.transform.localScale = new Vector3(dataPointSize, dataPointSize, dataPointSize);

			if (dataPointColorCode == 0) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.red;
			} else if (dataPointColorCode == 1) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.blue;
			} else if (dataPointColorCode == 2) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.green;
			} else {
				spawnedChild.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
			}
			
			Debug.Log(spawnedChild.GetComponent<Renderer>().material.color);
			
			spawnedChild.transform.parent = parentSpawner.transform;

		}

		// Instantiate(pointfordata, new Vector3(1,1,1), Quaternion.identity);
		
		
	}
	
	// Update is called once per frame
	// void Update () {
		
	// }
}
