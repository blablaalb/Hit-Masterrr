using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using Enemy;
using Player;
using Player.Navigation;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private Locomotion _locomotion;
        private int _squadsCount;
        private int _squadsEliminated;
        private static LevelManager _instance;
        public static LevelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("Level Manager");
                    _instance = go.AddComponent(typeof(LevelManager)) as LevelManager;
                }
                return _instance;
            }
        }

        internal void Awake()
        {
            _locomotion = FindObjectOfType<Locomotion>();
            _squadsCount = FindObjectsOfType<Squad>().Length;
        }

        public void OnSquadEliminated(Squad squad)
        {
            _squadsEliminated++;
            if (_squadsEliminated == _squadsCount)
                _locomotion.Dance();
            else
                StartCoroutine(MovePlayerCoroutine());

        }

        private IEnumerator MovePlayerCoroutine()
        {
            yield return new WaitForSeconds(1f);
            _locomotion.Move();
        }

        public void OnLevelPassed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}