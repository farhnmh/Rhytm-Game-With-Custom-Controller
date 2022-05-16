using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameManager game;
    public int blockIdentity;
    public float moveSpeed;
    public bool isHover;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isPlay)
            this.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (isHover)
        {
            if (game.guitarPlucked && game.redPushed && blockIdentity == 0)
            {
                Destroy(this.gameObject);
                game.totalScore += 1;
            }

            if (game.guitarPlucked && game.bluePushed && blockIdentity == 1)
            {
                Destroy(this.gameObject);
                game.totalScore += 1;
            }

            if (game.guitarPlucked && game.greenPushed && blockIdentity == 2)
            {
                Destroy(this.gameObject);
                game.totalScore += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            isHover = true;
        }

        if (other.gameObject.tag == "BlockMargin")
        {
            Destroy(this.gameObject);
            game.isPlay = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            isHover = false;
        }
    }
}
