using UnityEngine;
public class FractalThing : MonoBehaviour
{
    [SerializeField]
    GameObject childPrefab;
    GameObject child;
    [SerializeField, Range(1, 10)]
    int depth = 3;
    [SerializeField]
    bool isRotating = true;
    void Start()
    {
        if (depth <= 1) // stopping condition
        {
            return;
        }
        //childPrefab.transform.localScale = transform.localScale * 0.7f;
        CreateChildren(Vector3.up);
        CreateChildren(Vector3.down);
        CreateChildren(Vector3.right);
        CreateChildren(Vector3.left);
        CreateChildren(Vector3.forward);
        CreateChildren(Vector3.back);

    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0f, 10.0f * Time.deltaTime, 0f);
        }
    }
    void CreateChildren(Vector3 direction)
    {
        child = Instantiate(childPrefab, transform);
        child.transform.localPosition = 0.75f * direction; // snape child to its parent
        child.transform.localScale = Vector3.one * 0.5f;
        child.AddComponent<FractalThing>().childPrefab = childPrefab;
        child.GetComponent<FractalThing>().depth = depth - 1;
    }
}
