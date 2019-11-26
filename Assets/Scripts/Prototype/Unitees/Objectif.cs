using UnityEngine;

namespace Prototype.Unitees
{
    
    public class Objectif
    {

        public string name;
        public Vector3 location;
        
        public Objectif(Vector3 location , string name)
        {
            this.location = location;
            this.name = name;
        }
    }
}
