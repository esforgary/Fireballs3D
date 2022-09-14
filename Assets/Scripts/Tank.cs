using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBeetwenShoot;
    [SerializeField] private float _recoilDistance;
    
    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBeetwenShoot)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBeetwenShoot / 2).SetLoops(2, LoopType.Yoyo);  
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }
}
