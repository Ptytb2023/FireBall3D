using Coroutines;
using Obstacle;
using Obstacle.Sequence;
using Obstaicel.Sequence;
using Sequence;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Obstaicel
{
    public class ObstaacelMovement : MonoBehaviour
    {
        [SerializeField] private FloatRange _moveDuration;
        [SerializeField] private FloatRange _changeSpeedDuration;
        [SerializeField] private FloatRange _speed;
        [SerializeField] private AnimationCurve _changeSpeedCuve;


        private void Start()
        {
            IMovement movment = new RotationMovement(transform, Vector3.up, _speed.Min);

            var terms = new ISequnceTerm[]
            {
                new MoveSequenceTerm(_changeSpeedDuration,movment),
                new ChangeSpeedSequenceTerm(movment,_speed,_changeSpeedDuration,_changeSpeedCuve),
            };

            CoroutinesExecutor coroutinesExecutor = new CoroutinesExecutor(this);

            MovementSequence sequence = new MovementSequence(terms, coroutinesExecutor);

            sequence.StartProccesing();
        }

      
    }
}
