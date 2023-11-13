using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOutliner : MonoBehaviour
{
    [SerializeField] private GameObject _slime = null;
    void Start()
    {
        _slime.GetComponent<Outline>().enabled = true;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.transform.gameObject.tag == "Slime")
            {
                Debug.Log("fddsfd");
                _slime = hit.transform.gameObject;
                _slime.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Debug.Log("18998");
                _slime.GetComponent<Outline>().enabled = false;
                _slime = null;
            }
        }
    }

        void Outlining()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.Log("c");
            if (hit.transform.gameObject.tag == "Slime")
            {
                Debug.Log("a");
                _slime = hit.transform.gameObject;
                _slime.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Debug.Log("b");
                _slime.GetComponent<Outline>().enabled = false;
                _slime = null;
            }
            Debug.Log(_slime.name);
        }
    }
}
