﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightweightPhotoSuite
{
    class Tag
    {
        private static Dictionary<int, Tag> idToTag;
        private static Dictionary<string, Tag> nameToTag;
        private static int idCounter;

        public readonly int id;
        public string name { get; private set; }

        /// <summary>
        /// Do not call! Call Tag.GiveTag() instead.
        /// </summary>
        public Tag() { }

        private Tag(string name)
        {
            this.name = name;
            id = idCounter++;
        }
        
        public static Tag GiveTag(string name)
        {
            if (nameToTag.ContainsKey(name))
            {
                return nameToTag[name];
            }
            else
            {
                Tag newTag = new Tag(name);
                idToTag.Add(newTag.id, newTag);
                nameToTag.Add(newTag.name, newTag);
                return newTag;
            }
        }

        public bool rename(string newName)
        {
            if (nameToTag.ContainsKey(newName))
            {
                return false;
            }
            else
            {
                name = newName;
                nameToTag.Remove(name);
                nameToTag.Add(newName, this);
                return true;
            }
        }
    }
}