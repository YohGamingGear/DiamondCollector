using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int diamonds = 0;

    [SerializeField] private Text diamondsText;
    [SerializeField] private AudioSource diamondSound;

    public int GetDiamondCount()
    {
        return diamonds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            diamondSound.Play();
            Destroy(collision.gameObject);
            diamonds++;
            diamondsText.text = "" + diamonds;
        }
    }
}
