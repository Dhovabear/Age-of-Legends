using UnityEngine;

namespace Prototype.Unitees
{
    public class Objectif
    {

        public string name { get; }
        public Vector3 location { get; }
        
        public Objectif(Vector3 location , string name)
        {
            this.location = location;
            this.name = name;
        }
    }
}
