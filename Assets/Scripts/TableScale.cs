using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TableScale : MonoBehaviour {
    public float TableLength;
    public float TableWidth;
    public float TableDepth;
    public float BarHeightPortion;
    public float ManLength;

	// Use this for initialization
	void Start () {
        var cabinet = GameObject.Find("Cabinet");
        var bars = GameObject.Find("Bars");

        cabinet.transform.localScale = new Vector3(TableLength, TableDepth, TableWidth);

        var barsPosition = bars.transform.localPosition;
        barsPosition.y = BarHeightPortion * TableDepth;
        bars.transform.localPosition = barsPosition;

        var barsScale = bars.transform.localScale;
        barsScale.z = TableWidth;
        bars.transform.localScale = barsScale;

        foreach (Transform childTransform in bars.transform)
        {
            var child = childTransform.gameObject;
            var childPosition = childTransform.localPosition;
            childPosition.x *= TableLength;
            childTransform.localPosition = childPosition;

            var men = GameObject.Find(child.name + "Men");
            if (men == null) continue;
            men.transform.position = childTransform.position;
            var menScale = men.transform.localScale;
            menScale.z = TableWidth;
            men.transform.localScale = menScale;
            var menHinge = men.GetComponent<HingeJoint>();
            menHinge.autoConfigureConnectedAnchor = false;
            menHinge.connectedAnchor = Vector3.zero;
            foreach (Transform manTransform in men.transform)
            {
                if (manTransform.gameObject.name.EndsWith("Rod")) continue;
                var manScale = manTransform.localScale;
                manScale.y = ManLength;
                manTransform.localScale = manScale;

                var manPosition = manTransform.localPosition;
                manPosition.y = 0.015f - ManLength / 2f;
                manTransform.localPosition = manPosition;
            }
        }
	}

}
