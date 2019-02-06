using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit2D
{
    public class GameManager : MonoBehaviour
    {
        public float winLength = 200;
        public float length = 0;
        public Transform start;
        public LevelSpawner levelSpawner;

        //****************UI****************//
        public GameObject uCanvas;
        public Image uBackgroung;

        public Sprite win;
        public Sprite lose;
        //****************UI****************//
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            length = start.position.y - PlayerCharacter.PlayerInstance.transform.position.y > 0 ?
                start.position.y - PlayerCharacter.PlayerInstance.transform.position.y : 0;
            if (length > winLength)
            {
                GameWin();
            }
        }

        public void StartGame()
        {
            uCanvas.SetActive(false);
            PlayerCharacter.PlayerInstance.Respawn(true, false);
            length = 0;
            levelSpawner.ResetLevelSpawner();
            Time.timeScale = 1;
        }

        public void GameWin()
        {
            uBackgroung.sprite = win;
            uCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        public void GameLose()
        {
            uBackgroung.sprite = lose;
            uCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }

}