using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// using static System.Convert;

public class DataPointSpawner : MonoBehaviour {

	public string testcsv;

	public GameObject UIPanel;

	public GameObject currentSphere;

	public Text rowHeading;
	public Text xCoord;
	public Text yCoord;
	public Text zCoord;
	public Text colorText;

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

	public float scalePosition=0.1f;


	// Use this for initialization
	void Start () {

		datapoints = ParseCSVData.Read(testcsv);

		//Debug.Log(datapoints);

		List<string> columns = new List<string> (datapoints[1].Keys);
		
		//Debug.Log(datapoints.Count);

		// foreach (string column in columns)
		// {
		// 	Debug.Log("Col    " + column);
		// }

		xindexname = columns[xindex];
		yindexname = columns[yindex];
		zindexname = columns[zindex];
		sizeindexname = columns[sizeindex];
		colorindexname = columns[colorindex];


		setAxisLabels();

		for (int i=0; i<datapoints.Count; i++) {

			
			float x_coordinate = Convert.ToSingle(datapoints[i][xindexname]);
			float y_coordinate = Convert.ToSingle(datapoints[i][yindexname]);
			float z_coordinate = Convert.ToSingle(datapoints[i][zindexname]);
			float dataPointSize = Convert.ToSingle(datapoints[i][sizeindexname])/100;
			float dataPointColorCode = Convert.ToSingle(datapoints[i][colorindexname]);

			// Debug.Log(x_coordinate);

			// Debug.Log(color);

			//Debug.Log(x_coordinate + y_coordinate + z_coordinate + color);


			GameObject spawnedChild = Instantiate(pointfordata, new Vector3(x_coordinate, y_coordinate, z_coordinate)*scalePosition, Quaternion.identity);

			spawnedChild.transform.localScale = new Vector3(dataPointSize, dataPointSize, dataPointSize);

			spawnedChild.name = i.ToString();

			if (dataPointColorCode == 0) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.red;
			} else if (dataPointColorCode == 1) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.blue;
			} else if (dataPointColorCode == 2) {
				spawnedChild.GetComponent<Renderer>().material.color = Color.green;
			} else {
				spawnedChild.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
			}
			
			//Debug.Log(spawnedChild.GetComponent<Renderer>().material.color);
			
			spawnedChild.transform.parent = parentSpawner.transform;

		}

		// Instantiate(pointfordata, new Vector3(1,1,1), Quaternion.identity);
		
		
	}

	public void setAxisLabels() {
		GameObject.Find("xLabel").GetComponent<TextMesh>().text = xindexname;
		GameObject.Find("yLabel").GetComponent<TextMesh>().text = yindexname;
		GameObject.Find("zLabel").GetComponent<TextMesh>().text = zindexname;
	}
	
	//Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit)) {
				SphereCollider sc = hit.collider as SphereCollider;
				if (sc != null) {
					currentSphere = sc.gameObject;
					setUIvalues(currentSphere);
					UIPanel.SetActive(true);
					// string new_x = GameObject.Find((Convert.ToInt32(sc.gameObject.name)+1).ToString()).transform.position.x.ToString();
					// Debug.Log(new_x);
				} else {
					UIPanel.SetActive(false);
				}
			}
		}
		
	}

	public void rightButtonUI() {
		currentSphere = GameObject.Find((Convert.ToInt32(currentSphere.name)+1).ToString());
		setUIvalues (currentSphere);
	}

	public void leftButtonUI() {
		currentSphere = GameObject.Find((Convert.ToInt32(currentSphere.name)-1).ToString());
		setUIvalues (currentSphere);
	}

	public void setUIvalues(GameObject dataSphere) {
		rowHeading.text = "Row Number:  " + dataSphere.name;
		xCoord.text = "X-Coordinate:  " + dataSphere.transform.position.x.ToString();
		yCoord.text = "Y-Coordinate:  " + dataSphere.transform.position.y.ToString();
		zCoord.text = "Z-Coordinate:  " + dataSphere.transform.position.z.ToString();
		colorText.text = "Color:  " + ((dataSphere.GetComponent<Renderer>().material.color == Color.green)?"Green":((dataSphere.GetComponent<Renderer>().material.color == Color.blue)?"Blue":"Red"));
	}
}
