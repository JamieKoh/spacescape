using System;
using SplashKitSDK;

namespace CustomProgram{

    /// <summary>
    /// This is the Star class
    /// </summary>
    public class Star{
        private float x;
        private float y;
        private Random randx;
        private Random type;
        Bitmap star;

        /// <summary>
        /// This is the class constructor that accepts values
        /// </summary>
        /// <param name="_star"></param>
        public Star(Bitmap _star){
            randx = new Random();
            type = new Random();
            y = 0;
            x = randx.Next(1, 1399);
            star = _star;
        }

        /// <summary>
        /// This is the default class constructor
        /// </summary>
        public Star():this(new Bitmap("star_1", "images/star_1.png")){}

        /// <summary>
        /// This property returns the y attribute
        /// </summary>
        /// <value></value>
        public float Y{
            get{return y;}
            set{y = value;}
        }

        /// <summary>
        /// This method draws the star to the game window
        /// </summary>
        /// <param name="window"></param>
        public void Draw(Window window){
            window.DrawBitmap(star, x, y);
        }

        /// <summary>
        /// This method moves the stars
        /// </summary>
        public void Move(){
            Y += 3;
        }
    }
}