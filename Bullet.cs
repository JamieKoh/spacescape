using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Bullet class that inherits from the abstract PlayerController class
    /// </summary>
    public class Bullet:PlayerController{

        private Bitmap bullet;

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Bullet(float x, float y){
            X = x;
            Y = y;
            bullet = new Bitmap("bullet", "images/bullet.png");
        }

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        public Bullet():this(0, 0){}
        public Bitmap _bullet{
            get{return bullet;}
            set{bullet = value;}
        }

        /// <summary>
        /// This method checks to see if the bullet has collided with an enemy
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Boolean CheckIfCollide(Enemy e){

            Boolean collide;
            collide = SplashKit.BitmapCollision(bullet, X, Y, e.CurrentEnemy, e.x, e.y);
            return collide;
        }

        /// <summary>
        /// This method draws the bitmap bullet to the gamewindow. It is overriden from the PlayerController class
        /// </summary>
        /// <param name="window"></param>
        public override void Draw(Window window)
        {
            window.DrawBitmap(bullet, X, Y);
        }

        /// <summary>
        /// This method moves the bullet. It is overriden from the PlayerController class
        /// </summary>
        public override void Move(){
            Y = Y - 5;
        }
    }

    
}