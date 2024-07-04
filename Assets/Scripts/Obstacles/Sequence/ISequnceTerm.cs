using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles.Sequence
{
    public interface ISequnceTerm
    {
        public IEnumerator GetSequnceCorutine();
    }
}