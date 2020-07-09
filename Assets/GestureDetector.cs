using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[System.Serializable]
public class GestureDetector : MonoBehaviour
{

    public List<Vector3> leftHandSkeletonPos;
    public List<Vector3> rightHandSkeletonPos;

    [SerializeField]
    public List<List<Vector3>> leftGestures;

    [System.Serializable]
    public struct Gesture
    {
        public string Name;
        public List<Vector3> fingerPositions;
    }

    // Update is called once per frame
    public void Update()
    {
        //left hand
        try
        {
            leftHandSkeletonPos.Clear();
            GameObject leftHand = GameObject.Find("RigidRoundHand_L");
            for (int i = 0; i < 5; i++)
            {
                Transform fingerGroup = leftHand.transform.GetChild(i);
                         
                for (int j = 0; j < 3; j++)
                {
                    leftHandSkeletonPos.Add(fingerGroup.transform.GetChild(j).transform.position);
                }
            }
        }
        catch
        {}

        //right hand
        try
        {
            rightHandSkeletonPos.Clear();
            GameObject leftHand = GameObject.Find("RigidRoundHand_R");
            for (int i = 0; i < 5; i++)
            {
                Transform fingerGroup = leftHand.transform.GetChild(i);

                for (int j = 0; j < 3; j++)
                {
                    rightHandSkeletonPos.Add(fingerGroup.transform.GetChild(j).transform.position);
                }
            }
        }
        catch
        { }

        //Save gesture for left hand
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveLeftGesture();
        }
    }

    public void SaveLeftGesture()
    {
        Gesture tempGesture = new Gesture();
        List<Vector3> tempPositions = new List<Vector3>();

        GameObject leftHand = GameObject.Find("RigidRoundHand_L");
        for (int i = 0; i < 5; i++)
        {
            Transform fingerGroup = leftHand.transform.GetChild(i);

            for (int j = 0; j < 3; j++)
            {
                tempPositions.Add(fingerGroup.transform.GetChild(j).transform.position);
            }
        }

        tempGesture.Name = "Custom Gesture";
        tempGesture.fingerPositions = tempPositions;

        Debug.Log("yeah boii");
        leftGestures.Add(tempPositions);
    }
}
