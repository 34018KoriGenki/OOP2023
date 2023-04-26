using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class SoccerBall : Obj {

        private static int soccerCount = 0;

        //コンストラクタ
        public SoccerBall(double xp, double yp)
                : base(xp, yp, Image.FromFile(@"pic\soccer_Ball.png")) {
            SoccerCount++;
        }

        public static int SoccerCount { get => soccerCount; set => soccerCount = value; }

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