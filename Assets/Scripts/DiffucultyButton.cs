using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int diffuculty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDiffuclty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDiffuclty()
    {
        Debug.Log(gameObject.name + " clicked");
        gameManager.StartGame(diffuculty);    

    }
}
