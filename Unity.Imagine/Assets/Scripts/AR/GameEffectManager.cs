﻿
using UnityEngine;
using System.Linq;

public class GameEffectManager : MonoBehaviour {

  [SerializeField]
  GameEffect _player1effect = null;
  public GameEffect p1effect { get { return _player1effect; } }

  [SerializeField]
  GameEffect _player2effect = null;
  public GameEffect p2effect { get { return _player2effect; } }

  [SerializeField]
  GameEffect _paper = null;

  [SerializeField, Range(0f, 100f)]
  float _paperOffset = 10f;

  [SerializeField]
  OneTimeEffect _fire = null;

  [SerializeField]
  Vector3 _fireOffset = Vector3.zero;

  [SerializeField, Range(0f, 100f)]
  float _randomRange = 10f;

  /// <summary> 花火打ち上げ </summary>
  public OneTimeEffect CreateFireWorks(Transform winner) {
    var fire = Instantiate(_fire);
    fire.transform.SetParent(transform);

    var position = winner.position + _fireOffset;
    var random = Random.insideUnitSphere * _randomRange;
    fire.transform.position = position + random;
    return fire;
  }

  /// <summary> 紙吹雪開始 </summary>
  public void ActivatePaper(Transform winner) {
    var paper = Instantiate(_paper);
    paper.transform.position = winner.position + Vector3.up * _paperOffset * 10f;
    paper.particle.loop = true;
    paper.particle.Play();
  }
}
