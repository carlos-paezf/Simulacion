using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour{
  
    private GameObject   _target;
    private NavMeshAgent _agent;
    private Life         _life;
    private Animator     _animator;
    private Collider     _collider;
    private Life         _playerLife;
    private PlayerLogic  _playerLogic;
    public  bool         life0        = false;
    public  bool         isAttacking  = false;
    public  float        speed        = 1.0f;
    public  float        angularSpeed = 120f;
    public  float        damage       = 25;
    public  bool         looking;
    public  bool         addPoints = false;
    public  GameObject   valueScorePrefab;

    void Start() {
        _target      = GameObject.Find("Player");
        _playerLife = _target.GetComponent<Life>();
        if (_playerLife == null) {
            throw new System.Exception("El objeto jugador no tiene componente vida");
        }
        _playerLogic = _target.GetComponent<PlayerLogic>();
        if (_playerLogic == null) {
            throw new SystemException("No tiene componenten LogicaJugador");
        }

        _agent    = GetComponent<NavMeshAgent>();
        _life     = GetComponent<Life>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

    }

    void Update() {
        CheckLife();
        Chase();
        CheckAtack();
        IsFrontOfPlayer();
    }

    private void IsFrontOfPlayer() {
        Vector3 forward      = transform.forward;
        Vector3 playerTarget = (GameObject.Find("Player").transform.position - transform.position).normalized;
        if (Vector3.Dot(forward, playerTarget) < 0.6f) {
            looking = false;
        }
        else {
            looking = true;
        }
    }

    private void CheckLife() {
        if (life0) return;
        if (_life.value <= 0) {
            addPoints       = true;
            if (addPoints) {
                valueScorePrefab.GetComponent<ScorePlayer>().value += 20;
                addPoints                                          =  false;
            }
            life0             = true;
            _agent.isStopped  = true;
            _collider.enabled = false;
            _animator.CrossFadeInFixedTime("Life0", 0.1f);
            Destroy(gameObject, 3f);
        }
    }

    private void Chase() {
        if (life0) return;
        if (_playerLogic.vida0) return;
        _agent.destination = _target.transform.position;
    }

    private void CheckAtack() {
        if (life0) return;
        if (isAttacking) return;
        if (_playerLogic.vida0) return;
        float distanceToTarget = Vector3.Distance(_target.transform.position, transform.position);
        if (distanceToTarget <= 2.0 && looking) {
            Atack();
        }
    }

    private void Atack() {
        _playerLife.TakeDamage(damage);
        _agent.speed        = 0;
        _agent.angularSpeed = 0;
        isAttacking        = true;
        _animator.SetTrigger("MustAtack");
        Invoke("RestartAttack", 1f);
        if (isAttacking) {
            valueScorePrefab.GetComponent<ScorePlayer>().value -= 5;
        }
    }

    private void RestartAttack() {
        isAttacking        = false;
        _agent.speed        = speed;
        _agent.angularSpeed = angularSpeed;
    }
}
