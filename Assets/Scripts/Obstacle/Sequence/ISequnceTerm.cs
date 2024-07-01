using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle.Sequence
{
    public interface ISequnceTerm
    {
        public IEnumerator GetSequnceCorutine();
    }
}