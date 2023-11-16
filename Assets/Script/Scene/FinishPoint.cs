using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        ItemCollector itemCollector = collision.GetComponent<ItemCollector>();

        if (collision.CompareTag("Player"))
        {
            if (itemCollector != null && itemCollector.GetDiamondCount() == 20)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
