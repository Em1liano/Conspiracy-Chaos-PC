using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils.WorldGenerator.Models
{
    public class Stage : MonoBehaviour
    {
        private bool isPlayerCollidedOnce;

        [SerializeField]
        public GameObject Enter;

        [SerializeField]
        public GameObject Exit;

        public event EventHandler onLoadNextStagePointEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!isPlayerCollidedOnce && collision.gameObject.tag == "Player")
            {
                onLoadNextStagePointEnter.Invoke(this, new EventArgs());
                isPlayerCollidedOnce = true;
            }
        }
    }
}
