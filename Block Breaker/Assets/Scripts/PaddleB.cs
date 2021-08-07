using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleB : MonoBehaviour
{
    // configration paramaters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    //cached refrences
    GameStatus theGameStatus;
    BallM theBall;
    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<BallM>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
