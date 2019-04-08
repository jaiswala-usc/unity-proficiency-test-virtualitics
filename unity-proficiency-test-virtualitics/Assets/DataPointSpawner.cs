using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPointSpawner : MonoBehaviour {

	public string testcsv;

	private List<Dictionary<string, object>> datapoints;

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
		
	}
	
	// Update is called once per frame
	// void Update () {
		
	// }
}
