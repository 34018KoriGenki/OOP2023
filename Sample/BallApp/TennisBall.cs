using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class TennisBall : Obj {

        private static int tennisCount = 0;

        //コンストラクタ
        public TennisBall(double xp, double yp)
                : base(xp, yp, Image.FromFile(@"pic\tennis_Ball.png")) {
            TennisCount++;
        }
        
        public  static int TennisCount { get => tennisCount; set => tennisCount = value; }
        
        //メソッド
        override
        public void Move(Program form, PictureBox pb) {
            Ricochet(form, pb);
            PosX += MoveX;
            PosY += MoveY;
            
        }

        override
        public void Ricochet(Program form, PictureBox pb) {
            if (this.PosX < 0 || PosX > form.Width - pb.Width)
            {
                MoveX *= -1;
            }
            if (this.PosY < 0 || this.PosY > form.Height - pb.Height)
            {
                MoveY *= -1;
            }
        }
    }
}
