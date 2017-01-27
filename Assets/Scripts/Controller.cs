using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public string TablePlayer;
    public string ControllerName;

    //const float Extent1Bar;
    //const float Extent2Bar;
    //const float Extent5Bar;
    //const float Extent3Bar;

    GameObject _1bar;
    GameObject _2bar;
    GameObject _5bar;
    GameObject _3bar;

    GameObject[] _bars;

    int _left, _right;

	// Use this for initialization
	void Start () {
        _1bar = GameObject.Find(TablePlayer + "1Bar");
        _2bar = GameObject.Find(TablePlayer + "2Bar");
        _5bar = GameObject.Find(TablePlayer + "5Bar");
        _3bar = GameObject.Find(TablePlayer + "3Bar");

        _bars = new[] { _1bar, _2bar, _5bar, _3bar };

        _left = 0;
        _right = 2;
    }

    // Update is called once per frame
    void FixedUpdate () {
        updateBar(_left, "Left");
        updateBar(_right, "Right");
    }

    void updateBar(int bar, string controlName)
    {
        var barPosition = _bars[bar].transform.localPosition;
        barPosition.z = 0.375f * Input.GetAxis(ControllerName + "_" + controlName + "Y");
        _bars[bar].transform.localPosition = barPosition;

        float targetRotation = 90f * Input.GetAxis(ControllerName + "_" + controlName + "X");
        //var barRotation = _bars[bar].transform.localRotation;
        //_bars[bar].
        var men = GameObject.Find(_bars[bar].name + "Men");
        if (men == null) return;
        var menPosition = men.transform.position;
        var joint = men.GetComponent<HingeJoint>();
        if (joint != null)
        {
            var jointSpring = joint.spring;
            jointSpring.targetPosition = targetRotation;
            joint.spring = jointSpring;
        }
        //men.transform.position = menPosition;
        //_bars[bar].transform.rotation = barRotation;
    }
}
