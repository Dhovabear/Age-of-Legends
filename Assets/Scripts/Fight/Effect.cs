using UnityEngine;

namespace Fight
{
    public class Effect : MonoBehaviour
    {

        [SerializeField] public string name;
        [SerializeField] public int durability;


        public Effect()
        {
            name = "Effet";
            durability = 1;
        }
    }
}
