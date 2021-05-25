using System;
using System.Collections.Generic;
using System.Text;

namespace MAv3.Models
{
    class Items
    {
        string Name;
        string Description;

        public Items(string _name, string _description)
        {
            Name = _name;
            Description = _description;
        }

        public void CreateItem()
        {
            var hex = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(Description);
            foreach (var t in bytes)
            {
                hex.Append(t.ToString("X2"));
            }

            string hexString = hex.ToString();
        }
    }
}
