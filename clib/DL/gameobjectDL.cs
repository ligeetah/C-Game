using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace clib.game
{
    public class gameobjectDL
    {
        public EventHandler onAdd;
        private List<gameobject> gameobjects = new List<gameobject>();
        public void add_list(Image p,string m,int top,int left)
        {
            gameobject k = new gameobject(p, m,top,left);
            gameobjects.Add(k);
            onAdd?.Invoke(k.Pb, EventArgs.Empty);

        }
        public void gravity()
        {
            for (int i = 0; i < gameobjects.Count; i++)
            {
                gameobjects[i].Pb.Top += 10;
            }
        }
    }
}
