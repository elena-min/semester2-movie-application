using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Cast
    {
        private List<string> actors;

        public string MediaItemTitle { get; private set; }
        public Cast(string movieName)
        {
            MediaItemTitle  = movieName;
            actors = new List<string>();
        }

        public void AddToCast(string actor)
        {
            actors.Add(actor);
        }
        public void RemoveFromCast(string actor) 
        {
            actors.Remove(actor);
        }
        public override string ToString()
        {
            return string.Join(", ", actors);
        }
    }
}
