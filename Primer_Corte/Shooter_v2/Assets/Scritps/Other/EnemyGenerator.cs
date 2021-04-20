using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public  GameObject[] enemiesPrefabs;
    public  Transform[]  generatingPlaces;
    public  float        generationTime = 5f;
    public  int          numberEnemiesTeams;
    private int          _countEnemies;
    
    void Start() {
        generatingPlaces = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            generatingPlaces[i] = transform.GetChild(i);
        }
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy() {
        while (true) {
            for (int i = 0; i < generatingPlaces.Length; i++) {
                Transform generatingPlace = generatingPlaces[i];
                for (int j = 0; j < enemiesPrefabs.Length; j++) {
                    GameObject zombiePrefab = enemiesPrefabs[j];
                    Instantiate(zombiePrefab, generatingPlace.position, generatingPlace.rotation);
                }

                _countEnemies++;
                if (_countEnemies == numberEnemiesTeams) {
                    Destroy(gameObject, 0f);
                }
            }
            yield return new WaitForSeconds(generationTime);
        }
    }
    
}
