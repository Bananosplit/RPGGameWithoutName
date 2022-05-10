using System;
using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.Input;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero {
    public class HeroMove : MonoBehaviour, ISavedProgressReader
    {
        public CharacterController CharacterController;
        public float MovementSpeed = 4.0f;
        private IInputService _inputService;
        private Camera _camera;


        public void SaveProgress(PlayerProgress progress) {
            progress.Level = 
                new PositionOnLevel(transform.position.AsVectorData(), SceneManager.GetActiveScene().name);
        }

        public void LoadProgress(PlayerProgress progress) {
            if(SceneManager.GetActiveScene().name == progress.Level.SceneName) {
                var savedPosition = progress.Level.Position;
                if(savedPosition != null) 
                    Swap(savedPosition);
            }
        }

        private void Swap(Vector3Data to) {
            CharacterController.enabled = false;
            transform.position = to.AsUnityVector3().AddY(CharacterController.height);
            CharacterController.enabled = true;
        }

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
               
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            
            CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }

    
}