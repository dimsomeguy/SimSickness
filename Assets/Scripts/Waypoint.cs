using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    private GameObject[] WayPointList;
    private Vector3 FirstPoint;
    private Vector3 CurrentPoint;
    private Vector3 LastPoint;
    private float distence;
    private int index;
    public int playerPoint = 0;
    private int totalTransform;
    private Transform TempTrans;
    private GameObject CurrentWaypoint;

	// Use this for initialization
	void Start ()
    {
        GetTransforms();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnDrawGizmos()
    {
        if (WayPointList == null)
        {
            GetTransforms();
        }

        if (WayPointList.Length < 2)
            return;
        TempTrans = WayPointList[0].transform;
        LastPoint = TempTrans.position;

        Transform PointTemp = TempTrans;

        FirstPoint = LastPoint;

        Gizmos.color = new Color(1, 0, 0, 1);

        for (int I = 1; I < WayPointList.Length; I++)
        {
            TempTrans = WayPointList[I].transform;

            CurrentPoint = TempTrans.position;

            Gizmos.DrawLine(LastPoint, CurrentPoint);

            Gizmos.DrawCube(FirstPoint, new Vector3 (2,2,2));

            Gizmos.DrawCube(CurrentPoint, new Vector3(2, 2, 2));

            PointTemp.LookAt(CurrentPoint);

            LastPoint = CurrentPoint;

            PointTemp = WayPointList[I].transform;
        }

        Gizmos.DrawLine(CurrentPoint, FirstPoint);
    }
    void GetTransforms()
    {
        WayPointList = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            WayPointList[i] = this.transform.GetChild(i).gameObject;
        }
        totalTransform = WayPointList.Length;

        WayPointVisable();
    }

    Transform GetWaypoint(int index)
    {
        if (WayPointList == null)
            GetTransforms();

        if (index > WayPointList.Length)
            return null;

        return WayPointList[index].transform;
    }

    int GetTotal()
    {
        return totalTransform;
    }
   public void WayPointVisable()
    {
        if (WayPointList == null)
            GetTransforms();
        if (playerPoint == 0)
        {
            WayPointList[playerPoint].GetComponent<MeshRenderer>().enabled = true;
            WayPointList[playerPoint].GetComponent<BoxCollider>().enabled = true;
            WayPointList[playerPoint].GetComponent<PlayerTrigger>().enabled = true;
        }
        else
        {
            CurrentWaypoint.GetComponent<BoxCollider>().enabled = false;
            CurrentWaypoint.GetComponent<MeshRenderer>().enabled = false;
            CurrentWaypoint.GetComponent<PlayerTrigger>().enabled = false;
            WayPointList[playerPoint].GetComponent<BoxCollider>().enabled = true;
            WayPointList[playerPoint].GetComponent<MeshRenderer>().enabled = true;
            WayPointList[playerPoint].GetComponent<PlayerTrigger>().enabled = true;
        }

        CurrentWaypoint = WayPointList[playerPoint];
    }
}
