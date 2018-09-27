using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    public GameObject rightController;
    public GameObject linePrefabs;
    private GameObject linePrefab;
    
    public float lineWidth = 0.03f;

    public float Max_width;
    public float Min_width;

    private bool pressing = false;
    private LineRenderer lr;
    private List<Vector3> verts = new List<Vector3>();

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        float RI = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        bool clearA = OVRInput.GetDown(OVRInput.Button.One);
        bool undoX = OVRInput.GetDown(OVRInput.RawButton.X);
        if (pressing == false && clearA == true)
        {
            Debug.Log("clear all");
            GameObject[] delete = GameObject.FindGameObjectsWithTag("Dynamic_Line");
            int deleteCount = delete.Length;//.Length();
            for (int i = deleteCount - 1; i >= 0; i--)
                Destroy(delete[i]);
            
        }

        if (pressing == false && undoX == true)
        {
            GameObject[] delete = GameObject.FindGameObjectsWithTag("Dynamic_Line");
            int deleteCount = delete.Length;//.Length();
            if(deleteCount > 0)
                Destroy(delete[deleteCount - 1]);
        }
        

        if (pressing == false && RI > 0)
        {
            pressing = true;
            linePrefab = GameObject.Instantiate(linePrefabs) as GameObject;

            lr = linePrefab.GetComponent<LineRenderer>();

            Renderer rend;
            rend = rightController.GetComponent<Renderer>();

            lr.material.color = rend.material.color;
            lr.SetWidth(lineWidth, lineWidth);
            lr.SetVertexCount(0);
            lr.sortingLayerName = "ForeGround";
            lr.sortingOrder = 2000;
            
            /* linePrefab.c1 = c1;
             linePrefab.c2 = c2;
             linePrefab.lineWidth = lineWidth;
             */
        }

        if (pressing == true && RI == 0)
        {
            pressing = false;
            verts.Clear();
        }


        if (pressing == true && RI > 0)
        {
            Vector3 pos = rightController.transform.position;
            if (verts.Count == 0 || verts[verts.Count - 1] != pos)
                verts.Add(pos);

            lr.SetVertexCount(verts.Count);
            lr.SetPositions(verts.ToArray());
        }

        if (pressing == false)
        {
            float moveHOrizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveVertical > 0 && lineWidth < Max_width)
            {
                lineWidth += 0.001f;
                rightController.gameObject.transform.localScale = new Vector3(lineWidth, lineWidth, lineWidth);
            }

            if (moveVertical < 0 && lineWidth > Min_width)
            {
                lineWidth -= 0.001f;
                rightController.gameObject.transform.localScale = new Vector3(lineWidth, lineWidth, lineWidth);
            }
        }

    }
}
