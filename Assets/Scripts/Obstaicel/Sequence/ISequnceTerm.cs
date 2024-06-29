using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacel.Sequence
{
    public interface ISequnceTerm
    {
        public IEnumerator GetSequnceCorutine();
    }
}