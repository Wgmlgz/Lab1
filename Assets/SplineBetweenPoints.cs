using UnityEngine;
using UnityEngine.Splines;

public class SplineBetweenPoints : MonoBehaviour
{
    public Transform obj1;
    public Transform obj2;
    public SplineContainer splineObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        splineObj.Spline.SetKnot(0, new BezierKnot(obj1.transform.position - obj1.transform.position));
        splineObj.Spline.SetKnot(1, new BezierKnot(obj2.transform.position - obj1.transform.position));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
