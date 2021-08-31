using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject line;
    public KeyCode key; // 입력 버튼
    public GameObject n; // createMode에서 생성될 노트

    private bool isActive = false; // 판정선에 닿았는지 체크
    private GameObject note; // 노트

	void Update () {
        if (GameManager.instance.createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                line.SetActive(true);
            }

            if (Input.GetKeyUp(key))
            {
                line.SetActive(false);
            }

            if (Input.GetKeyDown(key) && isActive)
            {
                Destroy(note);
                GameManager.instance.AddScore();
                GameManager.instance.AddCombo();
                isActive = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;

        if (other.gameObject.tag == "Note")
        {
            note = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isActive = false;
    }
}
