using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    abstract class Obj {
        //フィールド
        private Image image;        //画像データ

        private double posX;        // X座標
        private double posY;        // Y座標
        private double moveX;
        private double moveY;
        private static int count = 0;


        //コンストラクタ
        public Obj(double xp, double yp, Image Image) {
            this.Image = Image;
            PosX = xp;
            PosY = yp;
            Random rm = new Random();
            MoveX = rm.Next(-50, 50) * 0.5;  //移動量(X方向)
            MoveY = rm.Next(-50, 50) * 0.5;  //移動量(Y方向)

            Count++;
        }

        //プロパティ
        public Image Image { get => image; set => image = value; }
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public double MoveX { get => moveX; set => moveX = value; }
        public double MoveY { get => moveY; set => moveY = value; }

        public static int Count { get => count; set => count = value; }

        //メソッド(抽象メソッド)
        public abstract void Move(Program form, PictureBox pb);

        public abstract void Ricochet(Program form, PictureBox pb);

    }
}
