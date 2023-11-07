using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        public string _desc;
        private string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _desc = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public virtual string Description
        {
            get 
            { 
                return _desc; 
            }
        }

        public string ShortDescription
        {
            get
            {
                return _name + ": " + /*FirstId.ToLower()*/ Description;
            }
        }
    }
}
