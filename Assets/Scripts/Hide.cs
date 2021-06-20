using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public void Bury()
    {
        gameObject.SetActive(false);
    }

    public void slowDelete()
    {
        gameObject.SetActive(true);
        StartCoroutine(DeletePanel());
    }

    IEnumerator DeletePanel()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
