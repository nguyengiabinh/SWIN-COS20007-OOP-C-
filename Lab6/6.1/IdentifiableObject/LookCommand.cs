﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string _itemID;

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            switch (text.Length)
            {
                case 3:
                    _container = p;
                    break;
                case 5:
                    if (text[3] != "in")
                    {
                        return "What do you want to look in?";
                    }
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                    {
                        return $"i can't find the {text[4]}";
                    }
                    break;
                default:
                    return "Something wrong with the input length";
            }
            _itemID = text[2];
            return LookAtIn(_itemID,  _container);
        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return $"I can't find the {thingId}";
            }
            else
            {
                return container.Locate(thingId).Description;
            }
        }
    }
}
