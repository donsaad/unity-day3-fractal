using UnityEngine;
public class Fractal : MonoBehaviour
{
    [SerializeField]
    GameObject childPrefab;
    GameObject child;
    [SerializeField, Range(1, 5)]
    int depth = 3;
    void Start()
    {
        if (depth <= 1) // stopping condition
        {
            return;
        }
        //childPrefab.transform.localScale = transform.localScale * 0.7f;
        child = Instantiate(childPrefab, transform);
        child.transform.localPosition = 0.75f * Vector3.right;
        child.transform.localScale = Vector3.one * 0.5f;
        child.AddComponent<Fractal>().childPrefab = childPrefab;
        child.GetComponent<Fractal>().depth = depth - 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        //    childPrefab.transform.localScale = transform.localScale * 0.7f;
        //    child = Instantiate(childPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity, transform);
          //  child.AddComponent<Fractal>();
        }
    }
}
