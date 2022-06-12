using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using clib.BL;
namespace clib.DL
{
    public class EnemyDL
    {
        List<Enemy> enemyList= new List<Enemy>();
        public EventHandler onAdd;

        public void add_list(int top, int left, int s, int g)
        {
            Enemy e =new Enemy(top,left,s,g);
            enemyList.Add(e);
            onAdd?.Invoke(e.pb, EventArgs.Empty);
        }
        public void move(int width,List<Floor> list)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].move(width,list);
            }
        }
        public void gravity(List<Floor> list)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].gravity(list);
            }
        }
    }
}
