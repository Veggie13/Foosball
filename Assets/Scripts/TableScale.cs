using System.Collections;
using System.Collections.Generic;
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

            foreach (Transform manTransform in childTransform)
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
