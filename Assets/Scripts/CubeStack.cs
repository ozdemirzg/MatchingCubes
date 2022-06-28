using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeStack : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro m_TextMeshPro=null;
    public Transform stackParent;

    private Vector3 newPos;

    [SerializeField] public List<GameObject> cubes = new List<GameObject>();
    private void Update()
    {
        CountCubeText();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
       
            Transform Cube = other.transform.parent;
            Cube.gameObject.layer = LayerMask.NameToLayer("CubeStacked");
            other.gameObject.layer = LayerMask.NameToLayer("CubeStacked");

            newPos = stackParent.localPosition;
            newPos.x = 0;
            newPos.y += 1;
            newPos.z = 0;
            stackParent.localPosition = newPos;

            //Put cubes as a child
            Cube.SetParent(stackParent);
            newPos.y *= -1;
            Cube.localPosition= newPos;
            Cube.localRotation=Quaternion.identity;

            //Add list
            cubes.Add(other.gameObject);

        }

    }
    private void CountCubeText()
    {
        m_TextMeshPro.text = cubes.Count.ToString();
    }
}
