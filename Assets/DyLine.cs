using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Change color from 
 * 
 * 
 * 
 * 
 * 
 * 
 * */

namespace VRPaint{
	
	public class DyLine : MonoBehaviour {

        // Use this for initialization
		public Color c1 = Color.yellow;
		public Color c2 = Color.green;
		public float lineWidth = 0.03f;
		//public GameObject rightController;

		private List<Vector3> verts = new List<Vector3>();
		//private bool pressing = false;

		private LineRenderer lr;

		void Start () {
			lr = gameObject.AddComponent<LineRenderer> ();
            lr.material.color = c2;
			lr.SetWidth (lineWidth,lineWidth);
			lr.SetVertexCount (0);
			lr.sortingLayerName = "ForeGround";
			lr.sortingOrder = 2000;
		}

        void addpoint(Vector3 pos)
        {
            if (verts.Count == 0 || verts[verts.Count - 1] != pos)
                verts.Add(pos);
        }

		// Update is called once per frame
		void Update () {
            
            /*
			float RI= OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
            //Debug.Log ("update" + RI);
            bool clearA = OVRInput.GetDown(OVRInput.Button.One);
            bool colorX = OVRInput.GetDown(OVRInput.RawButton.X);
            if (pressing == false && clearA == true)
            {
                verts.Clear();
            }
            

            if (colorX == true)
            {
                lr.material.color = c1;
            }
            
            if (pressing == false && RI > 0)
            {
                pressing = true;
            }
            if (pressing == true && RI == 0)
            {
                pressing = false;
            }
                
            
            if (pressing == true && RI > 0)
            {
                Vector3 pos = rightController.transform.position;
                if (verts.Count == 0 || verts[verts.Count - 1] != pos)
                    verts.Add(pos);
            }
            */
            /*
			if (verts.Count > 1) {
				lr.SetVertexCount (verts.Count);
				lr.SetPositions (verts.ToArray());
			}*/
            lr.SetVertexCount(verts.Count);
            lr.SetPositions(verts.ToArray());
        }
	}
}